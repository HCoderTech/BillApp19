using BillApp.DBHelper.Common;
using BillApp.DBHelper.Data;
using BillApp.DBHelper.MainForm;
using NUnit.Framework;
using System.IO;

namespace BillApp.Tests
{
    public class MainDBHelperTests
    {
        IMainDBHelper mainDBHelper;
        CommonDBHelper dbHelper = new CommonDBHelper();
        private void PathCreate()
        {
            Directory.CreateDirectory("MRStudio\\");
        }

        private void FileCreate()
        {
            File.Create("MRStudio\\count.txt").Close();
            TextWriter tw = new StreamWriter("MRStudio\\count.txt");
            tw.WriteLine("50000");
            tw.Close();
        }
        private void PathInitialize()
        {
            if (Directory.Exists("MRStudio\\"))
            {
                if (File.Exists("MRStudio\\count.txt"))
                {
                    File.Delete("MRStudio\\count.txt");
                }
                if (File.Exists("MRStudio\\MyData.db"))
                {
                    File.Delete("MRStudio\\MyData.db");
                }

                Directory.Delete("MRStudio\\");
            }

        }
        [OneTimeSetUp]
        public void OneTimeInitialize()
        {
            PathInitialize();
            PathCreate();
            FileCreate();
        }

        [SetUp]
        public void TestInitialize()
        {
            if (Directory.Exists("MRStudio\\") && File.Exists("MRStudio\\MyData.db"))
                File.Delete("MRStudio\\MyData.db");
            else
                Directory.CreateDirectory("MRStudio\\");
            dbHelper.AddAdminUser("admin", "admin");
            dbHelper.AddStandardUser("Arun", "Hello");
            mainDBHelper = new MainDBHelper();
        }

        [Test]
        public void InitializeNewEntryForceCreate()
        {
            bool isInitialized=mainDBHelper.InitializeNewBillEntry("Suresh", true);
            Assert.IsTrue(isInitialized,"Internal Status of current Bill Entry not initialized");
            Assert.AreEqual(string.Empty, mainDBHelper.GetCustomerName(), "Internal customerName of current Bill Entry not initialized");
            Assert.AreEqual(string.Empty, mainDBHelper.GetPhoneNumber(), "Internal PhoneNumber of current Bill Entry not initialized");
            Assert.AreEqual("50000", mainDBHelper.GetBillID(), "Initialize value not read from file correctly.");
            Assert.AreEqual(BillType.Undefined, mainDBHelper.GetBillType(),"Internal Bill Type not in the right state.");
        }

        [Test]
        public void InitializeNewEntrySaveNeeded()
        {
            mainDBHelper.InitializeNewBillEntry("Suresh", true);
            mainDBHelper.UpdateCustomerName("Ram");
            bool isInitialized = mainDBHelper.InitializeNewBillEntry("Suresh", false);
            Assert.IsFalse(isInitialized, "Internal Status of current Bill Entry should not initialized");
        }

        [Test]
        public void UpdateCustomerNameSucceeded()
        {
            mainDBHelper.InitializeNewBillEntry("Suresh", true);
            mainDBHelper.UpdateCustomerName("Ram");
            Assert.AreEqual("Ram", mainDBHelper.GetCustomerName(),"Customer Name is not updated when it follows right pattern.");
        }

        [Test]
        public void UpdateCustomerNameFailed()
        {
            mainDBHelper.InitializeNewBillEntry("Suresh", true);
            mainDBHelper.UpdateCustomerName("Ram@%");
            Assert.AreEqual(string.Empty, mainDBHelper.GetCustomerName(), "Customer Name is updated when it doesn't follow right pattern.");
        }

        [Test]
        public void UpdatePhoneNumberSucceeded()
        {
            mainDBHelper.InitializeNewBillEntry("Suresh", true);
            mainDBHelper.UpdatePhoneNumber("9487556877");
            Assert.AreEqual("9487556877", mainDBHelper.GetPhoneNumber(), "Phone Number is not updated when it follows right pattern.");
        }

        [Test]
        public void UpdatePhoneNumberFailed()
        {
            mainDBHelper.InitializeNewBillEntry("Suresh", true);
            mainDBHelper.UpdateCustomerName("944O235698");
            Assert.AreEqual(string.Empty, mainDBHelper.GetPhoneNumber(), "Phone Number is updated when it doesn't follow right pattern.");
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void UpdateBillType(int billType)
        {
            mainDBHelper.InitializeNewBillEntry("Suresh", true);
            mainDBHelper.UpdateBillType(billType);
            Assert.AreEqual(billType+1,(int)mainDBHelper.GetBillType(),"Uodate BillType not successful for valid values.");
        }
        [Test]
        public void UpdateBillTypeFailed()
        {
            mainDBHelper.InitializeNewBillEntry("Suresh", true);
            mainDBHelper.UpdateBillType(2);
            mainDBHelper.UpdateBillType(-1);
            Assert.AreEqual(3, (int)mainDBHelper.GetBillType(), "Uodate BillType successful for invalid values.");
        }

    }
}
