using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM
{
    public class DbContext
    {
        private static DbContext instance;
        private string connectionString;

        private DbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public static DbContext getInstance(string connectionString)
        {
            if (instance == null)
            {
                instance = new DbContext(connectionString);
            }
            return instance;
        }

        public StudentsRepository StudentsRepository()
        {
            return new StudentsRepository(connectionString, this);
        }

        public GroupsRepository GroupsRepository()
        {
            return new GroupsRepository(connectionString, this);
        }

        public void DeployDatabase(string script)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = script;
                    query.Connection.Open();
                    query.ExecuteNonQuery();
                    query.Connection.Close();
                }
            }
        }
    }
}
