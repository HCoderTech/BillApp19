using BillApp.DBHelper.SplashScreen.Data;
using LiteDB;
using BillApp.DBHelper.Data;

namespace BillApp.DBHelper.SplashScreen
{
    public interface ISplashScreenDBHelper
    {
        void InitializeDB();
    }
    public class SplashScreenDBHelper : ISplashScreenDBHelper
    {
        public void InitializeDB()
        {
            using (var db = new LiteDatabase("MRStudio\\MyData.db"))
            {
                var col = db.GetCollection<UserDetail>("AdminUsers");
                var defaultUser = UserDetail.GetDefault();
                col.Insert(defaultUser);
                col.EnsureIndex("Id");

                var products = db.GetCollection<Product>("ProductDetails");
                Product product1 = new Product() { ProductName = "Photo Frame", Rate = 100 };
                Product product2 = new Product() { ProductName = "PassPort", Rate = 10 };
                Product product3 = new Product() { ProductName = "Profile Pic", Rate = 30 };
                Product product4 = new Product() { ProductName = "Selfie", Rate = 30 };

                products.Insert(product1);
                products.Insert(product2);
                products.Insert(product3);
                products.Insert(product4);
                products.EnsureIndex("Id");
            }
        }

    }
}
