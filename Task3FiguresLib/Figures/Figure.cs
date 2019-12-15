using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Task3EnumsLib.Enums;

namespace Task3FiguresLib.Figures
{
    /// <summary>
    /// An abstract class that represents the basic characteristics of all figures
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Constant value for cut figure from another figure
        /// </summary>
        public const double PERCENT_FROM_VALUE = 0.9;

        /// <summary>
        /// A variable that indicates whether the figure has been painted
        /// </summary>
        private bool wasPainted;

        /// <summary>
        /// Constructor for announcement of figure object with input material
        /// </summary>
        /// <param name="material"></param>
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

        /// <summary>
        /// Constructor for announcement of figure object with input figure
        /// </summary>
        /// <param name="figure"></param>
        public Figure(Figure figure)
        {  }

        /// <summary>
        /// Property which stores the value of color
        /// </summary>
        public Colors Color { get; set; }

        /// <summary>
        /// Property which stores the value of material
        /// </summary>
        public Materials Material { get; set; }

        /// <summary>
        /// Method for painting figure
        /// </summary>
        /// <param name="color"></param>
        public virtual void ToPaint(Colors color)
        {
            if (!wasPainted && Material == Materials.Paper)
            {
                Color = color;
                wasPainted = true;
            }
            else
            {
                throw new Exception("Данная фигура уже покрашена");
            }
        }

        /// <summary>
        /// Abstract method for get sum of perimetr
        /// </summary>
        /// <returns></returns>
        public abstract double GetPerimetr();

        /// <summary>
        /// Abstract method for get sum of square
        /// </summary>
        /// <returns></returns>
        public abstract double GetSquare();

        /// <summary>
        /// Abstract method for write characteristics to xml file by XmlWriter
        /// </summary>
        /// <param name="writer"></param>
        public abstract void WriteByXmlWriter(XmlWriter writer);

        /// <summary>
        /// Abstract method for write characteristics to xml file by StreamWriter
        /// </summary>
        /// <param name="writer"></param>
        public abstract void WriteByStreamWriter(StreamWriter writer);
    }
}
