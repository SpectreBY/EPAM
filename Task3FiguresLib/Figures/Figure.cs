using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Task3EnumsLib.Enums;
using Task3FiguresLib.Interfaces;

namespace Task3FiguresLib.Figures
{
    /// <summary>
    /// An abstract class that represents the basic characteristics of all figures
    /// </summary>
    public abstract class Figure : IFormFigure
    {
        /// <summary>
        /// Constant value for cut figure from another figure
        /// </summary>
        public const double PERCENT_FROM_VALUE = 0.9;

        /// <summary>
        /// 
        /// </summary>
        private Material material;

        /// <summary>
        /// Constructor for announcement of figure object with input material
        /// </summary>
        /// <param name="material"></param>
        public Figure(Material material)
        {
            this.material = material;
        }

        /// <summary>
        /// Constructor for announcement of figure object with input figure
        /// </summary>
        /// <param name="figure"></param>
        public Figure(Figure figure)
        { }

        /// <summary>
        /// 
        /// </summary>
        public Material Material
        {
            get { return material; }
            set { material = value; }
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
        public abstract void WriteByXmlWriterHelper(XmlWriter writer);

        /// <summary>
        /// Abstract method for write characteristics to xml file by StreamWriter
        /// </summary>
        /// <param name="writer"></param>
        public abstract void WriteByStreamWriterHelper(StreamWriter writer);
    }
}
