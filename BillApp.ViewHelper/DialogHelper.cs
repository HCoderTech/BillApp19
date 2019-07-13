using System;
using System.Windows.Forms;

namespace BillApp.ViewHelper
{
    public interface IDialogHelper
    {
        void ShowWarning(string msg, string caption);
        void ShowError(string msg, string caption);
        void ShowInfo(string msg, string caption);
        bool AskUser(string msg, string caption);
    }
    public class DialogHelper : IDialogHelper
    {
        public void ShowError(string msg, string caption)
        {
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowInfo(string msg, string caption)
        {
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowWarning(string msg, string caption)
        {
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public bool AskUser(string msg, string caption)
        {
            DialogResult result=MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes ? true : false;
        }
    }
}
