using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Task6ORM.Models;
using Task6Library;

namespace Task6ORM
{
    public class SubjectsOfGroupsRepository : BaseRepository
    {
        public SubjectsOfGroupsRepository(string connectionString, DbContext dbContext) : base(connectionString, dbContext)
        { }

        public override void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormDeleteQuery(typeof(SubjectsOfGroup), id);
                    query.Connection.Open();
                    query.ExecuteNonQuery();
                    query.Connection.Close();
                }
            }
        }

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
