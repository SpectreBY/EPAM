using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6SQL
{
    public static class SqlStrings
    {
        public static string Select
        {
            get
            {
                return "SELECT * FROM {0};";
            }
        }

        public static string SelectById
        {
            get
            {
                return "SELECT * FROM {0} WHERE {1};";
            }
        }

        public static string Insert
        {
            get
            {
                return "INSERT INTO {0} ({1}) VALUES ({2});";
            }
        }

        public static string Update
        {
            get
            {
                return "UPDATE {0} SET {1};";
            }
        }

        public static string Delete
        {
            get
            {
                return "DELETE FROM {0} WHERE {1};";
            }
        }
    }
}
