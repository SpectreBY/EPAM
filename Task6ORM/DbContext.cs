using System;
using System.Collections.Generic;
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
    }
}
