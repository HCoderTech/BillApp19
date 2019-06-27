using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillApp.BusinessLogic;
using MRStudio_new;

namespace BillApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Adder adder = new Adder();
            Assert.AreEqual(4, adder.Add(2,2));
        }

        public void Test2()
        {
            Subtract sub = new Subtract();
            Assert.AreEqual(4, sub.Subtract(8, 4));
        }
    }
}
