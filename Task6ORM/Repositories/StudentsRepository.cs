using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Task6ORM.Models;
using Task6Library;

namespace Task6ORM
{
    /// <summary>
    /// Repository class which represents realization of CRUD queries for Student table
    /// </summary>
    public class StudentsRepository : BaseRepository
    {
        /// <summary>
        /// Constructor which inherits parameters connectionString and dbContext from the base repository
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbContext"></param>
        public StudentsRepository(string connectionString, DbContext dbContext) : base(connectionString, dbContext)
        { }

        /// <summary>
        /// Method for delete student by id value from the database
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
                        query.CommandText = SqlQueriesHelper.FormDeleteQuery(typeof(Student), id);
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
        /// Method for get all of students from the database
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Method for get student by id value from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
