using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Task3EnumsLib.Enums;

namespace Task3FiguresLib.Figures
{
    public class Circle : Figure
    {
        private double radius;
        public Circle(Materials material, double radius) : base(material)
        {
            this.radius = radius;
        }

        public override double GetPerimetr()
        {
            double perimetr = 2 * Math.PI * radius;
            return perimetr;
        }

        public override double GetSquare()
        {
            double square = Math.PI * Math.Pow(radius, 2);
            return square;
        }

        public override void ReadByStreamReader()
        {
            throw new NotImplementedException();
        }

        public override void ReadByXmlReader()
        {
            throw new NotImplementedException();
        }

        public override void WriteByStreamWriter(StreamWriter writer)
        {
            writer.WriteLine(string.Format("    <figuretype>{0}</figuretype>", "Circle"));
            writer.WriteLine(string.Format("    <color>{0}</color>", Color.ToString()));
            writer.WriteLine(string.Format("    <material>{0}</material>", Material.ToString()));
            writer.WriteLine(string.Format("    <radius>{0}</radius>", radius));
        }

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
