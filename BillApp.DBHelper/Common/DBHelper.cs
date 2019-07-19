using BillApp.DBHelper.Data;
using BillApp.DBHelper.SplashScreen.Data;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.DBHelper.Common
{
    public class CommonDBHelper
    {
        public void AddAdminUser(string username,string password)
        {
            using (var db = new LiteDatabase("MRStudio\\MyData.db"))
            {
                var col = db.GetCollection<UserDetail>("AdminUsers");
                var adminUser =new UserDetail { Username = username, Password = password };
                col.Insert(adminUser);
                col.EnsureIndex("Id");
            }
        }

        public void AddStandardUser(string username, string password)
        {
            using (var db = new LiteDatabase("MRStudio\\MyData.db"))
            {
                var col = db.GetCollection<UserDetail>("StandardUsers");
                var adminUser = new UserDetail { Username = username, Password = password };
                col.Insert(adminUser);
                col.EnsureIndex("Id");
            }
        }

        public void AddProductDetails(string productName,double rate)
        {
            using (var db = new LiteDatabase("MRStudio\\MyData.db"))
            {
                var products = db.GetCollection<Product>("ProductDetails");
                Product product1 = new Product() { ProductName = productName, Rate = rate };
                products.Insert(product1);
                products.EnsureIndex("Id");
            }
        }

        public int GetBillEntryCount()
        {
            using (var db = new LiteDatabase("MRStudio\\MyData.db"))
            {
                var billEntries = db.GetCollection<BillEntry>("InvoiceDetails");
                return billEntries.Count() ;
            }
        }

        public BillEntry GetCustomer(string name,string phonenumber)
        {
            using (var db = new LiteDatabase("MRStudio\\MyData.db"))
            {
                var billEntries = db.GetCollection<BillEntry>("InvoiceDetails");
                return billEntries.FindAll().Where(x => x.CustomerName.ToLower()==name.ToLower() && x.PhoneNumber.ToLower()==phonenumber.ToLower()).First();
            }
        }

        public Product GetProduct(string productName)
        {
            Product product = null;
            using (var db = new LiteDatabase("MRStudio\\MyData.db"))
            {
                var products = db.GetCollection<Product>("ProductDetails");
                if (products.Exists(x => x.ProductName.ToLower() == (productName.ToLower())))
                {
                    product = products.Find(x => x.ProductName.ToLower() == (productName.ToLower())).First();
                   
                }
                return product;
            }
        }
    }
    
}
