using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Task3EnumsLib.Enums;

namespace Task3FiguresLib.Figures
{
    public class Triangle : Figure
    {
        private double side;
        private double height;

        public Triangle(Materials material, double side) : base(material)
        {
            this.side = side;
            this.height = (Math.Sqrt(3) * side) / 2;
        }

        public Triangle(Figure figure) : base(figure)
        {
            if (figure is Square)
            {
                Square square = (Square)figure;
                side = square.Side;
                height = (Math.Sqrt(3) * side) / 2;
                Material = square.Material;
                Color = square.Color;
            }
            if (figure is Circle)
            {
                Circle circle = (Circle)figure;
                side = (circle.Radius * 3) / Math.Sqrt(3);
                height = (Math.Sqrt(3) * side) / 2;
                Material = circle.Material;
                Color = circle.Color;
            }
            if (figure is Triangle)
            {
                Triangle triangle = (Triangle)figure;
                side = triangle.Side * PERCENT_FROM_VALUE;
                Material = triangle.Material;
                Color = triangle.Color;
            }
        }

        public double Side
        {
            get { return side; }
            set { side = value; }
        }

        public override double GetPerimetr()
        {
            double perimetr = 3 * side;
            return perimetr;
        }

        public override double GetSquare()
        {
            double square = 1/2 * side * height;
            return square;
        }

        public override void ReadByStreamReader()
        {
            throw new NotImplementedException();
        }

        public override void ReadByXmlReader()
        {
            
        }

        public override void WriteByStreamWriter(StreamWriter writer)
        {
            writer.WriteLine(string.Format("    <figuretype>{0}</figuretype>", "Triangle"));
            writer.WriteLine(string.Format("    <color>{0}</color>", Color.ToString()));
            writer.WriteLine(string.Format("    <material>{0}</material>", Material.ToString()));
            writer.WriteLine(string.Format("    <height>{0}</height>", height));
            writer.WriteLine(string.Format("    <a>{0}</a>", side));
            writer.WriteLine(string.Format("    <b>{0}</a>", side));
            writer.WriteLine(string.Format("    <c>{0}</a>", side));
        }

        public override void WriteByXmlWriter(XmlWriter writer)
        {
            writer.WriteStartElement("figuretype");
            writer.WriteValue("Triangle");
            writer.WriteEndElement();
            writer.WriteStartElement("color");
            writer.WriteValue(Color.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("material");
            writer.WriteValue(Material.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("height");
            writer.WriteValue(height);
            writer.WriteEndElement();
            writer.WriteStartElement("a");
            writer.WriteValue(side);
            writer.WriteEndElement();
            writer.WriteStartElement("b");
            writer.WriteValue(side);
            writer.WriteEndElement();
            writer.WriteStartElement("c");
            writer.WriteValue(side);
            writer.WriteEndElement();
        }
    }
}
