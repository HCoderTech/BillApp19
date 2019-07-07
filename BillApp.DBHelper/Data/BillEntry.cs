using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BillApp.DBHelper.Data
{
    public class BillEntry
    {
        [BsonId]
        public int Id { get; set; }
        public string BillID { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public ProductPurchase Products { get; set; } = new ProductPurchase();
        public bool Delivered { get; set; }
        public BillType BillType { get; set; }
        public string BilledByUser { get; set; }
        public DateTime DateTimeFirstEntry { get; set; }
        public DateTime DateTimeLastUpdate { get; set; }

    }

    public enum BillType { Undefined,Cash, Card, UPI }

    public class ProductPurchase
    {
        public Dictionary<Product, double> ProductList { get; set; }
        public double Advance { get; set; }
        public double Discount { get; set; }
        public double Balance { get; set; }
        public double TotalAmount { get; set; }
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
        [BsonId]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Rate { get; set; }
    }
}
