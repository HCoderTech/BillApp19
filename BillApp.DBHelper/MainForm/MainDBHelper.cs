using System;
using BillApp.DBHelper.Data;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using LiteDB;
using System.Linq;

namespace BillApp.DBHelper.MainForm
{
    public interface IMainDBHelper
    {
        bool UpdateCustomerName(string customerName);
        bool InitializeNewBillEntry(string BilledBy,bool forceCreate);
        string GetCustomerName();
        string GetBillID();
        bool UpdatePhoneNumber(string phoneNumber);
        string GetPhoneNumber();
        bool UpdateDiscount(double discount,out double balance);
        bool UpdateAdvance(double advance, out double balance);
        List<string> GetProducts(string productPattern);
        void UpdateBillType(int billType);
        void UpdateDeliverStatus(bool status);
        bool GetDeliverStatus();
        bool AddProduct(string productName,out double amount);
        string GetTotalAmount();
        string GetBalance();
        string GetAdvance();
        string GetDiscount();
        void UpdateQuantity(string productName, double value, out double amount);
        BillType GetBillType();
        bool SaveEntryToDatabase();
    }

    public class MainDBHelper:IMainDBHelper
    {
        private BillEntry currentBillEntry;
        bool saveNeeded,firsttimesave;
        public bool InitializeNewBillEntry(string BilledBy,bool forceCreate)
        {
            if (forceCreate || !saveNeeded)
            {
                currentBillEntry = new BillEntry();
                currentBillEntry.CustomerName = "";
                currentBillEntry.PhoneNumber = "";
                currentBillEntry.BillID = File.ReadAllText("MRStudio\\count.txt").Replace("\r\n","");
                currentBillEntry.BilledByUser = BilledBy;
                saveNeeded = false;
                firsttimesave = true;
                return true;
            }

            return false;
        }

        public string GetCustomerName()
        {
            return currentBillEntry.CustomerName;
        }
        public string GetBillID()
        {
            return currentBillEntry.BillID;
        }

        public bool UpdateCustomerName(string customerName)
        {
            if (isNameValid(customerName))
            {
                currentBillEntry.CustomerName = customerName;
                saveNeeded = true;
                return true;
            }
            return false;
        }

        bool isNameValid(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        bool isPhoneNumberValid(string phone)
        {
            return Regex.IsMatch(phone, @"^[0-9]+$");
        }

        public bool UpdatePhoneNumber(string phoneNumber)
        {
            if (isPhoneNumberValid(phoneNumber))
            {
                currentBillEntry.PhoneNumber = phoneNumber;
                saveNeeded = true;
                return true;
            }
            return false;
        }

        public string GetPhoneNumber()
        {
           return currentBillEntry.PhoneNumber;
        }

        public bool UpdateDiscount(double discount,out double balance)
        {
            balance = currentBillEntry.Products.TotalAmount - currentBillEntry.Products.Advance - discount;
            if (balance < 0)
                return false;
            currentBillEntry.Products.Discount = discount;
            currentBillEntry.Products.Balance = balance;
            saveNeeded = true;
            return true;
        }

        public bool UpdateAdvance(double advance, out double balance)
        {
            balance=currentBillEntry.Products.TotalAmount - advance;
            if (balance < 0)
                return false;
            currentBillEntry.Products.Advance = advance;
            currentBillEntry.Products.Balance = balance;
            saveNeeded = true;
            return true;
        }

        public List<string> GetProducts(string productPattern)
        {
            using (var db = new LiteDatabase("MRStudio\\MyData.db"))
            {
                var products = db.GetCollection<Product>("ProductDetails");
                IEnumerable<Product> productSelected=products.Find(x => x.ProductName.ToLower().Contains(productPattern.ToLower()));
                List<Product> productList = productSelected.ToList();
                return productList.Select(x => x.ProductName).ToList();
            }
        }

        public void UpdateBillType(int billType)
        {
            if (billType < 0) return;
           
                currentBillEntry.BillType = (BillType)(billType+1);
                saveNeeded = true;
        }

        public void UpdateDeliverStatus(bool status)
        {
            currentBillEntry.Delivered = status;
            saveNeeded = true;
        }

        public bool AddProduct(string productName,out double amount)
        {
            amount = 0;
            Product product = null;
            if (ProductExists(productName,out product) && !currentBillEntry.Products.AlreadyExists(productName))
            {
                currentBillEntry.Products.AddProductPurchase(product);
                amount = product.Rate;
                saveNeeded = true;
                return true;
            }else if (currentBillEntry.Products.AlreadyExists(productName))
            {
                amount = product.Rate;
                currentBillEntry.Products.UpdateProductPurchase(product, 1, true);
                saveNeeded = true;
                return true;
            }
            return false;
        }

        private bool ProductExists(string productName,out Product product)
        {
            product = null;
            using (var db = new LiteDatabase("MRStudio\\MyData.db"))
            {
                var products = db.GetCollection<Product>("ProductDetails");
                if(products.Exists(x => x.ProductName.ToLower()==(productName.ToLower())))
                {
                    product=products.Find(x => x.ProductName.ToLower() == (productName.ToLower())).First();
                    return true;
                }
                return false;
            }
        }

        public string GetTotalAmount()
        {
            return currentBillEntry.Products.TotalAmount.ToString();
        }

        public string GetBalance()
        {
            return currentBillEntry.Products.Balance.ToString();
        }

        public string GetAdvance()
        {
            return currentBillEntry.Products.Advance.ToString();
        }

        public string GetDiscount()
        {
            return currentBillEntry.Products.Discount.ToString();
        }

        public void UpdateQuantity(string productName, double value, out double amount)
        {
            Product product = null;
            amount = 0;
            if (ProductExists(productName, out product))
            {
                currentBillEntry.Products.UpdateProductPurchase(product, value);
                saveNeeded = true;
                amount = product.Rate * value;
            }
        }

        public BillType GetBillType()
        {
            return currentBillEntry.BillType;
        }

        public bool SaveEntryToDatabase()
        {
            if (firsttimesave && saveNeeded)
            {
                using (var db = new LiteDatabase("MRStudio\\MyData.db"))
                {
                    var billEntries = db.GetCollection<BillEntry>("InvoiceDetails");
                    billEntries.Insert(currentBillEntry);
                    billEntries.EnsureIndex("Id");
                    saveNeeded = false;
                    firsttimesave = false;
                    int number;
                    int.TryParse(File.ReadAllText("MRStudio\\count.txt"), out number);
                    number = number + 1;
                    File.WriteAllText("MRStudio\\count.txt", number.ToString());
                    return true;
                }
            }
            if (saveNeeded)
            {
                using (var db = new LiteDatabase("MRStudio\\MyData.db"))
                {
                    var billEntries = db.GetCollection<BillEntry>("InvoiceDetails");
                    billEntries.Update(currentBillEntry);
                    saveNeeded = false;
                    return true;
                }
            }
            return false;
        }

        public bool GetDeliverStatus()
        {
            return currentBillEntry.Delivered;
        }
    }
}
