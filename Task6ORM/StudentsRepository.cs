using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6ORM.Enums;
using Task6ORM.Interfaces;
using Task6ORM.Models;
using Task6SQL;

namespace Task6ORM
{
    public class StudentsRepository : IRepository<Student>
    {
        private string connectionString;
        private DbContext dbContext;

        public StudentsRepository(string connectionString, DbContext dbContext)
        {
            this.connectionString = connectionString;
            this.dbContext = dbContext;
        }


        public void Create(Student model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (var query = new SqlCommand())
                {
                    string tableName = string.Format("{0}s", nameof(Student));
                    string queryString = string.Format(SqlQueries.Select, tableName);

                    query.Connection = connection;
                    query.CommandText = queryString;

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
                                                 Gender = (int)reader["Gender"] == 0 ? Genders.Male : Genders.Female,
                                                 DateOfBirth = ((DateTime)reader["DateOfBirth"]).Date,
                                                 Group = new Group { Id = (int)reader["GroupId"] }
                                             });
                            }
                        }
                    }
                    query.Connection.Close();
                }
            }

            if(students.Any())
            {
                foreach(Student model in students)
                {
                    Group group = dbContext.GroupsRepository().GetById(model.Group.Id);
                    model.Group = group;
                }
            }
            return students;
        }

        public Student GetById(int id)
        {
            Student student = null;




            Group group = dbContext.GroupsRepository().GetById(student.Group.Id);
            student.Group = group;
            return student;
        }

        public void Update(Student model)
        {
            throw new NotImplementedException();
        }
    }
}
