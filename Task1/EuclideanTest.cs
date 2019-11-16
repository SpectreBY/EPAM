using System;
using EuclideanLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1
{
    [TestClass]
    public class EuclideanTest
    {
        [TestMethod]
        public void FindDeviderForTwoDigitsTest()
        {
            int result = Euclidean.FindDevider(64, 48);
            Assert.AreEqual(16, result);
        }
        [TestMethod]
        public void FindDeviderForThreeDigitsTest()
        {
            int result = Euclidean.FindDevider(18, 12, 6);
            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void FindDeviderForFourDigitsTest()
        {
            int result = Euclidean.FindDevider(18, 12, 9, 60);
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void FindDeviderForFiveDigitsTest()
        {
            int result = Euclidean.FindDevider(75, 15, 10, 100, 35);
            Assert.AreEqual(5, result);
        }
    }
}
