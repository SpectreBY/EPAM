using System;
using System.Collections.Generic;
using System.Text;
using Task3Lib.Materials;

namespace Task3Lib.Figures
{
    class Circle : Figure
    {
        public Circle(Material material) : base(material)
        {
        }

        public Circle(Figure figure) : base(figure)
        {
        }
    }
}
