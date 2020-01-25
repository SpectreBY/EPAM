using System;
using Task6ORM;
using Task6ORM.Models;
using Task6Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Task6
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class SaveToXlsxTest
    {
        private const string connectionString = @"Data Source=(local);Initial Catalog=Task6DB;Integrated Security=True";
        private DbContext dbContext;
        private SessionHelper sessionHelper;

        /// <summary>
        /// 
        /// </summary>
        public SaveToXlsxTest()
        {
            dbContext = DbContext.GetInstance(connectionString);
            sessionHelper = new SessionHelper();
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        [TestMethod]
        public void SaveExpelledStudentsTest()
        {
            List<BaseModel> results = dbContext.ResultsOfExamsRepository.GetAll();
            List<ExpelledStudentDto> resultsOfSessions = sessionHelper.GetExpelledStudents(results);
            bool isSaved = DataToExcelFileHelper.SaveExpelledStudentsToXLSX(resultsOfSessions);
            Assert.IsTrue(isSaved);
        }

        [TestMethod]
        public void GetAllStudentsTest()
        {
            dbContext.DeployDatabase();
            //List<BaseModel> results = dbContext.SessionsRepository.GetAll();
            //Assert.IsTrue(isSaved);
        }
    }
}
