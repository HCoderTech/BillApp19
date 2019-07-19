using BillApp.DBHelper.Common;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BillApp.DBHelper.Data
{
    [Serializable]
    public class BillEntry
    {
        [BsonId]
        public int Id { get; set; }
        public string BillID { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string ProductList { get { return Products.ToString(); }
            set { Products.FromString(value); }
        }
        [BsonIgnore]
        public ProductPurchase Products { get; set; } = new ProductPurchase();
        public bool Delivered { get; set; }
        public BillType BillType { get; set; }
        public string BilledByUser { get; set; }
        public double Advance { get { return Products.Advance; } }
        public double Discount { get { return Products.Discount; } }
        public double Balance { get { return Products.Balance; } }
        public double TotalAmount { get { return Products.TotalAmount; } }
        public DateTime DateTimeFirstEntry { get; set; }
        public DateTime DateTimeLastUpdate { get; set; }
    }

    public enum BillType { Undefined,Cash, Card, UPI }
    
    [Serializable]
    public class ProductPurchase
    {
        
        public int PurchaseId { get; set; }
      
        public Dictionary<Product, double> ProductList { get; set; } = new Dictionary<Product, double>();
        public double Advance { get; set; }
        public double Discount { get; set; }
        public double Balance { get; set; }
        public double TotalAmount { get; set; }
        

        public void AddProductPurchase(Product product,double quantity=1)
        {
            ProductList.Add(product, quantity);
            UpdateValues();
        }

        public void RemoveProductPurchase(Product product)
        {
            ProductList.Remove(product);
        }

        public override string ToString()
        {
            string productString = string.Empty;
            foreach(KeyValuePair<Product,double> kvp in ProductList)
            {
                productString = productString + kvp.Key.ProductName + "-" + kvp.Value+";";
            }
            return productString;
        }

        public void FromString(string productString)
        {
            ProductList = new Dictionary<Product, double>();
            foreach(string someProduct in productString.Split(';'))
            {
                if (someProduct != "")
                {
                    string[] comp = someProduct.Split('-');

                    Product product = (new CommonDBHelper()).GetProduct(comp[0]);
                    double quantity = double.Parse(comp[1]);
                    ProductList.Add(product, quantity);
                }
            }
        }

        public void UpdateProductPurchase(Product product, double quantity,bool addtoExisting=false)
        {
            try
            {
                if (addtoExisting)
                {
                    ProductList[product] = ProductList[product] + quantity;
                }
                else
                {
                    ProductList[product] = quantity;
                }
                UpdateValues();
            }
            catch {
                //Not handled now.Will be logged in the future
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

    [Serializable]
    public sealed class Product:IEquatable<Product>
    {
        [BsonId]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Rate { get; set; }

        public override int GetHashCode()
        {
            return ProductId;
        }

        public override bool Equals(object obj)
        {
            return Equals((Product)obj);
        }

        public bool Equals(Product other)
        {
           return ProductName==other.ProductName;
        }
    }
}
