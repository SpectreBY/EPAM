using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6ORM.Interfaces;
using Task6ORM.Models;
using Task6Library;

namespace Task6ORM
{
    public class SubjectsRepository : BaseRepository
    {
        public SubjectsRepository(string connectionString, DbContext dbContext) : base(connectionString, dbContext)
        { }

        public override void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormDeleteQuery(typeof(Subject), id);
                    query.Connection.Open();
                    query.ExecuteNonQuery();
                    query.Connection.Close();
                }
            }
        }

        public override List<BaseModel> GetAll()
        {
            List<BaseModel> subjects = new List<BaseModel>();
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormSelectQuery(typeof(Subject));

                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                subjects.Add(new Subject()
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
            return subjects;
        }

        public override BaseModel GetById(int id)
        {
            Subject subject = null;

            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormSelectByIdQuery(typeof(Subject), id);

                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            subject = new Subject()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"]
                            };
                        }
                    }
                    query.Connection.Close();
                }
            }
            return subject;
        }
    }
}
