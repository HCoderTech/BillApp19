using System;
using System.Collections.Generic;
using BillApp.DBHelper.MainForm;
using BillApp.ViewHelper;
using BillApp.DBHelper.Data;
using System.IO;

namespace BillApp.Presenter
{
    public interface IMainPresenter
    {
        void Initialize(string userName, bool isAdmin);
        void UpdateCustomerName(string customerName);
        void UpdatePhoneNumber(string phoneNumber);
        void UpdateDiscount(double discount);
        void UpdateAdvance(double advance);
        void CreateNewBillEntry();
        void ShowUserForm();
        void ShowProductForm();
        void ShowUpdateDBForm();
        void CancelCurrentEntry();
        List<string> GetProductList(string productPattern);
        void UpdateBillType(int v);
        void UpdateDeliverStatus(bool status);
        void AddProduct(string productName);
        void UpdateQuantity(string productName, double value);
        void SaveCurrentEntry();
        void ShowUpdateForm();
    }
    public class MainPresenter : IMainPresenter
    {
        readonly IMainDBHelper dbHelper;
        readonly IMainView view;
        readonly IDialogHelper dialogHelper;
        string currentSessionUser;
        public MainPresenter(IMainView viewArg,IMainDBHelper mainDBHelper,IDialogHelper dialogHelper)
        {
            view = viewArg;
            dbHelper = mainDBHelper;
            this.dialogHelper = dialogHelper;
        }

        public void Initialize(string userName,bool isAdmin)
        {
            view.SetFocusToName();
            view.SetSessionUserName(userName);
            currentSessionUser = userName;
            view.SetDate(string.Concat("Date :", " ", string.Format(DateTime.Now.ToString(), "dd/MM/yyyy")));
            dbHelper.InitializeNewBillEntry(userName,true);
            string number = dbHelper.GetBillID();
            view.UpdateInvoiceID(string.Concat("Invoice : ", string.Format(number, "0000")));
            if (isAdmin)
            {
                view.ShowAdminOptions();
            }else
            {
                view.HideAdminOptions();
            }
            view.GreyoutDiscount();
        }

        public void UpdateCustomerName(string customerName)
        {
            bool isUpdateSuccess=dbHelper.UpdateCustomerName(customerName);
            if (!isUpdateSuccess)
            {
                string currentName = dbHelper.GetCustomerName();
                view.UpdateCustomerName(currentName);
            }
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            bool isUpdateSuccess = dbHelper.UpdatePhoneNumber(phoneNumber);
            if (!isUpdateSuccess)
            {
                string currentPhoneNumber = dbHelper.GetPhoneNumber();
                view.UpdatePhoneNumber(currentPhoneNumber);
            }
        }

        public void UpdateDiscount(double discount)
        {
            double balance = 0;
            bool isUpdateSuccess = dbHelper.UpdateDiscount(discount,out balance);
            if (isUpdateSuccess)
            {
                view.UpdateBalance(balance.ToString());
            }
            else
            {
                view.UpdateDiscount("");
                dialogHelper.ShowError("Pay exceeds total amount", "Data Entry Error!!!");
            }
        }

        public void UpdateAdvance(double advance)
        {
            double balance = 0;
            bool isUpdateSuccess = dbHelper.UpdateAdvance(advance,out balance);
            if (isUpdateSuccess)
            {
                view.UpdateBalance(balance.ToString());
                view.SetDiscountAsAvailable();
            }
            else
            {
                view.UpdateAdvance("");
                dialogHelper.ShowError("Pay exceeds total amount", "Data Entry Error!!!");
            }
        }

        public void ShowUserForm()
        {
            view.ShowUserForm();
        }

        public void CreateNewBillEntry()
        {
            bool isNewEntryCreated=dbHelper.InitializeNewBillEntry(currentSessionUser,false);
            if (isNewEntryCreated)
            {
                view.UpdateInvoiceID(dbHelper.GetBillID());
                view.InitializeNewEntry();
            }else
            {
                bool save=dialogHelper.AskUser("Do you want to save current Entry?", "Save Details");
                if(save)
                    SaveCurrentEntry();
                else
                {
                    dbHelper.InitializeNewBillEntry(currentSessionUser, true);
                    view.UpdateInvoiceID(dbHelper.GetBillID());
                    view.InitializeNewEntry();
                }
            }
           
        }

        public void SaveCurrentEntry()
        {
            if (dbHelper.GetCustomerName() == "" || dbHelper.GetPhoneNumber() == "" || dbHelper.GetTotalAmount() == "0")
            {
                dialogHelper.ShowWarning("Customer Name or Phone Number or Product details missing", "Required!!!");
            } else if (dbHelper.GetBillType() == BillType.Undefined)
            {
                dialogHelper.ShowWarning("Select Bill Type", "Alert!!!");
            }else
            {
                bool isSaved=dbHelper.SaveEntryToDatabase();

                if (isSaved)
                {
                    dialogHelper.ShowInfo("Details Saved", "Success");
                }
                else
                {
                    dialogHelper.ShowInfo("Already Saved", "Info");
                }
            }
        }

        public void ShowProductForm()
        {
            view.ShowProductForm();
        }

        public void ShowUpdateDBForm()
        {
            view.ShowUpdateDBForm();
        }

        public void CancelCurrentEntry()
        {
            bool cancel = dialogHelper.AskUser("Do you want to clear Current Entry?", "Confirm");
            if (cancel)
            {
                dbHelper.InitializeNewBillEntry(currentSessionUser, true);
                view.UpdateInvoiceID(dbHelper.GetBillID());
                view.InitializeNewEntry();
            }
        }

        public List<string> GetProductList(string productPattern)
        {
            List<string> productList = dbHelper.GetProducts(productPattern);
            return productList;
        }


        public void UpdateBillType(int billType)
        {
            dbHelper.UpdateBillType(billType);
        }

        public void UpdateDeliverStatus(bool status)
        {
            dbHelper.UpdateDeliverStatus(status);
        }

        public void AddProduct(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                dialogHelper.ShowWarning("Select any one of the Suggested Product", "Caution!!!");
            }else
            {
                double amount = 0;
                dbHelper.AddProduct(productName,out amount);
                view.UpdateQuantity(1);
                view.UpdateRate(amount);
                view.UpdateAmount(amount);
                UpdateValues();
            }
        }

        public void UpdateQuantity(string productName, double value)
        {
            double amount = 0;
            if (string.IsNullOrEmpty(productName))
            {
                dialogHelper.ShowError("Internal Error Occurred", "Message");
            }else
            {
                dbHelper.UpdateQuantity(productName, value, out amount);
                view.UpdateAmount(amount);
                UpdateValues();  
            }
        }

        private void UpdateValues()
        {
            view.UpdateTotalAmount(dbHelper.GetTotalAmount());
            view.UpdateBalance(dbHelper.GetBalance());
            view.UpdateAdvance(dbHelper.GetAdvance());
            view.UpdateDiscount(dbHelper.GetDiscount());
        }

        public void ShowUpdateForm()
        {
            view.ShowUpdateForm();
        }
    }
}
