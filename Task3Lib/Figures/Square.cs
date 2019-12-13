using System;
using System.Collections.Generic;
using System.Text;
using Task3Lib.Materials;

namespace Task3Lib.Figures
{
    class Square : Figure
    {
        public Square(Material material) : base(material)
        {
        }

        public Square(Figure figure) : base(figure)
        {
        }
    }
}
