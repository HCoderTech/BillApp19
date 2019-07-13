using BillApp.DBHelper.MainForm;
using BillApp.Presenter;
using BillApp.ViewHelper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BillApp.MainFormTests
{
    [TestFixture]
    public class MainFormTests
    {
        MainPresenter presenter;
        Mock<IMainView> mockView;
        Mock<IMainDBHelper> mockDBHelper;
        Mock<IDialogHelper> mockDialogHelper;
        [SetUp]
        public void InitializeMainPresenter()
        {
            mockView = new Mock<IMainView>();
            mockDBHelper = new Mock<IMainDBHelper>();
            mockDialogHelper = new Mock<IDialogHelper>();
            mockDBHelper.Setup(dbHelper => dbHelper.GetBillID()).Returns("50000");
            mockDialogHelper.Invocations.Clear();
            mockDBHelper.Invocations.Clear();
            mockView.Invocations.Clear();
            presenter = new MainPresenter(mockView.Object,mockDBHelper.Object,mockDialogHelper.Object);
        }

        [Test]
        public void InitialLaunchAsAdmin()
        {
            presenter.Initialize("admin", true);
            mockView.Verify(view => view.SetFocusToName(),"Focus not set to Name during Initial Launch of MainForm.");
            mockView.Verify(view => view.SetSessionUserName(It.IsAny<string>()), "Name not set during Initial Launch of MainForm.");
            mockView.Verify(view => view.SetDate(It.IsAny<string>()), "Date not set during Initial Launch of MainForm.");
            mockDBHelper.Verify(dbHelper => dbHelper.InitializeNewBillEntry(It.Is<string>(x=>x=="admin"), It.IsAny<bool>()),"Initial DB Call not made during Launch of MainForm.");
            mockView.Verify(view => view.ShowAdminOptions(),"Admin options may not be shown for admin user.");
            mockDBHelper.Verify(dbHelper => dbHelper.GetBillID());
            mockView.Verify(view => view.UpdateInvoiceID(It.IsAny<string>()),"Invoice ID not updated during Initial Launch of MainForm.");
            mockView.Verify(view => view.GreyoutDiscount(),"Discount not greyed out during the initial launch  of MainForm.");
        }

        [Test]
        public void InitialLaunchAsUser()
        {
            presenter.Initialize("username", false);
            mockView.Verify(view => view.SetFocusToName(),"Focus not set to Name during Initial Launch of MainForm.");
            mockView.Verify(view => view.SetSessionUserName(It.IsAny<string>()), "Name not set during Initial Launch of MainForm.");
            mockView.Verify(view => view.SetDate(It.IsAny<string>()), "Date not set during Initial Launch of MainForm.");
            mockDBHelper.Verify(dbHelper => dbHelper.InitializeNewBillEntry(It.Is<string>(x => x == "username"), It.IsAny<bool>()), "Initial DB Call not made during Launch of MainForm.");
            mockView.Verify(view => view.HideAdminOptions(), "Admin options are shown for non-admin user.");
            mockDBHelper.Verify(dbHelper => dbHelper.GetBillID());
            mockView.Verify(view => view.UpdateInvoiceID(It.IsAny<string>()), "Invoice ID not updated during Initial Launch of MainForm.");
            mockView.Verify(view => view.GreyoutDiscount(), "Discount not greyed out during the initial launch  of MainForm.");
        }

        [Test]
        public void UpdateCustomerNameSucceeded()
        {
            mockDBHelper.Setup(dbHelper => dbHelper.UpdateCustomerName(It.IsAny<string>())).Returns(true);
            presenter.UpdateCustomerName("Suresh");
            mockView.Verify(view => view.UpdateCustomerName(It.IsAny<string>()),Times.Never,"Update Customer Name failed internally.");
        }

        [Test]
        public void UpdateCustomerNameFailed()
        {
            mockDBHelper.Setup(dbHelper => dbHelper.UpdateCustomerName(It.IsAny<string>())).Returns(false);
            presenter.UpdateCustomerName("Suresh");
            mockView.Verify(view => view.UpdateCustomerName(It.IsAny<string>()), Times.Once,"Update Customer Name succeeded internally");
        }

        [Test]
        public void ShowUpdateForm()
        {
            presenter.ShowUpdateForm();
            mockView.Verify(view => view.ShowUpdateForm(), "Update Form not shown when the button is clicked.");
        }
        [Test]
        public void ShowUpdateDBForm()
        {
            presenter.ShowUpdateDBForm();
            mockView.Verify(view => view.ShowUpdateDBForm(), "Update DB Form not shown when the button is clicked");
        }

        [Test]
        public void ShowProductForm()
        {
            presenter.ShowProductForm();
            mockView.Verify(view => view.ShowProductForm(), "Product Form not shown when the button is clicked");
        }

        [Test]
        public void ShowUserForm()
        {
            presenter.ShowUserForm();
            mockView.Verify(view => view.ShowUserForm(), "User Form not shown when the button is clicked");
        }

        [Test]
        public void AddProductEmptyName()
        {
            presenter.AddProduct(string.Empty);
            mockDialogHelper.Verify(dialogHelper => dialogHelper.ShowWarning(It.IsAny<string>(),It.IsAny<string>()),"Warning not shown when empty product name typed.");
        }

        [Test]
        public void AddProductNull()
        {
            presenter.AddProduct(null);
            mockDialogHelper.Verify(dialogHelper => dialogHelper.ShowWarning(It.IsAny<string>(), It.IsAny<string>()), "Warning not shown when product name is null.");
        }

        [Test]
        public void AddProductSucceeded()
        {
            presenter.AddProduct("PassPort");
            double amount = 0;
            mockDBHelper.Verify(db => db.AddProduct(It.Is<string>(x => x == "PassPort"),out amount));
            mockView.Verify(view => view.UpdateTotalAmount(It.IsAny<string>()), "View values are not updated on successful product addition.");
            mockView.Verify(view => view.UpdateDiscount(It.IsAny<string>()),"View values are not updated on successful product addition.");
        }

        [Test]
        public void CancelCurrentEntryConfirmed()
        {
            mockDialogHelper.Setup(x => x.AskUser(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            presenter.Initialize("admin", true);
            ClearInvocations();
            presenter.CancelCurrentEntry();
            mockDBHelper.Verify(db => db.InitializeNewBillEntry(It.Is<string>(x => x == "admin"), It.Is<bool> (x => x == true)),"DB not initialized with new entry after cancel succeeded.");
            mockView.Verify(view => view.UpdateInvoiceID(It.IsAny<string>()),"Invoice ID not updated after cancel succeeded.");
            mockView.Verify(view => view.InitializeNewEntry(),"View not updated for Initialize New Entry");
        }

        [Test]
        public void CancelCurrentEntryNotConfirmed()
        {
            mockDialogHelper.Setup(x => x.AskUser(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            presenter.Initialize("admin", true);
            ClearInvocations();
            presenter.CancelCurrentEntry();
            mockDBHelper.Verify(db => db.InitializeNewBillEntry(It.Is<string>(x => x == "admin"), It.Is<bool>(x => x == true)), Times.Never, "DB initialized with new entry after cancel failed.");
            mockView.Verify(view => view.UpdateInvoiceID(It.IsAny<string>()), Times.Never, "Invoice ID updated after cancel failed.");
            mockView.Verify(view => view.InitializeNewEntry(), Times.Never, "View updated for Initialize New Entry after cancel failed.");

        }

        [Test]
        public void UpdateDeliverStatusTrue()
        {
            presenter.UpdateDeliverStatus(true);
            mockDBHelper.Verify(db => db.UpdateDeliverStatus(It.Is<bool>(x => x == true)),"DB update call made was wrong.");
        }

        [Test]
        public void UpdateDeliverStatusFalse()
        {
            presenter.UpdateDeliverStatus(false);
            mockDBHelper.Verify(db => db.UpdateDeliverStatus(It.Is<bool>(x => x == false)), "DB update call made was wrong.");
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void UpdateBillType(int billType)
        {
            presenter.UpdateBillType(billType);
            mockDBHelper.Verify(db => db.UpdateBillType(It.Is<int>(x=>x==billType)), "DB update call made was wrong.");
        }


        [Test]
        public void UpdateDiscountSucceeded()
        {
            double balance = 0;
            mockDBHelper.Setup(db => db.UpdateDiscount(It.IsAny<double>(), out balance)).Returns(true);
            presenter.UpdateDiscount(25.0);
            mockView.Verify(view => view.UpdateBalance(It.IsAny<string>()), "On Success, Balance was not updated on the view");
        }

        [Test]
        public void UpdateDiscountFailed()
        {
            double balance = 0;
            mockDBHelper.Setup(db => db.UpdateDiscount(It.IsAny<double>(), out balance)).Returns(false);
            presenter.UpdateDiscount(25.0);
            mockView.Verify(view => view.UpdateDiscount(It.Is<string>(x => x == "")),"On Failure, Discount should be cleared from the view.");
            mockDialogHelper.Verify(dialog => dialog.ShowError(It.IsAny<string>(), It.IsAny<string>()),"Error Dialog is not shown, on failure."); 
        }

        [Test]
        public void UpdateAdvanceSucceeded()
        {
            double balance = 0;
            mockDBHelper.Setup(db => db.UpdateAdvance(It.IsAny<double>(), out balance)).Returns(true);
            presenter.UpdateAdvance(25.0);
            mockView.Verify(view => view.UpdateBalance(It.IsAny<string>()), "On Success, Balance was not updated on the view");
        }

        [Test]
        public void UpdateAdvanceFailed()
        {
            double balance = 0;
            mockDBHelper.Setup(db => db.UpdateAdvance(It.IsAny<double>(), out balance)).Returns(false);
            presenter.UpdateAdvance(25.0);
            mockView.Verify(view => view.UpdateAdvance(It.Is<string>(x => x == "")), "On Failure, Advance should be cleared from the view.");
            mockDialogHelper.Verify(dialog => dialog.ShowError(It.IsAny<string>(), It.IsAny<string>()), "Error Dialog is not shown, on failure.");
        }

        [Test]
        public void GetProductList()
        {
            mockDBHelper.Setup(db => db.GetProducts("Ph")).Returns(new System.Collections.Generic.List<string>() { "Photo", "PhonePhoto" });
            List<string> products=presenter.GetProductList("Ph");
            Assert.AreEqual(2, products.Count, "Products not retained properly");
        }

        [Test]
        public void UpdatePhoneNumberSucceeded()
        {
            mockDBHelper.Setup(db => db.UpdatePhoneNumber(It.IsAny<string>())).Returns(true);
            mockDBHelper.Setup(db => db.GetPhoneNumber()).Returns("9994458698");
            presenter.UpdatePhoneNumber("9994458698");
            mockView.Verify(view => view.UpdatePhoneNumber(It.IsAny<string>()),Times.Never,"On Success, view should not be updated after success.");  
        }

        [Test]
        public void UpdatePhoneNumberFailed()
        {
            mockDBHelper.Setup(db => db.UpdatePhoneNumber(It.IsAny<string>())).Returns(false);
            mockDBHelper.Setup(db => db.GetPhoneNumber()).Returns("9994458698");
            presenter.UpdatePhoneNumber("9994458698");
            mockDBHelper.Verify(db => db.GetPhoneNumber(),"On Failure, DB call not made for view update.");
            mockView.Verify(view => view.UpdatePhoneNumber(It.IsAny<string>()), Times.Once, "On Failure, view should not be updated after success.");
        }

        [Test]
        public void UpdateQuantityEmptyName()
        {
            presenter.UpdateQuantity(string.Empty,25);
            mockDialogHelper.Verify(dialogHelper => dialogHelper.ShowError(It.IsAny<string>(), It.IsAny<string>()), "Warning not shown when empty product name typed.");
        }

        [Test]
        public void UpdateQuantityNull()
        {
            presenter.UpdateQuantity(null,25);
            mockDialogHelper.Verify(dialogHelper => dialogHelper.ShowError(It.IsAny<string>(), It.IsAny<string>()), "Warning not shown when product name is null.");
        }

        [Test]
        public void UpdateQuantitySucceeded()
        {
            presenter.UpdateQuantity("PassPort",10);
            double amount = 0;
            mockDBHelper.Verify(db => db.UpdateQuantity(It.Is<string>(x => x == "PassPort"),It.Is<double>(x=>x==10) ,out amount),"DB Helper call not made on success.");
            mockView.Verify(view => view.UpdateTotalAmount(It.IsAny<string>()), "View values are not updated on successful product addition.");
            mockView.Verify(view => view.UpdateDiscount(It.IsAny<string>()), "View values are not updated on successful product addition.");
        }

        [Test]
        public void CreateNewBillEntryAlreadySaved()
        {
            mockDBHelper.Setup(db => db.InitializeNewBillEntry(It.IsAny<string>(), It.IsAny<bool>())).Returns(true);
            presenter.CreateNewBillEntry();
            mockView.Verify(view => view.UpdateInvoiceID(It.IsAny<string>()),"On Success, Invoice ID not updated in view.");
            mockView.Verify(view => view.InitializeNewEntry(), "On Success, New Entry not initialized in view");
        }


        [Test]
        public void CreateNewBillEntrySaveNeededUserConfirmNo()
        {
            mockDBHelper.Setup(db => db.InitializeNewBillEntry(It.IsAny<string>(), It.IsAny<bool>())).Returns(false);
            mockDialogHelper.Setup(dialog => dialog.AskUser(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            presenter.CreateNewBillEntry();
            mockDBHelper.Verify(db => db.InitializeNewBillEntry(It.IsAny<string>(), It.Is<bool>(x => x == true)),"When save needed and user responded no, force Initialize is not done internally.");
            mockView.Verify(view => view.UpdateInvoiceID(It.IsAny<string>()), "When save needed and user responded no,, Invoice ID not updated in view.");
            mockView.Verify(view => view.InitializeNewEntry(), "When save needed and user responded no,, New Entry not initialized in view");
        }

        [Test]
        public void CreateNewBillEntrySaveNeededUserConfirmYes()
        {
            mockDBHelper.Setup(db => db.InitializeNewBillEntry(It.IsAny<string>(), It.IsAny<bool>())).Returns(false);
            mockDialogHelper.Setup(dialog => dialog.AskUser(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            presenter.CreateNewBillEntry();
            mockDBHelper.Verify(db => db.SaveEntryToDatabase(), "When save needed and user responded yes, save call is not done internally.");
       }


        private void ClearInvocations()
        {
            mockDialogHelper.Invocations.Clear();
            mockDBHelper.Invocations.Clear();
            mockView.Invocations.Clear();
        }

        [TearDown]
        public void ClearInternalState()
        {
            mockDialogHelper.Invocations.Clear();
        }


    }
}
