using System.Collections.Generic;
using System.Data.SqlClient;
using Task6ORM.Models;
using Task6Library;

namespace Task6ORM
{
    public class SessionsRepository : BaseRepository
    {
        public SessionsRepository(string connectionString, DbContext dbContext) : base(connectionString, dbContext)
        { }

        public override void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormDeleteQuery(typeof(Session), id);
                    query.Connection.Open();
                    query.ExecuteNonQuery();
                    query.Connection.Close();
                }
            }
        }

        public override List<BaseModel> GetAll()
        {
            List<BaseModel> sessions = new List<BaseModel>();
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormSelectQuery(typeof(Session));

                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                sessions.Add(new Session()
                                {
                                    Id = (int)reader["Id"],
                                    EducationPeriod = (string)reader["EducationPeriod"],
                                    Semestr = (int)reader["Semestr"]
                                });
                            }
                        }
                    }
                    query.Connection.Close();
                }
            }
            return sessions;
        }

        public override BaseModel GetById(int id)
        {
            Session session = null;

            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormSelectByIdQuery(typeof(Session), id);

                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            session = new Session()
                            {
                                Id = (int)reader["Id"],
                                EducationPeriod = (string)reader["EducationPeriod"],
                                Semestr = (int)reader["Semestr"]
                            };
                        }
                    }
                    query.Connection.Close();
                }
            }
            return session;
        }
    }
}
