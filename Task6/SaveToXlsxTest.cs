using System;
using Task6ORM;
using Task6ORM.Models;
using Task6Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Task6
{
    /// <summary>
    /// The unit test that represents saving data to xlsx format excel files
    /// </summary>
    [TestClass]
    public class SaveToXlsxTest
    {
        /// <summary>
        /// Connection string to access Microsoft SQL Server Database
        /// </summary>
        private const string connectionString = @"Data Source=(local);Initial Catalog=Task6DB;Integrated Security=True";

        /// <summary>
        /// Object for access to repositories
        /// </summary>
        private DbContext dbContext = DbContext.GetInstance(connectionString);

        /// <summary>
        /// Helper object for save date to xlsx
        /// </summary>
        private SessionHelper sessionHelper = new SessionHelper();

        /// <summary>
        /// Method for save total results Of sessions to xlsx file
        /// </summary>
        [TestMethod]
        public void SaveTotalResultsOfSessionsTest()
        {
            List<BaseModel> results = dbContext.ResultsOfExamsRepository.GetAll();
            List<ResultOfSessionDto> resultsOfSessions = sessionHelper.GetTotalResultsOfSessions(results);
            bool isSaved = DataToExcelFileHelper.SaveResultsToXLSX(resultsOfSessions);
            Assert.IsTrue(isSaved);
        }

        /// <summary>
        /// Method for save expelled students to xlsx file
        /// </summary>
        [TestMethod]
        public void SaveExpelledStudentsTest()
        {
            List<BaseModel> results = dbContext.ResultsOfExamsRepository.GetAll();
            List<ExpelledStudentDto> resultsOfSessions = sessionHelper.GetExpelledStudents(results);
            bool isSaved = DataToExcelFileHelper.SaveExpelledStudentsToXLSX(resultsOfSessions);
            Assert.IsTrue(isSaved);
        }
    }
}
