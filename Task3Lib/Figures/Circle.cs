﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Task3Lib.Enums;

namespace Task3Lib.Figures
{
    class Circle : Figure
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
            base.WriteByStreamWriter(writer);
            writer.WriteLine(string.Format("<radius>{0}</radius>", radius));
        }

        public override void WriteByXmlWriter(XmlWriter writer)
        {
            base.WriteByXmlWriter(writer);
            writer.WriteStartElement("Radius");
            writer.WriteValue(radius);
            writer.WriteEndElement();
        }
    }
}
