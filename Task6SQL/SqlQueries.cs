using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6SQL
{
    public static class SqlQueries
    {
        public const string Select     = "SELECT * FROM {0};";
        public const string SelectById = "SELECT * FROM {0} WHERE {1};"; 
        public const string Insert     = "INSERT INTO {0} ({1}) VALUES ({2});";
        public const string Update     = "UPDATE {0} SET {1};";
        public const string Delete     = "DELETE FROM {0} WHERE {1};";

        public static string GetDeployScript()
        {
            using (StreamReader sr = new StreamReader("DBDeployScript.sql")) 
            {
                string deploySql = sr.ReadToEnd();
                return deploySql;
            }
        }


    }
}
