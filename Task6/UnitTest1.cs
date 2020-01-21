using System;
using Task6ORM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task6
{
    [TestClass]
    public class UnitTest1
    {
        private const string connectionString = "Data Source=user-pc;Initial Catalog=Task6Database;Integrated Security=True";
        DbContext dbContext = DbContext.getInstance(connectionString);

        [TestMethod]
        public void TestMethod1()
        {
            var repos = dbContext.StudentsRepository();
            repos.GetAll();
        }
    }
}
