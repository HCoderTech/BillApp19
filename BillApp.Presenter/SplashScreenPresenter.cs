using BillApp.ViewHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.Presenter
{
    public interface ISplashScreenPresenter
    {
        int GetCurrentProgress();
        void IncrementLoadProgress();
    }

    public class SplashScreenPresenter : ISplashScreenPresenter
    {
        ISplashScreenView view;
        private int _loadProgress;
       
        public SplashScreenPresenter(ISplashScreenView viewArg)
        {
            view = viewArg;
            _loadProgress = 0;
        }

        public int GetCurrentProgress()
        {
           return _loadProgress;
        }

        public void IncrementLoadProgress()
        {
            _loadProgress++;
            view.IncrementProgressBar(1);
            if (_loadProgress == 100)
            {
                view.ShowLoginForm();
                view.CloseView();
            }
       
        }
    }
}
