using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using Task3EnumsLib.Enums;
using Task3FiguresLib.Figures;
using Task3FiguresLib.Interfaces;

namespace Task3FiguresLib
{
    /// <summary>
    /// Box for figures and functions for working with it
    /// </summary>
    public class Box: IWriteFile
    {
        /// <summary>
        /// Collection of figures
        /// </summary>
        private List<Figure> figures = new List<Figure>();

        /// <summary>
        /// Property for access to collection
        /// </summary>
        public List<Figure> Figures
        {
            get { return figures; }
        }

        /// <summary>
        /// Method for add figure to collection
        /// </summary>
        /// <param name="figure"></param>
        public void AddFigure(Figure figure)
        {
            if(!figures.Contains(figure))
            {
                if (figures.Count < 20)
                {
                    figures.Add(figure);
                }
            }
        }

        /// <summary>
        /// Method which return figure object by number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Figure ShowByNumber(int number)
        {
            if(number <= figures.Count && figures.Count > 0)
            {
                return figures[number - 1];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Method which return figure object by number and remove him from collection
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Figure ShowByNumberAndRemove(int number)
        {
            if (number <= figures.Count && figures.Count > 0)
            {
                Figure figure = figures[number - 1];
                figures.RemoveAt(number - 1);
                return figure;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Method which replace figure in collection by number
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="number"></param>
        public void ReplaceByNumber(Figure figure, int number)
        {
            if (number <= figures.Count && figures.Count > 0)
            {
                figures[number - 1] = figure;
            }
        }

        /// <summary>
        /// Method which return equivalent figure
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public List<Figure> FindEquivalent(Figure figure)
        {
            List<Figure> sameFigures = figures.Where(o => o.Material.Color.Equals(figure.Material.Color) && o.Material.Equals(figure.Material)).ToList();
            return sameFigures;
        }

        /// <summary>
        /// Method which return quantity of figures in collection
        /// </summary>
        /// <returns></returns>
        public int ShowQuantity()
        {
            return figures.Count;
        }

        /// <summary>
        /// Method which return sum of squares of figures
        /// </summary>
        /// <returns></returns>
        public double ShowSquareSum()
        {
            double sum = figures.Sum(o => o.GetSquare());
            return sum;
        }

        /// <summary>
        /// Method which return sum of perimeters of figures
        /// </summary>
        /// <returns></returns>
        public double ShowPrimetrSum()
        {
            double sum = figures.Sum(o => o.GetPerimetr());
            return sum;
        }

        /// <summary>
        /// Method which return collection of figures with Circle type
        /// </summary>
        /// <returns></returns>
        public List<Figure> ShowCircles()
        {
            List<Figure> circles = figures.Where(o => o is Circle).ToList();
            return circles;
        }

        /// <summary>
        /// Method which return collection of figures with Envelope material
        /// </summary>
        /// <returns></returns>
        public List<Figure> ShowEnvelopeFigures()
        {
            List<Figure> envelopeFigures = figures.Where(o => o.Material.MaterialType == MaterialTypes.Envelope).ToList();
            return envelopeFigures;
        }

        /// <summary>
        /// Method for save figures to xml file by XmlWriter
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="filename"></param>
        public void SaveFiguresByXmlWriter(SaveModes mode, string filename)
        {
            XmlWriter writer;
            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;
            writer = XmlWriter.Create(filename, writerSettings);
            writer.WriteStartDocument();
            writer.WriteStartElement("figures");
            foreach (var figure in figures)
            {
                switch (mode)
                {
                    case SaveModes.All:
                        writer.WriteStartElement("figure");
                        figure.WriteByXmlWriterHelper(writer);
                        writer.WriteEndElement();
                        break;
                    case SaveModes.OnlyEnvelope:
                        if (figure.Material.MaterialType == MaterialTypes.Envelope)
                        {
                            writer.WriteStartElement("figure");
                            figure.WriteByXmlWriterHelper(writer);
                            writer.WriteEndElement();
                        }
                        break;
                    case SaveModes.OnlyPaper:
                        if (figure.Material.MaterialType == MaterialTypes.Paper)
                        {
                            writer.WriteStartElement("figure");
                            figure.WriteByXmlWriterHelper(writer);
                            writer.WriteEndElement();
                        }
                        break;
                }
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            figures.Clear();
        }

        /// <summary>
        /// Method for save figures to xml file by StreamWriter
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="filename"></param>
        public void SaveFiguresByStreamWriter(SaveModes mode, string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine(string.Format("<?xml version={0}1.0{1} encoding={2}utf-8{3} ?>", @"""", @"""", @"""", @""""));
            writer.WriteLine("<figures>");
            foreach (var figure in figures)
            {
                switch (mode)
                {
                    case SaveModes.All:
                        writer.WriteLine("  <figure>");
                        figure.WriteByStreamWriterHelper(writer);
                        writer.WriteLine("  </figure>");
                        break;
                    case SaveModes.OnlyEnvelope:
                        if (figure.Material.MaterialType == MaterialTypes.Envelope)
                        {
                            writer.WriteLine("  <figure>");
                            figure.WriteByStreamWriterHelper(writer);
                            writer.WriteLine("  </figure>");
                        }
                        break;
                    case SaveModes.OnlyPaper:
                        if (figure.Material.MaterialType == MaterialTypes.Paper)
                        {
                            writer.WriteLine("  <figure>");
                            figure.WriteByStreamWriterHelper(writer);
                            writer.WriteLine("  </figure>");
                        }
                        break;
                }
            }
            writer.WriteLine("</figures>");
            writer.Close();
            figures.Clear();
        }

        /// <summary>
        /// Method for load figures from xml file and parsing by XmlWriter
        /// </summary>
        /// <param name="filename"></param>
        public void ReadFiguresByXmlReader(string filename)
        {
            XmlReader reader = XmlReader.Create(filename);
            while (reader.Read())
            {
                if (reader.Name == "figure")
                {
                    XmlDocument document = new XmlDocument();
                    document.LoadXml(reader.ReadOuterXml());
                    XmlNode node = document.SelectSingleNode("figure");
                    XmlNode figureTypeNode = node.SelectSingleNode("figuretype");
                    XmlNode colorNode = node.SelectSingleNode("color");
                    XmlNode materialNode = node.SelectSingleNode("material");

                    Colors color = (Colors)Enum.Parse(typeof(Colors), colorNode.InnerText);
                    MaterialTypes materialType = (MaterialTypes)Enum.Parse(typeof(MaterialTypes), materialNode.InnerText);
                    Material material = new Material(materialType);

                    if (figureTypeNode.InnerText == "Square")
                    {
                        XmlNode squareSideNode = node.SelectSingleNode("a");
                        double squareSide = Convert.ToDouble(squareSideNode.InnerText);

                        Square square = new Square(material, squareSide);
                        if (materialType == MaterialTypes.Paper)
                        {
                            square.Material.Paint(color);
                        }

                        figures.Add(square);
                    }
                    if (figureTypeNode.InnerText == "Circle")
                    {
                        XmlNode circleRadiusNode = node.SelectSingleNode("radius");
                        double circleRadius = Convert.ToDouble(circleRadiusNode.InnerText);

                        Circle circle = new Circle(material, circleRadius);
                        if (materialType == MaterialTypes.Paper)
                        {
                            circle.Material.Paint(color);
                        }

                        figures.Add(circle);
                    }
                    if (figureTypeNode.InnerText == "Triangle")
                    {
                        XmlNode triangleSideNode = node.SelectSingleNode("a");
                        XmlNode triangleHeightNode = node.SelectSingleNode("height");
                        double triangleSide = Convert.ToDouble(triangleSideNode.InnerText);

                        Triangle triangle = new Triangle(material, triangleSide);
                        if (material.MaterialType == MaterialTypes.Paper)
                        {
                            triangle.Material.Paint(color);
                        }

                        figures.Add(triangle);
                    }
                }
            }
        }

        /// <summary>
        /// Method for load figures from xml file and parsing by StreamWriter
        /// </summary>
        /// <param name="filename"></param>
        public void ReadFiguresByStreamReader(string filename)
        {
            //string path = "figuresStreamWriter.xml";
            Regex tag = new Regex(@"<[0-9a-zA-Z]+>");
            Regex value = new Regex(@"[\^\>][0-9a-zA-Z]+");
            StreamReader reader = new StreamReader(filename);
            string file = reader.ReadToEnd();
            string[] items = file.Split(new string[] { "<figure>" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < items.Length; i++)
            {
                string[] block = items[i].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                List<string> values = new List<string>();
                for (int j = 0; j < block.Length; j++)
                {
                    if (value.IsMatch(block[j]))
                    {
                        values.Add(value.Match(block[j]).Value.Remove(0, 1));
                    }
                }

                Colors color = (Colors)Enum.Parse(typeof(Colors), values[1]);
                MaterialTypes materialType = (MaterialTypes)Enum.Parse(typeof(MaterialTypes), values[2]);
                Material material = new Material(materialType);

                if (values.First() == "Square")
                {
                    double squareSide = Convert.ToDouble(values[3]);
                    Square square = new Square(material, squareSide);
                    if (materialType == MaterialTypes.Paper)
                    {
                        square.Material.Paint(color);
                    }
                    figures.Add(square);
                }
                else if (values.First() == "Circle")
                {
                    double circleRadius = Convert.ToDouble(values[3]);
                    Circle circle = new Circle(material, circleRadius);
                    if (materialType == MaterialTypes.Paper)
                    {
                        circle.Material.Paint(color);
                    }
                    figures.Add(circle);
                }
                else if (values.First() == "Triangle")
                {
                    double triangleSide = Convert.ToDouble(values[3]);
                    Triangle triangle = new Triangle(material, triangleSide);
                    if (materialType == MaterialTypes.Paper)
                    {
                        triangle.Material.Paint(color);
                    }
                    figures.Add(triangle);
                }
            }
        }

        /// <summary>
        /// Method for cleaning collection
        /// </summary>
        public void ClearBox()
        {
            figures.Clear();
        }
    }
}