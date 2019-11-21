using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorLib;

namespace Task2
{
    [TestClass]
    public class VectorTest
    {
        /// <summary>
        /// Тестируемые вектора
        /// </summary>
        private Vector vector1 = new Vector(10, 20, 4);
        private Vector vector2 = new Vector(5, -10, 16);

        /// <summary>
        /// Тест на сложение векторов
        /// </summary>
        [TestMethod]
        public void AdditionTest()
        {
            Vector expect = new Vector(15, 10, 20);
            Vector result = vector1 + vector2;
            Assert.IsTrue(expect.X == result.X &&
                          expect.Y == result.Y &&
                          expect.Z == result.Z);
        }

        /// <summary>
        /// Тест на вычитание векторов
        /// </summary>
        [TestMethod]
        public void SubtractionTest()
        {
            Vector expect = new Vector(5, 30, -12);
            Vector result = vector1 - vector2;
            Assert.IsTrue(expect.X == result.X &&
                          expect.Y == result.Y &&
                          expect.Z == result.Z);
        }

        /// <summary>
        /// Тест на умножение векторов
        /// </summary>
        [TestMethod]
        public void MultiplicationTest()
        {
            Vector expect = new Vector(50, -200, 64);
            Vector result = vector1 * vector2;
            Assert.IsTrue(expect.X == result.X &&
                          expect.Y == result.Y &&
                          expect.Z == result.Z);
        }

        /// <summary>
        /// Тест на умножение вектора на число
        /// </summary>
        [TestMethod]
        public void MultiplicationNumberTest()
        {
            Vector expect = new Vector(20, 40, 8);
            Vector result = vector1 * 2;
            Assert.IsTrue(expect.X == result.X &&
                          expect.Y == result.Y &&
                          expect.Z == result.Z);
        }

        /// <summary>
        /// Тест на деление векторов
        /// </summary>
        [TestMethod]
        public void DivisionTest()
        {
            Vector expect = new Vector(2, -2, 0.25);
            Vector result = vector1 / vector2;
            Assert.IsTrue(expect.X == result.X &&
                          expect.Y == result.Y &&
                          expect.Z == result.Z);
        }

        /// <summary>
        /// Тест на деление вектора на число
        /// </summary>
        [TestMethod]
        public void DivisionNumberTest()
        {
            Vector expect = new Vector(5, 10, 2);
            Vector result = vector1 / 2;
            Assert.IsTrue(expect.X == result.X &&
                          expect.Y == result.Y &&
                          expect.Z == result.Z);
        }

        /// <summary>
        /// Тест на равенство векторов
        /// </summary>
        [TestMethod]
        public void EqualsTest()
        {
            Vector vector1 = new Vector(4, -3, 2);
            Vector vector2 = new Vector(4, -3, 2);
            bool result = vector1 == vector2;
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Тест на неравенство векторов
        /// </summary>
        [TestMethod]
        public void EqualsMethodTest()
        {
            Vector vector1 = new Vector(4, -3, 2);
            Vector vector2 = new Vector(4, -3, 2);
            bool result = vector1.Equals(vector2);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Тест на неравенство векторов
        /// </summary>
        [TestMethod]
        public void NotEqualsTest()
        {
            Vector vector1 = new Vector(4, -3, 1);
            Vector vector2 = new Vector(7, -3, 2);
            bool result = vector1 != vector2;
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Тест на неравенство векторов
        /// </summary>
        [TestMethod]
        public void NotEqualsMethodTest()
        {
            Vector vector1 = new Vector(4, -3, 1);
            Vector vector2 = new Vector(7, -3, 2);
            bool result = vector1.Equals(vector2);
            Assert.IsFalse(result);
        }
    }
}
