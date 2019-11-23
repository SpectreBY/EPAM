using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2Lib;

namespace Task2
{
    [TestClass]
    public class PolynomialTest
    {
        #region TestContext
        /// <summary>
        /// Контекст для вывода информации в обозревателе тестов
        /// </summary>
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #endregion

        [TestMethod]
        public void AdditionTest()
        {
            Polynomial p1 = new Polynomial(new double[] { 2, 3, 4, 17 });
            Polynomial p2 = new Polynomial(new double[] { 2, 3, 4, 1, -7 });
            Polynomial assert = new Polynomial(new double[] { 4, 6, 8, 18, -7 });
            Polynomial p3 = p1 + p2;
            TestContext.WriteLine(p3.ToString());
            Assert.IsTrue(p3.Equals(assert));
        }

        [TestMethod]
        public void SubtractionTest()
        {
            Polynomial p1 = new Polynomial(new double[] { 3, 3, 4, 17, 4 });
            Polynomial p2 = new Polynomial(new double[] { 2, 1, 7, 1 });
            Polynomial assert = new Polynomial(new double[] { 1, 2, -3, 16, 4 });
            Polynomial p3 = p1 - p2;
            TestContext.WriteLine(p3.ToString());
            Assert.IsTrue(p3.Equals(assert));
        }
    }
}
