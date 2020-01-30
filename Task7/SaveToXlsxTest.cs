using System;
using Task7ORM;
using Task7ORM.Models;
using Task7ORM.DTO;
using Task7Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Task7
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
        private const string connectionString = @"Data Source=(local);Initial Catalog=Task7DB;Integrated Security=True";

        /// <summary>
        /// Object for access to repositories
        /// </summary>
        private DbContext dbContext = DbContext.GetInstance(connectionString);

        /// <summary>
        /// Helper object for save date to xlsx
        /// </summary>
        private SessionHelper sessionHelper = new SessionHelper();

        /// <summary>
        /// Method for save Results Of Session By Specialities to xlsx file
        /// </summary>
        [TestMethod]
        public void SaveResultsOfSessionBySpecialitiesTest()
        {
            List<ResultsOfExam> results = dbContext.ResultsOfExamsRepository.GetAll();
            List<ResultsOfSessionBySpecialityDto> resultsOfSessions = sessionHelper.GetResultsOfSessionBySpeciality(results);
            bool isSaved = DataToExcelFileHelper.SaveResultsOfSessionBySpecialityToXLSX(resultsOfSessions);
            Assert.IsTrue(isSaved);
        }

        /// <summary>
        /// Method for save Results Of Session By Subjects to xlsx file
        /// </summary>
        [TestMethod]
        public void SaveResultsOfSessionBySubjectsTest()
        {
            List<ResultsOfExam> results = dbContext.ResultsOfExamsRepository.GetAll();
            List<ResultsOfSessionBySubjectDto> resultsOfSessions = sessionHelper.GetResultsOfSessionBySubject(results);
            bool isSaved = DataToExcelFileHelper.SaveResultsOfSessionBySubjectToXLSX(resultsOfSessions);
            Assert.IsTrue(isSaved);
        }

        /// <summary>
        /// Method for save Results Of Session By Teachers to xlsx file
        /// </summary>
        [TestMethod]
        public void SaveResultsOfSessionByTeachersTest()
        {
            List<ResultsOfExam> results = dbContext.ResultsOfExamsRepository.GetAll();
            List<ResultsOfSessionByTeacherDto> resultsOfSessions = sessionHelper.GetResultsOfSessionByTeacher(results);
            bool isSaved = DataToExcelFileHelper.SaveResultsOfSessionByTeacherToXLSX(resultsOfSessions);
            Assert.IsTrue(isSaved);
        }

    }
}
