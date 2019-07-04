namespace BillApp.ViewHelper
{
    public interface ILoginView
    {
        void ClearError();
        void SetError(string msg);
        void ClearFields();
        void ShowMainForm();
        void CloseView();
    }
}
