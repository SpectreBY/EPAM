using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3EnumsLib.Enums;
using Task3FiguresLib;
using Task3FiguresLib.Figures;

namespace Task3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Figure square1 = new Square(Materials.Paper, 4);
            Figure square2 = new Triangle(Materials.Paper, 2, 3);
            Figure square3 = new Square(Materials.Paper, 3);
            Box.AddFigure(square1);
            Box.AddFigure(square2);
            Box.AddFigure(square3);
            Box.SaveFiguresByXmlWriter();
            Box.SaveFiguresByStreamWriter();
            Box.ReadFiguresByStreamReader();

        }
    }
}
