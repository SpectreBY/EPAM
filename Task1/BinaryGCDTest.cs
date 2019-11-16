using System;
using EuclideanLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1
{
    [TestClass]
    public class BinaryGCDTest
    {
        [TestMethod]
        public void FindDeviderTest()
        {
            int result = BinaryGCD.FindDevider(10, 8);
            Assert.AreEqual(2, result);
        }
    }
}
