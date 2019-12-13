using System;
using System.Collections.Generic;
using System.Text;
using Task3Lib.Materials;

namespace Task3Lib.Figures
{
    class Triangle : Figure
    {
        public Triangle(Material material) : base(material)
        {
        }

        public Triangle(Figure figure) : base(figure)
        {
        }
    }
}
