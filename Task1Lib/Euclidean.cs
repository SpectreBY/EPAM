using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Lib
{
    /// <summary>
    /// Класс для вычисления НОД с помощью алгоритма Эвклида
    /// </summary>
    public static class Euclidean
    {
        /// <summary>
        /// Поиск НОД для 2-х чисел
        /// </summary>
        /// <param name="_digit1"></param>
        /// <param name="_digit2"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int FindDevider(int _digit1, int _digit2, out TimeSpan time)
        {
            Stopwatch timer = Stopwatch.StartNew();

            int digit1;
            int digit2;
            int digit3;
            int degree;
            int result;

            if (_digit1 < 0)
                _digit1 = Math.Abs(_digit1);
            if (_digit2 < 0)
                _digit2 = Math.Abs(_digit2);
            if (_digit1 == 0)
            {
                timer.Stop();
                time = timer.Elapsed;
                return _digit2;
            }
            if (_digit2 == 0)
            {
                timer.Stop();
                time = timer.Elapsed;
                return _digit1;
            }
            if (_digit1 >= _digit2)
            {
                digit1 = _digit1;
                digit2 = _digit2;
            }
            else
            {
                digit1 = _digit2;
                digit2 = _digit1;
            }

            degree = digit1 / digit2;

            while (true)
            {
                digit3 = digit1 - digit2 * degree;
                if (digit3 >= digit2)
                    degree++;
                else if (digit3 == 0)
                {
                    result = digit2;
                    break;
                }
                else
                {
                    degree = 1;
                    digit1 = digit2;
                    digit2 = digit3;
                }
            }
            timer.Stop();
            time = timer.Elapsed;
            return result;
        }

        /// <summary>
        /// Поиск НОД для 3-х чисел
        /// </summary>
        /// <param name="_digit1"></param>
        /// <param name="_digit2"></param>
        /// <param name="_digit3"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int FindDevider(int _digit1, int _digit2, int _digit3, out TimeSpan time)
        {
            Stopwatch timer = Stopwatch.StartNew();
            int[] digits = new int[3] { _digit1, _digit2, _digit3 };
            int result = FindDeviderHelper(digits);
            timer.Stop();
            time = timer.Elapsed;
            return result;
        }

        /// <summary>
        /// Поиск НОД для 4-х чисел
        /// </summary>
        /// <param name="_digit1"></param>
        /// <param name="_digit2"></param>
        /// <param name="_digit3"></param>
        /// <param name="_digit4"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int FindDevider(int _digit1, int _digit2, int _digit3, int _digit4, out TimeSpan time)
        {
            Stopwatch timer = Stopwatch.StartNew();
            int[] digits = new int[4] { _digit1, _digit2, _digit3, _digit4 };
            int result = FindDeviderHelper(digits);
            timer.Stop();
            time = timer.Elapsed;
            return result;
        }

        /// <summary>
        /// Поиск НОД для 5-ти чисел
        /// </summary>
        /// <param name="_digit1"></param>
        /// <param name="_digit2"></param>
        /// <param name="_digit3"></param>
        /// <param name="_digit4"></param>
        /// <param name="_digit5"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int FindDevider(int _digit1, int _digit2, int _digit3, int _digit4, int _digit5, out TimeSpan time)
        {
            Stopwatch timer = Stopwatch.StartNew();
            int[] digits = new int[5] { _digit1, _digit2, _digit3, _digit4, _digit5 };
            int result = FindDeviderHelper(digits);
            timer.Stop();
            time = timer.Elapsed;
            return result;
        }

        /// <summary>
        /// Цикл поиска НОД для нескольких чисел
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        private static int FindDeviderHelper(int[] digits)
        {
            int result = digits.First();
            for (int i = 1; i < digits.Length; i++)
            {
                result = FindDevider(result, digits[i], out _);
            }
            return result;
        }
    }
}
