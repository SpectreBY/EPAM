using System.Collections.Generic;
using System.Data.SqlClient;
using Task6ORM.Models;
using Task6Library;
using System;

namespace Task6ORM
{
    /// <summary>
    /// Repository class which represents realization of CRUD queries for Session table
    /// </summary>
    public class SessionsRepository : BaseRepository
    {
        /// <summary>
        /// Constructor which inherits parameters connectionString and dbContext from the base repository
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbContext"></param>
        public SessionsRepository(string connectionString, DbContext dbContext) : base(connectionString, dbContext)
        { }

        /// <summary>
        /// Method for delete session by id value from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    try
                    {
                        query.Connection = connection;
                        query.CommandText = SqlQueriesHelper.FormDeleteQuery(typeof(Session), id);
                        query.Connection.Open();
                        query.ExecuteNonQuery();
                        query.Connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Method for get all of sessions from the database
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Method for get session by id value from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
