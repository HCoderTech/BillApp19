using BillApp.ViewHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.Presenter
{
    public interface ISplashScreenPresenter
    {
        int GetCurrentProgress();
        void InitializeEnvironment();
        void IncrementLoadProgress();
    }

    public class SplashScreenPresenter : ISplashScreenPresenter
    {
        readonly ISplashScreenView view;
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

        public void InitializeEnvironment()
        {
            string path1="MRStudio\\";
            if (!Directory.Exists(path1))
                Directory.CreateDirectory(path1);
            string path2 = "MRStudio\\count.txt";

            if (!File.Exists(path2))
            {
                using(StreamWriter sw= File.CreateText(path2))
                {
                    sw.Write("50000");
                }
            }
        }
    }
}
