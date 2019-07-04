using System;
using BillApp.BusinessLogic;
using MRStudio_new;
using NUnit.Framework;
using BillApp.Presenter;
using BillApp.ViewHelper;
using Moq;
using System.IO;

namespace BillApp.SplashScreenTests
{
    [TestFixture]
    public class SplashScreenTests
    {
        SplashScreenPresenter presenter;
        Mock<ISplashScreenView> mockView;
        
        [SetUp]
        public void TestInitialize()
        {
            mockView = new Mock<ISplashScreenView>();
            presenter = new SplashScreenPresenter(mockView.Object);
        }
       [Test]
        public void IncrementLoadProgressTest()
        {
            presenter.IncrementLoadProgress();
            int expectedLoadProgress = 1;
            int actualLoadProgress = presenter.GetCurrentProgress();
            Assert.AreEqual(expectedLoadProgress, actualLoadProgress, "Expected and Actual Load progress are not the same.");
            mockView.Verify(view => view.IncrementProgressBar(It.IsAny<int>()),"View Progressbar didnot get incremented by 1");
        }
        [Test]
        public void IncrementLoadProgress_ShowOpenLoginFormAtMax()
        {
            IncrementBeforeMax();
            presenter.IncrementLoadProgress();
            mockView.Verify(view => view.ShowLoginForm(), "At Max Load condition, Login Form was not shown to the user.");
            mockView.Verify(view => view.CloseView(), "At Max Load condition, Splash Screen Form was not closed.");
        }

        private void IncrementBeforeMax()
        {
            for(int i=0;i<99;i++)
            presenter.IncrementLoadProgress();
        }
        [Test]
        public void IsEnvironmentInitializedFirstTimeLaunch()
        {
            PathInitialize();
            presenter.InitializeEnvironment();
            Assert.IsTrue(Directory.Exists("MRStudio\\"));
            Assert.IsTrue(File.Exists("MRStudio\\count.txt"));
            Assert.IsTrue(File.Exists("MRStudio\\MyData.db"));
        }

        private void PathInitialize()
        {
            if (Directory.Exists("MRStudio\\"))
            {
                if (File.Exists("MRStudio\\count.txt"))
                {
                    File.Delete("MRStudio\\count.txt");
                }
                if (File.Exists("MRStudio\\MyData.db"))
                {
                    File.Delete("MRStudio\\MyData.db");
                }

                Directory.Delete("MRStudio\\");
            }

        }

        [Test]
        public void InitializeWhenOnlyPathExists()
        {
            PathInitialize();
            PathCreate();
            presenter.InitializeEnvironment();
            Assert.IsTrue(File.Exists("MRStudio\\count.txt"));
        }

        [Test]
        public void InitializeWhenAlreadyInitialized()
        {
            PathInitialize();
            PathCreate();
            FileCreate();
            DateTime beforeWriteTime=File.GetLastWriteTime("MRStudio\\count.txt");
            presenter.InitializeEnvironment();
            DateTime afterWriteTime = File.GetLastWriteTime("MRStudio\\count.txt");
            Assert.AreEqual(beforeWriteTime, beforeWriteTime);
        }

        private void PathCreate()
        {
            Directory.CreateDirectory("MRStudio\\");
        }

        private void FileCreate()
        {
            File.Create("MRStudio\\count.txt").Close();
        }

    }
}
