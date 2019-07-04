using BillApp.DBHelper;
using BillApp.Presenter;
using BillApp.ViewHelper;
using Moq;
using NUnit.Framework;

namespace BillApp.Tests
{
    [TestFixture]
    public class LoginTests
    {
        LoginPresenter presenter;
        Mock<ILoginView> mockView;
        Mock<ILoginDBHelper> mockDBHelper;

        [SetUp]
        public void TestInitialize()
        {
            mockView = new Mock<ILoginView>();
            mockDBHelper = new Mock<ILoginDBHelper>();
            presenter = new LoginPresenter(mockView.Object,mockDBHelper.Object);
        }
        [Test]
        public void LoginSucceededAsAdmin()
        {
            mockDBHelper.Setup(x => x.IsAdminExist(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            presenter.LoginAsAdmin("admin","admin");
            mockView.Verify(view => view.ShowMainForm(), "Main Form didn't show up on successful login as admin");
            mockView.Verify(view => view.CloseView(), "Login Form didn't close on successful login as admin");
        }

        [Test]
        public void LoginFailedAsAdmin()
        {
            mockDBHelper.Setup(x => x.IsAdminExist(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            presenter.LoginAsAdmin("admin", "admin");
            mockView.Verify(view => view.SetError(It.IsAny<string>()), "Error not shown on the Login Form on failure");
            mockView.Verify(view => view.ClearFields(), "Fields not cleared on LoginForm on failure.");
        }

        [Test]
        public void LoginSucceededAsUser()
        {
            mockDBHelper.Setup(x => x.IsUserExist(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            presenter.LoginAsUser("UserName", "Password");
            mockView.Verify(view => view.ShowMainForm(), "Main Form didn't show up on successful login as user");
            mockView.Verify(view => view.CloseView(), "Login Form didn't close on successful login as user");
        }

        [Test]
        public void LoginFailedAsUser()
        {
            mockDBHelper.Setup(x => x.IsUserExist(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            presenter.LoginAsUser("UserName", "Password");
            mockView.Verify(view => view.SetError(It.IsAny<string>()), "Error not shown on the Login Form on failure");
            mockView.Verify(view => view.ClearFields(), "Fields not cleared on LoginForm on failure.");
        }

        [Test]
        public void CancelLogin()
        {
            presenter.CancelLogin();
            mockView.Verify(view => view.ClearError(), "Error not clear on Cancel Login.");
            mockView.Verify(view => view.ClearFields(), "Fields not cleared on LoginForm on Cancel Login.");
        }
    }
}
