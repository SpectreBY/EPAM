using System;
using System.IO;

namespace Task6Library
{
    /// <summary>
    /// Helper static class which represents functionality for form sql query strings
    /// </summary>
    public static class SqlQueriesHelper
    {
        /// <summary>
        /// Constant filed which storage string of query "SELECT"
        /// </summary>
        public const string Select     = "SELECT {0} FROM {1};";

        /// <summary>
        /// Constant filed which storage string of query "SELECT with condition"
        /// </summary>
        public const string SelectById = "SELECT {0} FROM {1} WHERE {2};";

        /// <summary>
        /// Constant filed which storage string of query "INSERT"
        /// </summary>
        public const string Insert     = "INSERT INTO {0} ({1}) VALUES ({2});";

        /// <summary>
        /// Constant filed which storage string of query "UPDATE"
        /// </summary>
        public const string Update     = "UPDATE {0} SET {1} WHERE {2}={3};";

        /// <summary>
        /// Constant filed which storage string of query "DELETE"
        /// </summary>
        public const string Delete     = "DELETE FROM {0} WHERE {1}={2};";

        /// <summary>
        /// Method which return sql query string for deploy database
        /// </summary>
        /// <returns></returns>
        public static string GetDeployScript()
        {
            using (StreamReader sr = new StreamReader("../../../Task6Library/Scripts/DBDeployScript.sql")) 
            {
                string deploySql = sr.ReadToEnd();
                return deploySql;
            }
        }

        /// <summary>
        /// Method which return sql query string for fill deployed database
        /// </summary>
        /// <returns></returns>
        public static string GetFillDataScript()
        {
            using (StreamReader sr = new StreamReader("../../../Task6Library/Scripts/DBFillDataScript.sql"))
            {
                string fillSql = sr.ReadToEnd();
                return fillSql;
            }
        }

        /// <summary>
        /// Method for generating a query "SELECT" based on the name of the entity
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string FormSelectQuery(Type table)
        {
            string tableName = string.Format("{0}s", table.Name);
            string queryString = string.Format(Select, "*", tableName);
            return queryString;
        }

        /// <summary>
        /// Method for generating a query "SELECT" based on the name of the entity and id value
        /// </summary>
        /// <param name="table"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string FormSelectByIdQuery(Type table, int id)
        {
            string tableName = string.Format("{0}s", table.Name);
            string conditions = string.Format("Id = {0}", id);
            string queryString = string.Format(SelectById, "*", tableName, conditions);
            return queryString;
        }

        /// <summary>
        /// Method for generating a query "DELETE" based on the name of the entity and id value
        /// </summary>
        /// <param name="table"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string FormDeleteQuery(Type table, int id)
        {
            string tableName = string.Format("{0}s", table.Name);
            var propertyId = table.GetProperty("Id");
            string propertyIdName = propertyId.Name;
            string queryString = string.Format(Delete, tableName, propertyIdName, id);
            return queryString;
        }
    }
}
