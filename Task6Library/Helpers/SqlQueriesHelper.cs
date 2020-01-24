using System;
using System.IO;

namespace Task6Library
{
    public static class SqlQueriesHelper
    {
        public const string Select     = "SELECT {0} FROM {1};";
        public const string SelectById = "SELECT {0} FROM {1} WHERE {2};"; 
        public const string Insert     = "INSERT INTO {0} ({1}) VALUES ({2});";
        public const string Update     = "UPDATE {0} SET {1} WHERE {2}={3};";
        public const string Delete     = "DELETE FROM {0} WHERE {1}={2};";

        public static string GetDeployScript()
        {
            using (StreamReader sr = new StreamReader("DBDeployScript.sql")) 
            {
                string deploySql = sr.ReadToEnd();
                return deploySql;
            }
        }

        public static string GetFillDataScript()
        {
            using (StreamReader sr = new StreamReader("DBFillDataScript.sql"))
            {
                string fillSql = sr.ReadToEnd();
                return fillSql;
            }
        }

        public static string FormSelectQuery(Type table)
        {
            string tableName = string.Format("{0}s", table.Name);
            string queryString = string.Format(Select, "*", tableName);
            return queryString;
        }

        public static string FormSelectByIdQuery(Type table, int id)
        {
            string tableName = string.Format("{0}s", table.Name);
            string conditions = string.Format("Id = {0}", id);
            string queryString = string.Format(SelectById, "*", tableName, conditions);
            return queryString;
        }

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
