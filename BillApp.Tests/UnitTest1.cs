using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillApp.BusinessLogic;

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
    }
}
