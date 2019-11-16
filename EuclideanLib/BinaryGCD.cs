using System;
using System.Diagnostics;

namespace EuclideanLib
{
    /// <summary>
    /// Класс для вычисления НОД с помощью бинарного алгоритма
    /// </summary>
    public static class BinaryGCD
    {
        /// <summary>
        /// Поиск НОД для 2-х чисел c помощью бинарного алгоритма
        /// </summary>
        /// <param name="digit1"></param>
        /// <param name="digit2"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int FindDevider(int digit1, int digit2, out TimeSpan time)
        {
            Stopwatch timer = Stopwatch.StartNew();
            timer.Start();
            int result = FindDeviderHelper(digit1, digit2);
            timer.Stop();
            time = timer.Elapsed;
            return result;
        }

        /// <summary>
        /// Поиск НОД для 2-х чисел c помощью бинарного алгоритма
        /// </summary>
        /// <param name="digit1"></param>
        /// <param name="digit2"></param>
        /// <returns></returns>
        private static int FindDeviderHelper(int digit1, int digit2)
        {
            if (digit1 < 0)
                digit1 = Math.Abs(digit1);
            if (digit2 < 0)
                digit2 = Math.Abs(digit2);
            if (digit1 == 0)
            {
                return digit2;
            }
            if (digit2 == 0)
            {
                return digit1;
            }
            if (digit1 == digit2)
            {
                return digit1;
            }
            if (digit1 == 1 || digit2 == 1)
            {
                return 1;
            }
            if ((digit1 & 1) == 0 && (digit2 & 1) == 0)
            {
                return FindDeviderHelper(digit1 >> 1, digit2 >> 1) << 1;
            }
            if ((digit1 & 1) == 0 && (digit2 & 1) != 0)
            {
                return FindDeviderHelper(digit1 >> 1, digit2);
            }
            if ((digit1 & 1) != 0 && (digit2 & 1) == 0)
            {
                return FindDeviderHelper(digit1, digit2 >> 1);
            }
            if ((digit1 & 1) != 0 && (digit2 & 1) != 0 && digit2 > digit1)
            {
                return FindDeviderHelper((digit2 - digit1) >> 1, digit1);
            }
            if ((digit1 & 1) != 0 && (digit2 & 1) != 0 && digit1 > digit2)
            {
                return FindDeviderHelper((digit1 - digit2) >> 1, digit2);
            }
            else
            {
                return 0;
            }
        }
    }
}
