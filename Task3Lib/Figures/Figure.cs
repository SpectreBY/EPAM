using System;
using System.Collections.Generic;
using System.Text;
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
        private Colors color;
        private Materials material;

        private bool wasPainted;

        public Figure(Materials material)
        {
            this.material = material;
            wasPainted = false;
            if (material == Materials.Paper)
            {
                color = Colors.White;
            }
            else
            {
                color = Colors.Colorless;
            }
        }

        public Colors Color
        {
            get { return color; }
            set { color = value; }
        }

        public Materials Material
        {
            get { return material; }
            set { material = value; }
        }
        //public Figure(Figure figure)
        //{

        //}

        public void ToPaint(Colors color)
        {
            if(!wasPainted && material == Materials.Paper)
            {
                this.color = color;
                wasPainted = true;
            }
            else
            {
                throw new ColorException("Данная фигура уже покрашена");
            }
        }

        public abstract double GetPerimetr();
        public abstract double GetSquare();
    }
}
