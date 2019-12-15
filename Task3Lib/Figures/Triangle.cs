﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Task3Lib.Enums;

namespace Task3Lib.Figures
{
    class Triangle : Figure
    {
        private double side;
        private double height;

        public Triangle(Materials material, double side, double height) : base(material)
        {
            this.side = side;
            this.height = height;
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
            base.WriteByStreamWriter(writer);
            writer.WriteLine(string.Format("<height>{0}</height>", height));
            writer.WriteLine(string.Format("<b>{0}</a>", side));
            writer.WriteLine(string.Format("<c>{0}</a>", side));
            writer.WriteLine(string.Format("<d>{0}</a>", side));
        }

        public override void WriteByXmlWriter(XmlWriter writer)
        {
            base.WriteByXmlWriter(writer);
            writer.WriteStartElement("Height");
            writer.WriteValue(height);
            writer.WriteEndElement();
            writer.WriteStartElement("A");
            writer.WriteValue(side);
            writer.WriteEndElement();
            writer.WriteStartElement("B");
            writer.WriteValue(side);
            writer.WriteEndElement();
            writer.WriteStartElement("C");
            writer.WriteValue(side);
            writer.WriteEndElement();
        }
    }
}
