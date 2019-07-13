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

        private void AddProductsToDatabase()
        {
            if (File.Exists("MRStudio\\MyData.db"))
                File.Delete("MRStudio\\MyData.db");
           
            dbHelper.AddProductDetails("PhotoFrame", 100);
            dbHelper.AddProductDetails("Selfie", 50);
            dbHelper.AddProductDetails("ProfilePic", 40);
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
            AddProductsToDatabase();
        }

        [SetUp]
        public void TestInitialize()
        {
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
            mainDBHelper.UpdatePhoneNumber("944O235698");
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

        [TestCase(true)]
        [TestCase(false)]
        public void UpdateDeliverStatus(bool status)
        {
            mainDBHelper.InitializeNewBillEntry("Suresh", true);
            mainDBHelper.UpdateDeliverStatus(status);
            Assert.AreEqual(status, mainDBHelper.GetDeliverStatus(), "Deliver Status not updated correctly.");
        }

        [Test]
        public void AddProductThatDoesntExist()
        {
            double amount = 0;
            mainDBHelper.InitializeNewBillEntry("Suresh", true);
            bool isAdded=mainDBHelper.AddProduct("Product",out amount);
            Assert.IsFalse(isAdded, "Product added to Bill entry, when it doesn't exist in database.");
        }

        [Test]
        public void AddProductFirstTime()
        {
            double amount = 0;
            mainDBHelper.InitializeNewBillEntry("Suresh", true);
            bool isAdded = mainDBHelper.AddProduct("Selfie", out amount);
            Assert.IsTrue(isAdded, "Product not added to Bill entry, when it exists in database.");
            Assert.AreEqual(50, amount, "Amount for the product not equal to the expected value.");
            Assert.AreEqual("50", mainDBHelper.GetTotalAmount(), "Amount for the product not equal to the expected value.");
        }
        [Test]
        public void AddProductMultipleEntries()
        {
            double amount = 0;
            mainDBHelper.InitializeNewBillEntry("Suresh", true);
            mainDBHelper.AddProduct("Selfie", out amount);
            bool isAdded = mainDBHelper.AddProduct("Selfie", out amount);
            Assert.IsTrue(isAdded, "Product not added to Bill entry, when it exists in database.");
            Assert.AreEqual(50, amount, "Amount for the product not equal to the expected value.");
            Assert.AreEqual("100", mainDBHelper.GetTotalAmount(), "Amount for the product not equal to the expected value.");
        }

        [Test]
        public void AddMultipleProducts()
        {
            double amount = 0;
            mainDBHelper.InitializeNewBillEntry("Suresh", true);
            bool isAdded = true;
            isAdded &= mainDBHelper.AddProduct("Selfie", out amount);
            isAdded &= mainDBHelper.AddProduct("PhotoFrame", out amount);
            isAdded &= mainDBHelper.AddProduct("ProfilePic", out amount);
            Assert.IsTrue(isAdded, "Products not added to Bill entry, when it exists in database.");
            Assert.AreEqual(40, amount, "Amount for the product not equal to the expected value.");
            Assert.AreEqual("190", mainDBHelper.GetTotalAmount(), "Amount for the products not equal to the expected value.");
        }

        [Test]
        public void UpdateQuantityProductExist()
        {
            double amount = 0;
            mainDBHelper.InitializeNewBillEntry("Suresh", true);
            bool isAdded = true;
            isAdded &= mainDBHelper.AddProduct("Selfie", out amount);
            isAdded &= mainDBHelper.AddProduct("PhotoFrame", out amount);
            isAdded &= mainDBHelper.AddProduct("ProfilePic", out amount);
            mainDBHelper.UpdateQuantity("Selfie",3,out amount);
            Assert.IsTrue(isAdded, "Products not added to Bill entry, when it exists in database.");
            Assert.AreEqual(150, amount, "Amount for the product not equal to the expected value.");
            Assert.AreEqual("290", mainDBHelper.GetTotalAmount(), "Amount for the products not equal to the expected value.");
        }

        [Test]
        public void UpdateQuantityProductNotExist()
        {
            double amount = 0;
            mainDBHelper.InitializeNewBillEntry("Suresh", true);
            bool isAdded = true;
            isAdded &= mainDBHelper.AddProduct("Selfie", out amount);
            isAdded &= mainDBHelper.AddProduct("PhotoFrame", out amount);
            isAdded &= mainDBHelper.AddProduct("ProfilePic", out amount);
            mainDBHelper.UpdateQuantity("Selfies", 3, out amount);
            Assert.IsTrue(isAdded, "Products not added to Bill entry, when it exists in database.");
            Assert.AreEqual(0, amount, "Amount for the product not equal to the expected value.");
            Assert.AreEqual("190", mainDBHelper.GetTotalAmount(), "Amount for the products not equal to the expected value.");
        }


    }
}
