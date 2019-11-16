using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclideanLib
{
    public static class BinaryGCD
    {
        /// <summary>
        /// Поиск НОД для 2-х чисел c помощью бинарного алгоритма
        /// </summary>
        /// <param name="digit1"></param>
        /// <param name="digit2"></param>
        /// <returns></returns>
        public static int FindDevider(int digit1, int digit2)
        {
            if (digit1 == 0)
                return digit2;
            if (digit2 == 0)
                return digit1;
            if (digit1 == digit2)
                return digit1;
            if (digit1 == 1 || digit2 == 1)
                return 1;
            if (digit1 % 2 == 0 && digit2 % 2 == 0)
            {
                return FindDevider(digit1 >> 1, digit2 >> 1) << 1;
            }
            else if (digit1 % 2 == 0 && digit2 % 2 != 0)
            {
                return FindDevider(digit1 >> 1, digit2);
            }
            if (digit1 % 2 != 0 && digit2 % 2 == 0)
            {
                return FindDevider(digit1, digit2 >> 1);
            }
            else if (digit1 % 2 != 0 && digit2 % 2 != 0 && digit2 > digit1)
            {
                return FindDevider((digit2 - digit1) >> 1, digit1);
            }
            else if (digit1 % 2 != 0 && digit2 % 2 != 0 && digit1 > digit2)
            {
                return FindDevider((digit1 - digit2) >> 1, digit2);
            }
            else
            {
                return 0;
            }
        }
    }
}
