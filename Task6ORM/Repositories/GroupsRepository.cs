using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Task6ORM.Models;
using Task6Library;

namespace Task6ORM
{
    /// <summary>
    /// Repository class which represents realization of CRUD queries for Groups table
    /// </summary>
    public class GroupsRepository : BaseRepository
    {
        /// <summary>
        /// Constructor which inherits parameters connectionString and dbContext from the base repository
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbContext"></param>
        public GroupsRepository(string connectionString, DbContext dbContext) : base(connectionString, dbContext)
        { }

        /// <summary>
        /// Method for delete group by id value from the database
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
                        query.CommandText = SqlQueriesHelper.FormDeleteQuery(typeof(Group), id);
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
        /// Method for get all of groups from the database
        /// </summary>
        /// <returns></returns>
        public override List<BaseModel> GetAll()
        {
            List<BaseModel> groups = new List<BaseModel>();
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormSelectQuery(typeof(Group));

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

        /// <summary>
        /// Method for get group by id value from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override BaseModel GetById(int id)
        {
            Group group = null;

            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormSelectByIdQuery(typeof(Group), id);

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
