using System;
using Task6ORM;
using Task6ORM.Models;
using Task6Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Task6
{
    [TestClass]
    public class SaveToXlsxTest
    {
        private const string connectionString = @"Data Source=User-pc;Initial Catalog=Task6Database;Integrated Security=True";
        DbContext dbContext;

        public SaveToXlsxTest()
        {
            dbContext = DbContext.GetInstance(connectionString);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var res = dbContext.ResultsOfExamsRepository.GetAll();
            SessionHelper sessionHelper = new SessionHelper();
            var r = sessionHelper.GetTotalResultsOfSessions(res);
            var v = sessionHelper.GetExpelledStudents(res);
            bool rrr = DataToExcelFileHelper.SaveResultsToXLSX(r);
            bool rrr2 = DataToExcelFileHelper.SaveExpelledStudentsToXLSX(v);
        }
    }
}
