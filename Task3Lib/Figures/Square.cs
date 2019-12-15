﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Task3Lib.Enums;

namespace Task3Lib.Figures
{
    class Square : Figure
    {
        private double side;

        public Square(Materials material, double side) : base(material)
        {
            this.side = side;
        }

        public override void ToPaint(Colors color)
        {
            base.ToPaint(color);
        }

        public override double GetPerimetr()
        {
            double perimetr = 4 * side;
            return perimetr;
        }

        public override double GetSquare()
        {
            double square = Math.Pow(side, 2);
            return square;
        }

        public override void WriteByXmlWriter(XmlWriter writer)
        {
            base.WriteByXmlWriter(writer);
            writer.WriteStartElement("A");
            writer.WriteValue(side);
            writer.WriteEndElement();
            writer.WriteStartElement("B");
            writer.WriteValue(side);
            writer.WriteEndElement();
            writer.WriteStartElement("C");
            writer.WriteValue(side);
            writer.WriteEndElement();
            writer.WriteStartElement("D");
            writer.WriteValue(side);
            writer.WriteEndElement();
        }

        public override void ReadByXmlReader()
        {
            throw new NotImplementedException();
        }

        public override void WriteByStreamWriter(StreamWriter writer)
        {
            base.WriteByStreamWriter(writer);
            writer.WriteLine(string.Format("<a>{0}</a>", side));
            writer.WriteLine(string.Format("<b>{0}</a>", side));
            writer.WriteLine(string.Format("<c>{0}</a>", side));
            writer.WriteLine(string.Format("<d>{0}</a>", side));
        }

        public override void ReadByStreamReader()
        {
            throw new NotImplementedException();
        }
    }
}
