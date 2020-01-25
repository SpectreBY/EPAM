using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Task6ORM.Models;
using Task6Library;
using System;

namespace Task6ORM
{
    /// <summary>
    /// Repository class which represents realization of CRUD queries for SubjectsOfGroup table
    /// </summary>
    public class SubjectsOfGroupsRepository : BaseRepository
    {
        /// <summary>
        /// Constructor which inherits parameters connectionString and dbContext from the base repository
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbContext"></param>
        public SubjectsOfGroupsRepository(string connectionString, DbContext dbContext) : base(connectionString, dbContext)
        { }

        /// <summary>
        /// Method for delete subjects of group by id value from the database
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
                        query.CommandText = SqlQueriesHelper.FormDeleteQuery(typeof(SubjectsOfGroup), id);
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
        /// Method for get all of subjects of groups from the database
        /// </summary>
        /// <returns></returns>
        public override List<BaseModel> GetAll()
        {
            List<BaseModel> subjectsOfGroups = new List<BaseModel>();
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormSelectQuery(typeof(SubjectsOfGroup));

                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                subjectsOfGroups.Add(new SubjectsOfGroup()
                                {
                                    Id = (int)reader["Id"],
                                    Group = new Group { Id = (int)reader["GroupId"] },
                                    Subject = new Subject { Id = (int)reader["SubjectId"] }
                                });
                            }
                        }
                    }
                    query.Connection.Close();
                }
            }
            if (subjectsOfGroups.Any())
            {
                foreach (SubjectsOfGroup model in subjectsOfGroups)
                {
                    Group group = (Group)base.DbContext.GroupsRepository.GetById(model.Group.Id);
                    Subject subject = (Subject)base.DbContext.SubjectsRepository.GetById(model.Subject.Id);
                    model.Group = group;
                    model.Subject = subject;
                }
            }
            return subjectsOfGroups;
        }

        /// <summary>
        /// Method for get subjects of group by id value from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override BaseModel GetById(int id)
        {
            SubjectsOfGroup subjectsOfGroup = null;

            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormSelectByIdQuery(typeof(SubjectsOfGroup), id);

                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            subjectsOfGroup = new SubjectsOfGroup()
                            {
                                Id = (int)reader["Id"],
                                Group = new Group { Id = (int)reader["GroupId"] },
                                Subject = new Subject { Id = (int)reader["SubjectId"] }
                            };
                        }
                    }
                    query.Connection.Close();
                }
            }
            if (subjectsOfGroup != null)
            {
                Group group = (Group)base.DbContext.GroupsRepository.GetById(subjectsOfGroup.Group.Id);
                Subject subject = (Subject)base.DbContext.SubjectsRepository.GetById(subjectsOfGroup.Subject.Id);
                subjectsOfGroup.Group = group;
                subjectsOfGroup.Subject = subject;
            }
            return subjectsOfGroup;
        }
    }
}
