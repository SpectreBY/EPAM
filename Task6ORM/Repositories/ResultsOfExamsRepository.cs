using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Task6ORM.Interfaces;
using Task6ORM.Models;
using Task6Library;

namespace Task6ORM
{
    public class ResultsOfExamsRepository : BaseRepository
    {
        public ResultsOfExamsRepository(string connectionString, DbContext dbContext) : base(connectionString, dbContext)
        {}

        public override void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormDeleteQuery(typeof(ResultsOfExam), id);
                    query.Connection.Open();
                    query.ExecuteNonQuery();
                    query.Connection.Close();
                }
            }
        }

        public override List<BaseModel> GetAll()
        {
            List<BaseModel> resultsOfSession = new List<BaseModel>();
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormSelectQuery(typeof(ResultsOfExam));
                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                resultsOfSession.Add(new ResultsOfExam()
                                {
                                    Id = (int)reader["Id"],
                                    Student = new Student { Id = (int)reader["StudentId"] },
                                    Exam = new Exam { Id = (int)reader["ExamId"] },
                                    Result = (int)reader["Result"]
                                });
                            }
                        }
                    }
                    query.Connection.Close();
                }
            }

            if (resultsOfSession.Any())
            {
                foreach (ResultsOfExam model in resultsOfSession)
                {
                    Student student = (Student)base.DbContext.StudentsRepository.GetById(model.Student.Id);
                    Exam exam = (Exam)base.DbContext.ExamsRepository.GetById(model.Exam.Id);
                    model.Student = student;
                    model.Exam = exam;
                }
            }
            return resultsOfSession;
        }

        public override BaseModel GetById(int id)
        {
            ResultsOfExam results = null;
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormSelectByIdQuery(typeof(ResultsOfExam), id);

                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            results = new ResultsOfExam()
                            {
                                Id = (int)reader["Id"],
                                Student = new Student { Id = (int)reader["StudentId"] },
                                Exam = new Exam { Id = (int)reader["ExamId"] },
                                Result = (int)reader["Result"]
                            };
                        }
                    }
                    query.Connection.Close();
                }
            }
            if(results != null)
            {
                Student student = (Student)base.DbContext.StudentsRepository.GetById(results.Student.Id);
                Exam exam = (Exam)base.DbContext.ExamsRepository.GetById(results.Exam.Id);
                results.Student = student;
                results.Exam = exam;
            }
            return results;
        }
    }
}
