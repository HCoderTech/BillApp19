using BillApp.DBHelper;
using BillApp.DBHelper.Common;
using NUnit.Framework;
using System.IO;

namespace BillApp.DBHelperTests
{
    [TestFixture]
    public class LoginDBHelperTests
    {
        ILoginDBHelper loginDBHelper;
        CommonDBHelper dbHelper=new CommonDBHelper();
        [SetUp]
        public void TestInitialize()
        {
            if (File.Exists("MRStudio\\MyData.db"))
                File.Delete("MRStudio\\MyData.db");
            dbHelper.AddAdminUser("admin", "admin");
            dbHelper.AddStandardUser("Arun", "Hello");
            loginDBHelper = new LoginDBHelper();
        }

        [Test]
        public void AdminUserExist()
        {
           bool isExist=loginDBHelper.IsAdminExist("admin", "admin");
           Assert.IsTrue(isExist,"Returned false when Admin user exists in the database."); 
        }

        [Test]
        public void AdminUserNotExist()
        {
            bool isExist = loginDBHelper.IsAdminExist("Admin", "admin");
            Assert.IsFalse(isExist, "Returned true when Admin user doesnot exists in the database.");
        }

        [Test]
        public void AdminUserWrongPassword()
        {
            bool isExist = loginDBHelper.IsAdminExist("admin", "Admin");
            Assert.IsFalse(isExist, "Returned true when Admin user exist, and password is wrong.");
        }

        [Test]
        public void StandardUserExist()
        {
            bool isExist = loginDBHelper.IsUserExist("Arun", "Hello");
            Assert.IsTrue(isExist, "Returned false when Standard user exists in the database.");
        }

        [Test]
        public void StandardUserNotExist()
        {
            bool isExist = loginDBHelper.IsAdminExist("arun", "Hello");
            Assert.IsFalse(isExist, "Returned true when Standard user doesnot exists in the database.");
        }

        [Test]
        public void StandardUserWrongPassword()
        {
            bool isExist = loginDBHelper.IsAdminExist("Arun", "hello");
            Assert.IsFalse(isExist, "Returned true when Standard user exist, and password is wrong.");
        }
    }
}
