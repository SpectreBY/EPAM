using System;
using Task6ORM;
using Task6ORM.Models;
using Task6SQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task6
{
    [TestClass]
    public class UnitTest1
    {
        private const string connectionString = @"Data Source=User-pc;Initial Catalog=databasename;Integrated Security=True";
        DbContext dbContext;

        public UnitTest1()
        {
            dbContext = DbContext.GetInstance(connectionString);
        }

        [TestMethod]
        public void TestMethod1()
        {
            //var res = dbContext.ResultsOfSessionRepository.GetById(0);
            dbContext.DeployDatabase(SqlQueries.GetDeployScript());
        }
    }
}
