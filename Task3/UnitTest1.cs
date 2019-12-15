using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3EnumsLib.Enums;
using Task3FiguresLib;
using Task3FiguresLib.Figures;

namespace Task3
{
    [TestClass]
    public class UnitTest1
    {
        private List<Figure> figures = new List<Figure>()
        {
            new Circle(Materials.Paper, 5),
            new Triangle(Materials.Paper, 7),
            new Triangle(Materials.Envelope, 3),
            new Square(Materials.Paper, 4),
            new Circle(Materials.Envelope, 8)
        };

        [TestMethod]
        public void AddFigureTest()
        { 
            foreach(Figure figure in figures)
            {
                Box.AddFigure(figure);         
            }
            Assert.AreEqual(Box.ShowQuantity(), figures.Count);
            //Figure square1 = new Square(Materials.Paper, 4);
            //Figure square2 = new Triangle(Materials.Envelope, 3);
            //Figure square3 = new Square(Materials.Paper, 3);
            //Figure circle = new Circle(Materials.Paper, 3);
            //Box.AddFigure(square1);
            //Box.AddFigure(square2);
            //Box.AddFigure(square3);
            //Box.AddFigure(circle);
            //Box.ShowCircles();
            //Box.ShowEnvelopeFigures();
            //Box.SaveFiguresByXmlWriter(SaveModes.OnlyEnvelope);
            //Box.SaveFiguresByStreamWriter(SaveModes.OnlyPaper);
            //Box.ReadFiguresByStreamReader();

        }
    }
}
