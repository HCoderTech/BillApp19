using BillApp.DBHelper.MainForm;
using BillApp.Presenter;
using BillApp.ViewHelper;
using Moq;
using NUnit.Framework;

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
