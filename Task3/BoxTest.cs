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
        /// Field which store Box object
        /// </summary>
        private Box box = new Box();

        #region
        /// <summary>
        /// Collection of testable figures
        /// </summary>
        private List<Figure> figures = new List<Figure>()
        {
            new Circle(new Material(MaterialTypes.Paper), 5),
            new Triangle(new Material(MaterialTypes.Paper), 7),
            new Triangle(new Material(MaterialTypes.Envelope), 3),
            new Square(new Material(MaterialTypes.Paper), 4),
            new Circle(new Material(MaterialTypes.Envelope), 8)
        };

        /// <summary>
        /// Collection of testable colors
        /// </summary>
        List<Colors> colors = new List<Colors>()
        {
            Colors.Red,
            Colors.Red,
            Colors.Colorless,
            Colors.Red,
            Colors.Colorless
        };
        #endregion

        /// <summary>
        /// Test method on add figure to Box collection
        /// </summary>
        [TestMethod]
        public void AddFigureTest()
        {
            box.ClearBox();
            AddFiguresToBox();
            Assert.AreEqual(box.ShowQuantity(), figures.Count);
        }

        /// <summary>
        /// Test method on show figure by his number
        /// </summary>
        [TestMethod]
        public void ShowByNumberTest()
        {
            int number = 3;
            box.ClearBox();
            AddFiguresToBox();
            Figure figure1 = figures[number - 1];
            Figure figure2 = box.ShowByNumber(number);
            Assert.AreEqual(figure1, figure2);
        }

        /// <summary>
        /// Test method on show figure by his number and remove him
        /// </summary>
        [TestMethod]
        public void ShowByNumberAndRemoveTest()
        {
            int number = 3;
            box.ClearBox();
            AddFiguresToBox();
            Figure figure = box.ShowByNumberAndRemove(number);
            Assert.AreEqual(false, box.Figures.Contains(figure));
        }

        /// <summary>
        /// Test method on replace figure object by his number
        /// </summary>
        [TestMethod]
        public void ReplaceByNumberTest()
        {
            int number = 3;
            box.ClearBox();
            AddFiguresToBox();
            Figure figure = new Square(figures.First());
            box.ReplaceByNumber(figure, number);
            Assert.AreEqual(figure, box.ShowByNumber(number));
        }

        /// <summary>
        /// Test method on find equivalent figure
        /// </summary>
        [TestMethod]
        public void FindEquivalentTest()
        {
            box.ClearBox();
            AddFiguresToBox();
            List<Figure> result = box.FindEquivalent(figures.First());
            List<Figure> sameFigures = figures.Where(o => o.Material.Color.Equals(figures.First().Material.Color) && o.Material.Equals(figures.First().Material)).ToList();

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
            box.ClearBox();
            AddFiguresToBox();
            double result = box.ShowSquareSum();
            double squareSum = figures.Sum(o => o.GetSquare());
            Assert.AreEqual(result, squareSum);
        }

        /// <summary>
        /// Test method on get perimetr sum of all figures
        /// </summary>
        [TestMethod]
        public void ShowPerimetrTest()
        {
            box.ClearBox();
            AddFiguresToBox();
            double result = box.ShowPrimetrSum();
            double perimetrSum = figures.Sum(o => o.GetPerimetr());
            Assert.AreEqual(result, perimetrSum);
        }

        /// <summary>
        /// Test method on get figures collection of circle type
        /// </summary>
        [TestMethod]
        public void ShowCiclesTest()
        {
            box.ClearBox();
            AddFiguresToBox();
            List<Figure> result = box.ShowCircles();
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
            box.ClearBox();
            AddFiguresToBox();
            List<Figure> result = box.ShowEnvelopeFigures();
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(result[i].Material.MaterialType, MaterialTypes.Envelope);
            }
        }

        /// <summary>
        /// Test method on save and read all figures by XmlReader
        /// </summary>
        [TestMethod]
        public void SaveAndReadAllFiguresByXmlWriterAndXmlReaderTest()
        {
            box.ClearBox();
            AddFiguresToBox();
            box.SaveFiguresByXmlWriter(SaveModes.All, "allFiguresXml.xml");
            box.ReadFiguresByXmlReader("allFiguresXml.xml");
            int count = figures.Count();
            int resultCount = box.ShowQuantity();
            Assert.AreEqual(count, resultCount);
        }

        /// <summary>
        /// Test method on save and read all figures by StreamReader
        /// </summary>
        [TestMethod]
        public void SaveAndReadAllFiguresByXmlWriterAndStreamReaderTest()
        {
            box.ClearBox();
            AddFiguresToBox();
            box.SaveFiguresByStreamWriter(SaveModes.All, "allFiguresStream.xml");
            box.ReadFiguresByStreamReader("allFiguresStream.xml");
            int count = figures.Count();
            int resultCount = box.ShowQuantity();
            Assert.AreEqual(count, resultCount);
        }
        /// <summary>
        /// Test method for paint figures
        /// </summary>
        [TestMethod]
        public void PaintFiguresTest()
        {

            bool isEqual = false;
            foreach(var figure in figures)
            {
                if(figure.Material.MaterialType == MaterialTypes.Paper)
                    figure.Material.Paint(Colors.Red);
            }

            for(int i = 0; i < figures.Count; i++)
            {
                isEqual = figures[i].Material.Color == colors[i] ? true : false;
            }
            Assert.IsTrue(isEqual);
        }

        /// <summary>
        /// Helper for add testable collection to Box
        /// </summary>
        private void AddFiguresToBox()
        {
            foreach (Figure figure in figures)
            {
                box.AddFigure(figure);
            }
        }
    }
}
