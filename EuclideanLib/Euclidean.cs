using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclideanLib
{
    public static class Euclidean
    {
        /// <summary>
        /// Поиск НОД для 2-х чисел
        /// </summary>
        /// <param name="_digit1"></param>
        /// <param name="_digit2"></param>
        /// <returns></returns>
        public static int FindDevider(int _digit1, int _digit2)
        {
            int digit1;
            int digit2;
            int digit3;
            int degree;
            int result;

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
            return result;
        }

        /// <summary>
        /// Поиск НОД для 3-х чисел
        /// </summary>
        /// <param name="_digit1"></param>
        /// <param name="_digit2"></param>
        /// <param name="_digit3"></param>
        /// <returns></returns>
        public static int FindDevider(int _digit1, int _digit2, int _digit3)
        {
            int[] digits = new int[3] { _digit1, _digit2, _digit3 };
            return FindDeviderHelper(digits);
        }

        /// <summary>
        /// Поиск НОД для 4-х чисел
        /// </summary>
        /// <param name="_digit1"></param>
        /// <param name="_digit2"></param>
        /// <param name="_digit3"></param>
        /// <param name="_digit4"></param>
        /// <returns></returns>
        public static int FindDevider(int _digit1, int _digit2, int _digit3, int _digit4)
        {
            int[] digits = new int[4] { _digit1, _digit2, _digit3, _digit4 };
            return FindDeviderHelper(digits);
        }

        /// <summary>
        /// Поиск НОД для 5-ти чисел
        /// </summary>
        /// <param name="_digit1"></param>
        /// <param name="_digit2"></param>
        /// <param name="_digit3"></param>
        /// <param name="_digit4"></param>
        /// <param name="_digit5"></param>
        /// <returns></returns>
        public static int FindDevider(int _digit1, int _digit2, int _digit3, int _digit4, int _digit5)
        {
            int[] digits = new int[5] { _digit1, _digit2, _digit3, _digit4, _digit5 };
            return FindDeviderHelper(digits);
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
                result = FindDevider(result, digits[i]);
            }
            return result;
        }
    }
}
