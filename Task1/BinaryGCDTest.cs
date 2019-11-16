using EuclideanLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Task1
{
    [TestClass]
    public class BinaryGCDTest
    {
        #region TestValuesCases
        /// <summary>
        /// Набор значений для прохождения теста в формате: [{значение 1}, {значение 2}, {ожидаемое значение}]
        /// </summary>
        private int[,] testValuesCases = new int[10, 3]
        {
            { 64, 48, 16 },
            { 88, 256, 8 },
            { 12, 26, 2 },
            { -12, 120, 12 },
            { -12, -4, 4 },
            { 14, 0, 14 },
            { 0, 27, 27 },
            { 13, 27, 1 },
            { 61, 22, 1 },
            { 1, 1, 1 }
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

        /// <summary>
        /// Тест метода получения НОД для двух чисел с помощью Бинарного алгоритма
        /// </summary>
        [TestMethod]
        public void FindDeviderTest()
        { 
            TimeSpan time;
            for(int i = 0; i < testValuesCases.GetLength(0); i++)
            {
                int result = BinaryGCD.FindDevider(testValuesCases[i, 0], testValuesCases[i, 1], out time);
                Assert.AreEqual(testValuesCases[i, 2], result);
                TestContext.WriteLine(string.Format("Значение 1: {0}, Значение 2: {1}, Ожидаемое значение: {2}, Затраченое время: {3}", testValuesCases[i, 0],
                                                                                                                                        testValuesCases[i, 1],
                                                                                                                                        testValuesCases[i, 2],
                                                                                                                                        time.TotalMilliseconds));
            }
        }
    }
}
