using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Task6ORM.Models;
using Task6Library;

namespace Task6ORM
{
    public class StudentsRepository : BaseRepository
    {
        public StudentsRepository(string connectionString, DbContext dbContext) : base(connectionString, dbContext)
        {}

        public override void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormDeleteQuery(typeof(Student), id);
                    query.Connection.Open();
                    query.ExecuteNonQuery();
                    query.Connection.Close();
                }
            }
        }

        public override List<BaseModel> GetAll()
        {
            List<BaseModel> students = new List<BaseModel>();
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormSelectQuery(typeof(Student));
                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                students.Add(new Student()
                                {
                                    Id = (int)reader["Id"],
                                    FullName = (string)reader["FullName"],
                                    Gender = (string)reader["Gender"],
                                    DateOfBirth = ((DateTime)reader["DateOfBirth"]).Date,
                                    Group = new Group { Id = (int)reader["GroupId"] }
                                });
                            }
                        }
                    }
                    query.Connection.Close();
                }
            }

            if (students.Any())
            {
                foreach (Student model in students)
                {
                    Group group = (Group)base.DbContext.GroupsRepository.GetById(model.Group.Id);
                    model.Group = group;
                }
            }
            return students;
        }

        public override BaseModel GetById(int id)
        {
            Student student = null;
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormSelectByIdQuery(typeof(Student), id);

                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            student = new Student()
                            {
                                Id = (int)reader["Id"],
                                FullName = (string)reader["FullName"],
                                Gender = (string)reader["Gender"],
                                DateOfBirth = (DateTime)reader["DateOfBirth"],
                                Group = new Group { Id = (int)reader["GroupId"] }
                            };
                        }
                    }
                    query.Connection.Close();
                }
            }
            if(student != null)
            {
                student.Group = (Group)base.DbContext.GroupsRepository.GetById(student.Group.Id);
            }
            return student;
        }
    }
}
