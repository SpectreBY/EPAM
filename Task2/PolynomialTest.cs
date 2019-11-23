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
        #region коэффициенты и степени полинома для сложения и вычитания
        double[,] poly1AddSub = new double[,]
        {
            { 8, 3 },
            { 3, 2 },
            { 5, 1 },
            { 17, 0 },
        };
        double[,] poly2AddSub = new double[,]
        {
            { 2, 4 },
            { 3, 3 },
            { 4, 2 },
            { 1, 1 },
            { -7, 0 }
        };
        double[,] poly3AddAssert= new double[,]
        {
            { 10, 4 },
            { 6, 3 },
            { 9, 2 },
            { 18, 1 },
            { -7, 0 }
        };
        double[,] poly4SubAssert = new double[,]
        {
            { 6, 4 },
            { 0, 3 },
            { 1, 2 },
            { 16, 1 },
            { -7, 0 }
        };
        #endregion

        #region коэффициенты и степени полинома для умножения
        double[,] poly1multiplie = new double[,]
        {
            { 2, 2 },
            { 2, 1 },
            { 2, 0 }
        };
        double[,] poly2multiplie = new double[,]
        {
            { 2, 1 },
            { 2, 0 }
        };
        double[,] polyMultiplieAssert = new double[,]
        {
            { 4, 3 },
            { 4, 2 },
            { 4, 2 },
            { 4, 1 },
            { 4, 1 },
            { 4, 0 }
        };
        #endregion

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
            Polynomial p1 = new Polynomial(poly1AddSub);
            Polynomial p2 = new Polynomial(poly2AddSub);
            Polynomial assert = new Polynomial(poly3AddAssert);
            Polynomial p3 = p1 + p2;
            TestContext.WriteLine(p3.ToString());
            Assert.IsTrue(p3.Equals(assert));
        }

        [TestMethod]
        public void SubtractionTest()
        {
            Polynomial p1 = new Polynomial(poly1AddSub);
            Polynomial p2 = new Polynomial(poly2AddSub);
            Polynomial assert = new Polynomial(poly4SubAssert);
            Polynomial p3 = p1 - p2;
            TestContext.WriteLine(p3.ToString());
            Assert.IsTrue(p3.Equals(assert));
        }

        [TestMethod]
        public void MultiplieTest()
        {
            Polynomial p1 = new Polynomial(poly1multiplie);
            Polynomial p2 = new Polynomial(poly2multiplie);
            Polynomial assert = new Polynomial(polyMultiplieAssert);
            Polynomial p3 = p1 * p2;
            TestContext.WriteLine(p3.ToString());
            Assert.IsTrue(p3.Equals(assert));
        }
    }
}
