﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Task3Lib.Enums;

namespace Task3Lib.Figures
{
    class ColorException: Exception
    {
        public ColorException(string message)
        : base(message)
        { }
    }

    abstract class Figure
    {
        private bool wasPainted;

        public Figure(Materials material)
        {
            Material = material;
            wasPainted = false;
            if (material == Materials.Paper)
            {
                Color = Colors.White;
            }
            else
            {
                Color = Colors.Colorless;
            }
        }
        public Figure(Figure figure)
        {
            
        }


        public Colors Color { get; set; }

        public Materials Material { get; set; }

        public virtual void ToPaint(Colors color)
        {
            if (!wasPainted && Material == Materials.Paper)
            {
                Color = color;
                wasPainted = true;
            }
            else
            {
                throw new ColorException("Данная фигура уже покрашена");
            }
        }

        public abstract double GetPerimetr();
        public abstract double GetSquare();
        public virtual void WriteByXmlWriter(XmlWriter writer)
        {
            writer.WriteStartElement("Figure");
            writer.WriteValue(GetType().ToString());
            writer.WriteEndElement();
        }

        public abstract void ReadByXmlReader();
        public virtual void WriteByStreamWriter(StreamWriter writer)
        {
            writer.WriteLine(string.Format("<figure>{0}</figure>", GetType().ToString()));
        }
        public abstract void ReadByStreamReader();
    }
}
