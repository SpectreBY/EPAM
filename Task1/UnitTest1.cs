using System;
using EuclideanLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int res = Euclidean.Solve(8, 4);
            Assert.AreEqual(4, res);
        }
    }
}
