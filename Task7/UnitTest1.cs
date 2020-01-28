using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Linq;
using Task7ORM.Models;
using Task7ORM.Interfaces;
using Task7ORM;

namespace Task7
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Connection string to access Microsoft SQL Server Database
        /// </summary>
        private const string connectionString = @"Data Source=(local);Initial Catalog=Task6DB;Integrated Security=True";
        private DbContext dbContext = DbContext.GetInstance(connectionString);

        [TestMethod]
        public void TestMethod1()
        {

            var r = dbContext.ExamRepository.GetAll();


        }
    }
}
