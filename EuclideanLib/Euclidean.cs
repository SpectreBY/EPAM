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
        /// Поиск НОД для двух чисел
        /// </summary>
        /// <param name="_digit1"></param>
        /// <param name="_digit2"></param>
        /// <returns></returns>
        public static int FindDeviderForTwoDigits(int _digit1, int _digit2)
        {
            int digit1;
            int digit2;
            int digit3;
            int degree;
            int result;

            if(_digit1 >= _digit2)
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
                if(digit3 >= digit2)
                    degree++;
                else if(digit3 == 0)
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
        /// Поиск НОД для трех и более чисел
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static int FindDeviderForFewDigits(int[] digits)
        {
            int result = digits.First();

            for (int i = 1; i < digits.Length; i++)
            {
                result = FindDeviderForTwoDigits(result, digits[i]);
            }
            return result;
        }
    }
}
