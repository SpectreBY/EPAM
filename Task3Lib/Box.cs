using System;
using System.Collections.Generic;
using System.Linq;
using Task3Lib.Enums;
using Task3Lib.Figures;

namespace Task3Lib
{
    class Box
    {
        private static List<Figure> figures = new List<Figure>();

        public static void AddFigure(Figure figure)
        {
            if(!figures.Contains(figure))
            {
                if (figures.Count < 20)
                {
                    figures.Add(figure);
                }
            }
        }
        public static Figure ShowByNumber(int number)
        {
            try
            {
                return figures[number - 1];
            }
            catch(IndexOutOfRangeException)
            {
                return null;
            }
        }

        public static Figure ShowByNumberAndRemove(int number)
        {
            try
            {
                Figure figure = figures[number - 1];
                figures.RemoveAt(number - 1);
                return figure;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        public static void ReplaceByNumber(Figure figure, int number)
        {
            try
            {
                figures[number - 1] = figure;
            }
            catch (IndexOutOfRangeException)
            {
                
            }
        }

        public static List<Figure> FindEquivalent(Figure figure, int number)
        {
            List<Figure> sameFigures = figures.Where(o => o.Color.Equals(figure.Color) && o.Material.Equals(figure.Material)).ToList();
            if(sameFigures.Count > 0)
            {
                return sameFigures;
            }
            else
            {
                throw new Exception("AAA");
            }
        }

        public static int ShowQuantity()
        {
            return figures.Count;
        }

        public static double ShowSquareSum()
        {
            double sum = figures.Sum(o => o.GetSquare());
            return sum;
        }

        public static double ShowPrimetrSum()
        {
            double sum = figures.Sum(o => o.GetPerimetr());
            return sum;
        }

        public static List<Figure> ShowCircles()
        {
            List<Figure> circles = figures.Where(o => o is Circle).ToList();
            return circles;
        }

        public static List<Figure> ShowEnvelopeFigures()
        {
            List<Figure> circles = figures.Where(o => o.Material == Materials.Envelope).ToList();
            return circles;
        }
    }
}