using System;
using EuclideanLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FindDeviderForTwoDigitsTest()
        {
            int result = Euclidean.FindDeviderForTwoDigits(64, 48);
            Assert.AreEqual(16, result);
        }
        [TestMethod]
        public void FindDeviderForFewDigitsTest()
        {
            int[] testCase = new int[4] { 18, 12, 6, 24 };
            int result = Euclidean.FindDeviderForFewDigits(testCase);
            Assert.AreEqual(6, result);
        }
    }
}
