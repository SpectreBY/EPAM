using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Task3EnumsLib.Enums;
using Task3FiguresLib.Figures;

namespace Task3FiguresLib
{
    public class Box
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

        public static void SaveFiguresByXmlWriter()
        {
            string path = "figuresXmlWriter.xml";
            XmlWriter writer = XmlWriter.Create(path);
            writer.WriteStartDocument();
            writer.WriteStartElement("figures");
            foreach (var figure in figures)
            {
                writer.WriteStartElement("figure");
                figure.WriteByXmlWriter(writer);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        public static void SaveFiguresByStreamWriter()
        {
            string path = "figuresStreamWriter.xml";
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine("<figures>");
            foreach (var figure in figures)
            {
                figure.WriteByStreamWriter(writer);
            }
            writer.WriteLine("</figures>");
            writer.Close();
        }

        public static void ReadFiguresByXmlReader()
        {
            string path = "figuresXmlWriter.xml";
            XmlReader reader = XmlReader.Create(path);
            while (reader.Read())
            {
                if (reader.Name == "figure")
                {
                    XmlDocument document = new XmlDocument();
                    document.LoadXml(reader.ReadOuterXml());
                    XmlNode node = document.SelectSingleNode("figure");
                    XmlNode figuretype = node.SelectSingleNode("figuretype");
                    switch(figuretype.InnerText)
                    {
                        case "Square":
                            XmlNode squareSide = node.SelectSingleNode("a");
                            double squareSideValue = Convert.ToDouble(squareSide.InnerText);
                            figures.Add(new Square(Materials.Paper, squareSideValue));
                            break;
                        case "Circle":
                            XmlNode radius = node.SelectSingleNode("radius");    
                            break;
                        case "Triangle":
                            XmlNode height = node.SelectSingleNode("height");
                            XmlNode triangleSide = node.SelectSingleNode("a");
                            break;
                        default:
                            break;
                    }
                }  
            }
        }
    }
}