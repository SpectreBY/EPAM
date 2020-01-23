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
    public class GroupsRepository : BaseRepository
    {
        public GroupsRepository(string connectionString, DbContext dbContext) : base(connectionString, dbContext)
        { }

        public override void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueries.FormDeleteQuery(typeof(Group), id);
                    query.Connection.Open();
                    query.ExecuteNonQuery();
                    query.Connection.Close();
                }
            }
        }

        public override List<BaseModel> GetAll()
        {
            List<BaseModel> groups = new List<BaseModel>();
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueries.FormSelectQuery(typeof(Group));

                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                groups.Add(new Group()
                                {
                                    Id = (int)reader["Id"],
                                    Name = (string)reader["Name"]
                                });
                            }
                        }
                    }
                    query.Connection.Close();
                }
            }
            return groups;
        }

        public override BaseModel GetById(int id)
        {
            Group group = null;

            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueries.FormSelectByIdQuery(typeof(Group), id);

                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            group = new Group()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"]
                            };
                        }
                    }
                    query.Connection.Close();
                }
            }
            return group;
        }
    }
}
