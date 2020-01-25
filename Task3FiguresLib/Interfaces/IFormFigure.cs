using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3FiguresLib.Interfaces
{
    interface IFormFigure
    {
        /// <summary>
        /// Method for getting perimetr of figure
        /// </summary>
        /// <returns></returns>
        double GetPerimetr();

        /// <summary>
        /// Method for getting square of figure
        /// </summary>
        /// <returns></returns>
        double GetSquare();
    }
}
