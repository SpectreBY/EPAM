using System;
using Task1Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1
{
    [TestClass]
    public class HistogramTest
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
        /// Тест метода получения времени выполнения двух алгоритмов для гистограммы
        /// </summary>
        [TestMethod]
        public void GetDataTest()
        {
            TimeSpan timeEuclidean;
            TimeSpan timeBinary;
            for (int i = 0; i < testValuesCasesForTwoDigits.GetLength(0);i++)
            { 
                Histogram.GetData(testValuesCasesForTwoDigits[i, 0], testValuesCasesForTwoDigits[i, 1], out timeEuclidean, out timeBinary);
                TestContext.WriteLine(string.Format(@"Алгоритм Эвклида: {0}, Бинарный алгоритм: {1}", timeEuclidean.TotalMilliseconds, timeBinary.TotalMilliseconds));
            }
        }
    }
}
