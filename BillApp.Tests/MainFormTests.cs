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

    }
}
