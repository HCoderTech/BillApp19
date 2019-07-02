using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillApp.BusinessLogic;
using MRStudio_new;
using NUnit.Framework;

namespace BillApp.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            Adder adder = new Adder();
            Assert.AreEqual(4, adder.Add(2,2));
        }
        [Test]
        public void Test2()
        {
            Subtract sub = new Subtract();
            Assert.AreEqual(4, sub.Subtract(8, 4));
        }
    }
}
