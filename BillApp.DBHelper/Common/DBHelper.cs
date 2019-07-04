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
    }
}
