using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclideanLib
{
    /// <summary>
    /// Класс для получения данных для гистограмм
    /// </summary>
    public static class Histogram
    {
        /// <summary>
        /// Метод для получения времени выполнение алгорима Эвклида и Бинарного алгоритма для построения гистограммы
        /// </summary>
        public static void GetData(int digit1, int digit2, out TimeSpan timeEuclidean, out TimeSpan timeBinary)
        {
            Euclidean.FindDevider(digit1, digit2, out timeEuclidean);
            BinaryGCD.FindDevider(digit1, digit2, out timeBinary);
        }
    }
}
