using BillApp.DBHelper.SplashScreen.Data;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var col = db.GetCollection<UserDetail>("Users");
                var defaultUser = UserDetail.GetDefault();
                col.Insert(defaultUser);
            }
        }
    }
}
