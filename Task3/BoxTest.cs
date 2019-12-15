using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3EnumsLib.Enums;
using Task3FiguresLib;
using Task3FiguresLib.Figures;

namespace Task3
{
    /// <summary>
    /// Test class for Box static class
    /// </summary>
    [TestClass]
    public class BoxTest
    {
        /// <summary>
        /// Collection of testable figures
        /// </summary>
        private List<Figure> figures = new List<Figure>()
        {
            new Circle(Materials.Paper, 5),
            new Triangle(Materials.Paper, 7),
            new Triangle(Materials.Envelope, 3),
            new Square(Materials.Paper, 4),
            new Circle(Materials.Envelope, 8)
        };

        /// <summary>
        /// Test method on add figure to Box collection
        /// </summary>
        [TestMethod]
        public void AddFigureTest()
        {
            Box.ClearBox();
            AddFiguresToBox();
            Assert.AreEqual(Box.ShowQuantity(), figures.Count);
        }

        /// <summary>
        /// Test method on show figure by his number
        /// </summary>
        [TestMethod]
        public void ShowByNumberTest()
        {
            int number = 3;
            Box.ClearBox();
            AddFiguresToBox();
            Figure figure1 = figures[number - 1];
            Figure figure2 = Box.ShowByNumber(number);
            Assert.AreEqual(figure1, figure2);
        }

        /// <summary>
        /// Test method on show figure by his number and remove him
        /// </summary>
        [TestMethod]
        public void ShowByNumberAndRemoveTest()
        {
            int number = 3;
            Box.ClearBox();
            AddFiguresToBox();
            Figure figure = Box.ShowByNumberAndRemove(number);
            Assert.AreEqual(false, Box.Figures.Contains(figure));
        }

        /// <summary>
        /// Test method on replace figure object by his number
        /// </summary>
        [TestMethod]
        public void ReplaceByNumberTest()
        {
            int number = 3;
            Box.ClearBox();
            AddFiguresToBox();
            Figure figure = new Square(figures.First());
            Box.ReplaceByNumber(figure, number);
            Assert.AreEqual(figure, Box.ShowByNumber(number));
        }

        /// <summary>
        /// Test method on find equivalent figure
        /// </summary>
        [TestMethod]
        public void FindEquivalentTest()
        {
            Box.ClearBox();
            AddFiguresToBox();
            List<Figure> result = Box.FindEquivalent(figures.First());
            List<Figure> sameFigures = figures.Where(o => o.Color.Equals(figures.First().Color) && o.Material.Equals(figures.First().Material)).ToList();

            for(int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(result[i], sameFigures[i]);
            }
        }

        /// <summary>
        /// Test method on get square sum of all figures
        /// </summary>
        [TestMethod]
        public void ShowSquareTest()
        {
            Box.ClearBox();
            AddFiguresToBox();
            double result = Box.ShowSquareSum();
            double squareSum = figures.Sum(o => o.GetSquare());
            Assert.AreEqual(result, squareSum);
        }

        /// <summary>
        /// Test method on get perimetr sum of all figures
        /// </summary>
        [TestMethod]
        public void ShowPerimetrTest()
        {
            Box.ClearBox();
            AddFiguresToBox();
            double result = Box.ShowPrimetrSum();
            double perimetrSum = figures.Sum(o => o.GetPerimetr());
            Assert.AreEqual(result, perimetrSum);
        }

        /// <summary>
        /// Test method on get figures collection of circle type
        /// </summary>
        [TestMethod]
        public void ShowCiclesTest()
        {
            Box.ClearBox();
            AddFiguresToBox();
            List<Figure> result = Box.ShowCircles();
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(result[i].GetType(), typeof(Circle));
            }
        }

        /// <summary>
        /// Test method on get figures collection with envelope material
        /// </summary>
        [TestMethod]
        public void ShowEnvelopeFiguresTest()
        {
            Box.ClearBox();
            AddFiguresToBox();
            List<Figure> result = Box.ShowEnvelopeFigures();
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(result[i].Material, Materials.Envelope);
            }
        }

        /// <summary>
        /// Test method on save and read all figures by XmlReader
        /// </summary>
        [TestMethod]
        public void SaveAndReadAllFiguresByXmlWriterAndXmlReaderTest()
        {
            Box.ClearBox();
            AddFiguresToBox();
            Box.SaveFiguresByXmlWriter(SaveModes.All, "allFiguresXml.xml");
            Box.ReadFiguresByXmlReader("allFiguresXml.xml");
            int count = figures.Count();
            int resultCount = Box.ShowQuantity();
            Assert.AreEqual(count, resultCount);
        }

        /// <summary>
        /// Test method on save and read all figures by StreamReader
        /// </summary>
        [TestMethod]
        public void SaveAndReadAllFiguresByXmlWriterAndStreamReaderTest()
        {
            Box.ClearBox();
            AddFiguresToBox();
            Box.SaveFiguresByStreamWriter(SaveModes.All, "allFiguresStream.xml");
            Box.ReadFiguresByStreamReader("allFiguresStream.xml");
            int count = figures.Count();
            int resultCount = Box.ShowQuantity();
            Assert.AreEqual(count, resultCount);
        }

        /// <summary>
        /// Helper for add testable collection to Box
        /// </summary>
        private void AddFiguresToBox()
        {
            foreach (Figure figure in figures)
            {
                Box.AddFigure(figure);
            }
        }
    }
}
