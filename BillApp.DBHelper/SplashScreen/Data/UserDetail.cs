using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.DBHelper.SplashScreen.Data
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public static UserDetail GetDefault()
        {
            return new UserDetail
            {
                Username = "admin",
                Password = "admin"
            };
        }
    }
}
