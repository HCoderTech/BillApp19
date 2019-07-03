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
            Subtract sub = new Subtract();
            Assert.AreEqual(4, sub.Subtract(8, 4));
        }
    }
}
