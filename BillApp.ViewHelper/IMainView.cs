namespace BillApp.ViewHelper
{
    public interface IMainView
    {
        void UpdateCustomerName(string currentName);
        void UpdatePhoneNumber(string currentPhoneNumber);
        void SetFocusToName();
        void SetSessionUserName(string userName);
        void SetDate(string v);
        void UpdateInvoiceID(string v);
        void ShowAdminOptions();
        void HideAdminOptions();
        void GreyoutDiscount();
        void UpdateBalance(string v);
        void UpdateDiscount(string v);
        void UpdateAdvance(string v);
        void SetDiscountAsAvailable();
        void ShowUserForm();
        void InitializeNewEntry();
        void ShowProductForm();
        void ShowUpdateDBForm();
        void UpdateAmount(double amount);
        void UpdateTotalAmount(string v);
        void UpdateRate(double amount);
        void UpdateQuantity(int v);
        void ShowUpdateForm();
    }
}
