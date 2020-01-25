using System;
using System.Collections.Generic;
using System.Text;
using Task3EnumsLib.Enums;
using Task3FiguresLib.Exceptions;

namespace Task3FiguresLib
{
    /// <summary>
    /// Class which represents material of figure
    /// </summary>
    public class Material
    {
        /// <summary>
        /// Field which store material type value
        /// </summary>
        private MaterialTypes materialType;

        /// <summary>
        /// Field which store color value of material
        /// </summary>
        private Colors color;

        /// <summary>
        /// Field which store value was painting or no
        /// </summary>
        private bool isPainted;

        /// <summary>
        /// Constructor which get material type parametr
        /// </summary>
        /// <param name="materialType"></param>
        public Material(MaterialTypes materialType)
        {
            this.materialType = materialType;
            if(materialType == MaterialTypes.Envelope)
            {
                color = Colors.Colorless;
            }
            isPainted = false;
        }

        /// <summary>
        /// Property which stores the value of color
        /// </summary>
        public Colors Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        /// <summary>
        /// Property which stores the value of material
        /// </summary>
        public MaterialTypes MaterialType
        {
            get
            {
                return materialType;
            }
        }

        /// <summary>
        /// Method for paint material
        /// </summary>
        /// <param name="newColor"></param>
        public void Paint(Colors newColor)
        {
            if(materialType == MaterialTypes.Paper && !isPainted)
            {
                color = newColor;
            }
            else
            {
                throw new MaterialException("Невозможно покрасить, тк материал - пленка");
            }
        }
    }
}
