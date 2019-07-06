using BillApp.DBHelper;
using BillApp.ViewHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.Presenter
{
    public interface ILoginPresenter
    {
        void LoginAsAdmin(string username, string password);
        void LoginAsUser(string username, string password);
        void CancelLogin();
    }
    public class LoginPresenter : ILoginPresenter
    {
        readonly ILoginDBHelper dbHelper;
        readonly ILoginView view;
        public LoginPresenter(ILoginView viewArg,ILoginDBHelper dbHelperArg)
        {
            view = viewArg;
            dbHelper = dbHelperArg;
        }

        public void LoginAsAdmin(string username, string password)
        {
            Login(dbHelper.IsAdminExist(username, password));
        }

        private void Login(bool isExist)
        {
            if (isExist)
            {
                //Open MainForm
                view.ShowMainForm();
                view.CloseView();
            }else
            {
                //show error
                view.SetError("Username/Password does not match");
                view.ClearFields();
            }
        }

        public void LoginAsUser(string username, string password)
        {
            Login(dbHelper.IsUserExist(username, password));
        }

        public void CancelLogin()
        {
            view.ClearFields();
            view.ClearError();
        }
    }
}
