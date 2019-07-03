using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.ViewHelper
{
    public interface ISplashScreenView
    {

        void IncrementProgressBar(int value);
        void CloseView();
        void ShowLoginForm();
    }
}
