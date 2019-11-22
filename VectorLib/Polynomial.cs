﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2Lib
{
    class Polynomial
    {
        private List<double> _array;

        /// <summary>
        /// Инициализирует новый полином заданной строкой коэффициентов
        /// </summary>
        /// <param name="arrayCoefficients">Строка коэффициентов</param>
        public Polynomial(IEnumerable<double> arrayCoefficients)
        {
            _array = new List<double>(arrayCoefficients);
        }

        /// <summary>
        /// Инициализирует новый полином по старшей степени при этом все коэффициенты будут равны 0
        /// </summary>
        /// <param name="headPow">Старшая степень полинома</param>
        public Polynomial(int headPow)
        {
            _array = new List<double>(headPow);

            for (int i = 0; i < headPow; i++)
                _array.Add(0D);
        }

        /// <summary>
        /// Доступ к коэффициенту полинома по индексу
        /// </summary>
        /// <param name="i">Номер коффициента в полиноме</param>
        /// <returns>Коэффициент с заданным номером</returns>
        public double this[int i]
        {
            get
            {
                if (i < 0 || i >= _array.Count) throw new IndexOutOfRangeException();
                return _array[i];
            }

            set
            {
                if (i < 0 || i >= _array.Count) throw new IndexOutOfRangeException();
                _array[i] = value;
            }
        }

        /// <summary>
        /// Старшая степень полинома
        /// </summary>
        public int HeadPow
        {
            get
            {
                return _array.Count;
            }
        }

        /// <summary>
        /// Строка коэффициентов
        /// </summary>
        public IEnumerable<double> LineCoefficients
        {
            get
            {
                return _array;
            }
        }

        /// <summary>
        /// Выполняет сложение двух полиномов
        /// </summary>
        /// <param name="poly1">Первый полином</param>
        /// <param name="poly2">Второй полином</param>
        /// <returns>Результат сложения</returns>
        public static Polynomial operator +(Polynomial poly1, Polynomial poly2)
        {
            Polynomial maxPoly = maxPowPoly(poly1, poly2);
            Polynomial minPoly = minPowPoly(poly1, poly2);

            Polynomial resultPoly = new Polynomial(maxPoly.LineCoefficients);

            for (int i = 0; i < minPoly.HeadPow; i++)
                resultPoly[i] = maxPoly[i] + minPoly[i];

            return resultPoly;
        }

        /// <summary>
        /// Умножает полином на константу
        /// </summary>
        /// <param name="poly1">Полином</param>
        /// <param name="k">Константа</param>
        /// <returns>Полином умноженный на константу</returns>
        public static Polynomial operator *(Polynomial poly1, double k)
        {
            Polynomial resultPoly = new Polynomial(poly1.LineCoefficients);

            for (int i = 0; i < poly1.HeadPow; i++) resultPoly[i] *= k;

            return resultPoly;
        }

        /// <summary>
        /// Перемножает между собой два полинома
        /// </summary>
        /// <param name="poly1">Первый полином</param>
        /// <param name="poly2">Второй полином</param>
        /// <returns>Результат перемножения двух полиномов</returns>
        public static Polynomial operator *(Polynomial poly1, Polynomial poly2)
        {
            Polynomial resultPoly = new Polynomial(poly1.HeadPow + poly2.HeadPow - 1);
            resultPoly._array.Select(x => 0);

            for (int i = 0; i < poly1.HeadPow; i++)
                for (int j = 0; j < poly2.HeadPow; j++)
                    resultPoly[i + j] += poly1[i] * poly2[j];

            return resultPoly;
        }

        /// <summary>
        /// Вычисляет производную от полинома
        /// </summary>
        /// <returns>Произвдная</returns>
        public Polynomial Derivative()
        {
            Polynomial result = new Polynomial(this.LineCoefficients);

            for (int i = 0; i < this.HeadPow - 1; i++)
                result[i] = result[i + 1] * (i + 1);

            result._array.RemoveAt(result.HeadPow - 1);

            if (result._array.Count == 0) result._array.Add(0);

            return result;
        }

        /// <summary>
        /// Преобразует полином в строку
        /// </summary>
        /// <returns>Текстовой представление полинома</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.HeadPow; i++)
            {
                if (this[i] == 0 && i != 0) continue;
                if (i == 0)
                {
                    sb.Append(this[i] + " ");
                    continue;
                }
                if (this[i] > 0) sb.Append('+');
                if (i == 1)
                {
                    sb.Append(this[i] + "*x ");
                    continue;
                }

                sb.Append(this[i] + "*x^" + i + ' ');
            }

            return sb.ToString();
        }

        /// <summary>
        /// Решает полином подставляя x
        /// </summary>
        /// <param name="x">Значения x</param>
        /// <returns>Полученный ответ</returns>
        public double GetSolution(double x)
        {
            double res = this[0];

            for (int i = 1; i < this.HeadPow; i++)
                res += this[i] * Math.Pow(x, i);

            return res;
        }

        private static Func<Polynomial, Polynomial, Polynomial> maxPowPoly = (x, y) =>
            Math.Max(x.HeadPow, y.HeadPow) == x.HeadPow ? x : y;

        private static Func<Polynomial, Polynomial, Polynomial> minPowPoly = (x, y) =>
            maxPowPoly(x, y).Equals(x) ? y : x;
    }
}
