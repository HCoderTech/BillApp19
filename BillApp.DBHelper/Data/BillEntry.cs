using System;
using System.Collections.Generic;
using System.Linq;

namespace BillApp.DBHelper.Data
{
    public class BillEntry
    {
        public int Id;
        public string BillID;
        public string CustomerName;
        public string PhoneNumber;
        public ProductPurchase Products=new ProductPurchase();
        public bool Delivered;
        public BillType BillType;
        public string BilledByUser;
        public DateTime DateTimeFirstEntry;
        public DateTime DateTimeLastUpdate;
       
    }

    public enum BillType { Undefined,Cash, Card, UPI }

    public class ProductPurchase
    {
        public Dictionary<Product,double> ProductList;
        public double Advance;
        public double Discount;
        public double Balance;
        public double TotalAmount;
        public ProductPurchase()
        {
            ProductList = new Dictionary<Product, double>();
        }

        public void AddProductPurchase(Product product,double quantity=1)
        {
            ProductList.Add(product, quantity);
            UpdateValues();
        }

        public void RemoveProductPurchase(Product product)
        {
            ProductList.Remove(product);
        }

        public void UpdateProductPurchase(Product product, double quantity,bool addtoExisting=false)
        {
            try
            {
                if(addtoExisting)
                {
                    ProductList[product] = ProductList[product] + quantity;
                }else
                {
                    ProductList[product] = quantity;
                }
                UpdateValues();
            }
            catch (Exception ex)
            {

            }
        }

        private void UpdateValues()
        {
            TotalAmount = 0;
            foreach(KeyValuePair<Product,double> entry in ProductList)
            {
                TotalAmount = TotalAmount + entry.Key.Rate * entry.Value;
            }
            Balance = TotalAmount - (Advance + Discount);
        }

        internal bool AlreadyExists(string productName)
        {
            return ProductList.Keys.Any(x => x.ProductName.ToLower() == productName.ToLower());
        }
    }
    public class Product
    {
        public int Id;
        public string ProductName;
        public double Rate;
    }
}
