using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
