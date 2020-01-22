using System;
using Task6ORM;
using Task6SQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task6
{
    [TestClass]
    public class UnitTest1
    {
        private const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\ЛЕША\EPAM\Task6SQL\Task6Database.mdf;Integrated Security=True";
        DbContext dbContext = DbContext.getInstance(connectionString);

        [TestMethod]
        public void TestMethod1()
        {
            //var repos = dbContext.StudentsRepository();
            //repos.GetAll();
            string s = SqlQueries.GetDeployScript();
            dbContext.DeployDatabase(s);
        }
    }
}
