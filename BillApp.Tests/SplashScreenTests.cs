using System;
using BillApp.BusinessLogic;
using MRStudio_new;
using NUnit.Framework;
using BillApp.Presenter;
using BillApp.ViewHelper;
using Moq;

namespace BillApp.SplashScreenTests
{
    [TestFixture]
    public class SplashScreenTests
    {
        SplashScreenPresenter presenter;
        Mock<ISplashScreenView> mockView;
        ISplashScreenView view;
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
    }
}
