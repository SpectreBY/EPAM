using System;
using EuclideanLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1
{
    [TestClass]
    public class EuclideanTest
    {
        #region TestValuesCasesForTwoDigits
        /// <summary>
        /// Набор значений для прохождения теста в формате: [{значение 1}, {значение 2}, {ожидаемое значение}]
        /// </summary>
        private int[,] testValuesCasesForTwoDigits = new int[10, 3]
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

        #region TestValuesCasesForThreeDigits
        /// <summary>
        /// Набор значений для прохождения теста в формате: [{значение 1}, {значение 2}, {значение 3}, {ожидаемое значение}]
        /// </summary>
        private int[,] testValuesCasesForThreeDigits = new int[10, 4]
        {
            { 64, 48, 32, 16 },
            { 88, 24, 256, 8 },
            { -12, 26, -4, 2 },
            { -12, 120, 36, 12 },
            { -12, -4, 24, 4 },
            { 14, 0, 4, 2 },
            { 0, 27, 17, 1 },
            { 13, 27, 11, 1 },
            { 61, 22, 18, 1 },
            { 1, 1, 1, 1 }
        };
        #endregion

        #region TestValuesCasesForFourDigits
        /// <summary>
        /// Набор значений для прохождения теста в формате: [{значение 1}, {значение 2}, {значение 3}, {значение 4}, {ожидаемое значение}]
        /// </summary>
        private int[,] testValuesCasesForFourDigits = new int[10, 5]
        {
            { 64, 256, 48, 32, 16 },
            { 88, 24, 256, 64, 8 },
            { -12, 26, -4, 30, 2 },
            { 48, -12, 120, 36, 12 },
            { 40, -12, -4, 24, 4 },
            { 8, 14, 0, 4, 2 },
            { 7, 0, 27, 17, 1 },
            { 13, 24, 27, 11, 1 },
            { 23, 61, 22, 18, 1 },
            { 1, 1, 1, 1, 1 }
        };
        #endregion

        #region TestValuesCasesForFiveDigits
        /// <summary>
        /// Набор значений для прохождения теста в формате: [{значение 1}, {значение 2}, {значение 3}, {значение 4}, {значение 5}, {ожидаемое значение}]
        /// </summary>
        private int[,] testValuesCasesForFiveDigits = new int[10, 6]
        {
            { 16, 64, 256, 48, 32, 16 },
            { 88, 24, 80, 256, 64, 8 },
            { -12, 72, 26, -4, 30, 2 },
            { 60, 48, -12, 120, 36, 12 },
            { 40, -12, -4, 24, 20, 4 },
            { 8, 14, 0, 140, 4, 2 },
            { 42, 7, 0, 27, 17, 1 },
            { 13, 24, 23, 27, 11, 1 },
            { 11, 23, 61, 22, 18, 1 },
            { 1, 1, 1, 1, 1, 1 }
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
        /// Тест метода получения НОД для двух чисел с помощью алгоритма Эвклида
        /// </summary>
        [TestMethod]
        public void FindDeviderForTwoDigitsTest()
        {
            TimeSpan time;
            for (int i = 0; i < testValuesCasesForTwoDigits.GetLength(0); i++)
            {
                int result = Euclidean.FindDevider(testValuesCasesForTwoDigits[i, 0],
                                                   testValuesCasesForTwoDigits[i, 1],
                                                   out time);
                Assert.AreEqual(testValuesCasesForTwoDigits[i, 2], result);
                TestContext.WriteLine(string.Format("Значение 1: {0}, Значение 2: {1}, Ожидаемое значение: {2}, Затраченое время: {3}", testValuesCasesForTwoDigits[i, 0],
                                                                                                                                        testValuesCasesForTwoDigits[i, 1],
                                                                                                                                        testValuesCasesForTwoDigits[i, 2],
                                                                                                                                        time.TotalMilliseconds));
            }
        }

        /// <summary>
        /// Тест метода получения НОД для трех чисел с помощью алгоритма Эвклида
        /// </summary>
        [TestMethod]
        public void FindDeviderForThreeDigitsTest()
        {
            TimeSpan time;
            for (int i = 0; i < testValuesCasesForThreeDigits.GetLength(0); i++)
            {
                int result = Euclidean.FindDevider(testValuesCasesForThreeDigits[i, 0],
                                                   testValuesCasesForThreeDigits[i, 1],
                                                   testValuesCasesForThreeDigits[i, 2],
                                                   out time);
                Assert.AreEqual(testValuesCasesForThreeDigits[i, 3], result);
                TestContext.WriteLine(string.Format("Значение 1: {0}, Значение 2: {1}, Значение 2: {2}, Ожидаемое значение: {3}, Затраченое время: {4}", testValuesCasesForThreeDigits[i, 0],
                                                                                                                                                         testValuesCasesForThreeDigits[i, 1],
                                                                                                                                                         testValuesCasesForThreeDigits[i, 2],
                                                                                                                                                         testValuesCasesForThreeDigits[i, 3],
                                                                                                                                                         time.TotalMilliseconds));
            }
        }

        /// <summary>
        /// Тест метода получения НОД для четырех чисел с помощью алгоритма Эвклида
        /// </summary>
        [TestMethod]
        public void FindDeviderForFourDigitsTest()
        {
            TimeSpan time;
            for (int i = 0; i < testValuesCasesForFourDigits.GetLength(0); i++)
            {
                int result = Euclidean.FindDevider(testValuesCasesForFourDigits[i, 0],
                                                   testValuesCasesForFourDigits[i, 1], 
                                                   testValuesCasesForFourDigits[i, 2], 
                                                   testValuesCasesForFourDigits[i, 3], 
                                                   out time);
                Assert.AreEqual(testValuesCasesForFourDigits[i, 4], result);
                TestContext.WriteLine(string.Format("Значение 1: {0}, Значение 2: {1}, Значение 3: {2}, Значение 4: {3}, Ожидаемое значение: {4}, Затраченое время: {5}", testValuesCasesForFourDigits[i, 0],
                                                                                                                                                                          testValuesCasesForFourDigits[i, 1],
                                                                                                                                                                          testValuesCasesForFourDigits[i, 2],
                                                                                                                                                                          testValuesCasesForFourDigits[i, 3],
                                                                                                                                                                          testValuesCasesForFourDigits[i, 4],
                                                                                                                                                                          time.TotalMilliseconds));
            }
        }

        /// <summary>
        /// Тест метода получения НОД для пяти чисел с помощью алгоритма Эвклида
        /// </summary>
        [TestMethod]
        public void FindDeviderForFiveDigitsTest()
        {
            TimeSpan time;
            for (int i = 0; i < testValuesCasesForFiveDigits.GetLength(0); i++)
            {
                int result = Euclidean.FindDevider(testValuesCasesForFiveDigits[i, 0],
                                                   testValuesCasesForFiveDigits[i, 1],
                                                   testValuesCasesForFiveDigits[i, 2],
                                                   testValuesCasesForFiveDigits[i, 3],
                                                   testValuesCasesForFiveDigits[i, 4],
                                                   out time);
                Assert.AreEqual(testValuesCasesForFiveDigits[i, 5], result);
                TestContext.WriteLine(string.Format("Значение 1: {0}, Значение 2: {1}, Значение 3: {2}, Значение 4: {3}, Значение 5: {4}, Ожидаемое значение: {5}, Затраченое время: {6}", testValuesCasesForFiveDigits[i, 0],
                                                                                                                                                                                           testValuesCasesForFiveDigits[i, 1],
                                                                                                                                                                                           testValuesCasesForFiveDigits[i, 2],
                                                                                                                                                                                           testValuesCasesForFiveDigits[i, 3],
                                                                                                                                                                                           testValuesCasesForFiveDigits[i, 4],
                                                                                                                                                                                           testValuesCasesForFiveDigits[i, 5],
                                                                                                                                                                                           time.TotalMilliseconds));
            }
        }
    }
}
