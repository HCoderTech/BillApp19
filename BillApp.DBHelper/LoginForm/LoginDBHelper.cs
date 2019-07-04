using BillApp.DBHelper.SplashScreen.Data;
using LiteDB;
using System.Linq;

namespace BillApp.DBHelper
{
    public interface ILoginDBHelper
    {
        bool IsAdminExist(string username,string password);
        bool IsUserExist(string username, string password);
    }
    public class LoginDBHelper : ILoginDBHelper
    {
        public bool IsAdminExist(string username, string password)
        {
            using (var db = new LiteDatabase("MRStudio\\MyData.db"))
            {
                var col = db.GetCollection<UserDetail>("AdminUsers");
                return col.Exists(x => x.Username == username && x.Password == password);
            }
        }

        public bool IsUserExist(string username, string password)
        {
            using (var db = new LiteDatabase("MRStudio\\MyData.db"))
            {
                var col = db.GetCollection<UserDetail>("StandardUsers");
                return col.Exists(x => x.Username == username && x.Password == password);
            }
        }
    }
}
