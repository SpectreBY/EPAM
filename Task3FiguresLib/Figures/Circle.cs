using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Task3EnumsLib.Enums;

namespace Task3FiguresLib.Figures
{
    /// <summary>
    /// Class that represents circle figure
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// A variable which contains radius of the circle
        /// </summary>
        private double radius;

        /// <summary>
        /// Constructor for announcement of figure object with input material and radius value
        /// </summary>
        /// <param name="material"></param>
        /// <param name="radius"></param>
        public Circle(Materials material, double radius) : base(material)
        {
            this.radius = radius;
        }

        /// <summary>
        /// Constructor for announcement of figure object with input figure
        /// </summary>
        /// <param name="figure"></param>
        public Circle(Figure figure) : base(figure)
        {
            if (figure is Square)
            {
                Square square = (Square)figure;
                radius = square.Side / 2;
                Material = square.Material;
                Color = square.Color;
            }
            if (figure is Circle)
            {
                Circle circle = (Circle)figure;
                radius = circle.Radius * PERCENT_FROM_VALUE;
                Material = circle.Material;
                Color = circle.Color;
            }
            if (figure is Triangle)
            {
                Triangle triangle = (Triangle)figure;
                radius = triangle.Side / (2 * Math.Sqrt(3));
                Material = triangle.Material;
                Color = triangle.Color;
            }
        }

        /// <summary>
        /// Property for acsess to radius variable
        /// </summary>
        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        /// <summary>
        /// Method for get sum of perimetr
        /// </summary>
        /// <returns></returns>
        public override double GetPerimetr()
        {
            double perimetr = 2 * Math.PI * radius;
            return perimetr;
        }

        /// <summary>
        /// Method for get sum of square
        /// </summary>
        /// <returns></returns>
        public override double GetSquare()
        {
            double square = Math.PI * Math.Pow(radius, 2);
            return square;
        }

        /// <summary>
        /// Method for painting figure
        /// </summary>
        /// <param name="color"></param>
        public override void ToPaint(Colors color)
        {
            base.ToPaint(color);
        }

        /// <summary>
        /// Method for write characteristics to xml file by StreamWriter
        /// </summary>
        /// <param name="writer"></param>
        public override void WriteByStreamWriter(StreamWriter writer)
        {
            writer.WriteLine(string.Format("    <figuretype>{0}</figuretype>", "Circle"));
            writer.WriteLine(string.Format("    <color>{0}</color>", Color.ToString()));
            writer.WriteLine(string.Format("    <material>{0}</material>", Material.ToString()));
            writer.WriteLine(string.Format("    <radius>{0}</radius>", radius));
        }

        /// <summary>
        /// Method for write characteristics to xml file by XmlWriter
        /// </summary>
        /// <param name="writer"></param>
        public override void WriteByXmlWriter(XmlWriter writer)
        {
            writer.WriteStartElement("figuretype");
            writer.WriteValue("Circle");
            writer.WriteEndElement();
            writer.WriteStartElement("color");
            writer.WriteValue(Color.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("material");
            writer.WriteValue(Material.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("radius");
            writer.WriteValue(radius);
            writer.WriteEndElement();
        }
    }
}
