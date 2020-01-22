using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6ORM.Interfaces;
using Task6ORM.Models;
using Task6SQL;

namespace Task6ORM
{
    public class GroupsRepository : IRepository<Group>
    {
        private string connectionString;
        private DbContext dbContext;

        public GroupsRepository(string connectionString, DbContext dbContext)
        {
            this.connectionString = connectionString;
            this.dbContext = dbContext;
        }

        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }

        public void Create(Group model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public Group GetById(int id)
        {
            Group group = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (var query = new SqlCommand())
                {
                    StringBuilder builder = new StringBuilder();
                    string tableName = string.Format("{0}s", nameof(Group));
                    string conditions = string.Format("Id = {0}", id);
                    string queryString = string.Format(SqlQueries.SelectById, tableName, conditions);

                    query.Connection = connection;
                    query.CommandText = queryString;

                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            group = new Group()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Course = (int)reader["Course"]
                            };
                        }
                    }
                    query.Connection.Close();
                }
            }
            return group;
        }

        public void Update(Group model)
        {
            throw new NotImplementedException();
        }
    }
}
