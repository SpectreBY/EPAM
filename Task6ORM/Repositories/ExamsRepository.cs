using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Task6ORM.Interfaces;
using Task6ORM.Models;
using Task6SQL;

namespace Task6ORM
{
    public class ExamsRepository : BaseRepository
    {
        public ExamsRepository(string connectionString, DbContext dbContext) : base(connectionString, dbContext)
        {}

        public override void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueries.FormDeleteQuery(typeof(Exam), id);
                    query.Connection.Open();
                    query.ExecuteNonQuery();
                    query.Connection.Close();
                }
            }
        }

        public override List<BaseModel> GetAll()
        {
            List<BaseModel> exams = new List<BaseModel>();
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueries.FormSelectQuery(typeof(Exam));
                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                exams.Add(new Exam()
                                {
                                    Id = (int)reader["Id"],
                                    ExamType = (string)reader["ExamType"],
                                    Session = new Session { Id = (int)reader["SessionId"] },
                                    ExamDate = ((DateTime)reader["ExamDate"]).Date,
                                    SubjectsOfGroup = new SubjectsOfGroup { Id = (int)reader["SubjectsOfGroupId"] }
                                });
                            }
                        }
                    }
                    query.Connection.Close();
                }
            }

            if (exams.Any())
            {
                foreach (Exam model in exams)
                {
                    Session session = (Session)base.DbContext.SessionsRepository.GetById(model.Session.Id);
                    SubjectsOfGroup subjectsOfGroup = (SubjectsOfGroup)base.DbContext.SubjectsOfGroupsRepository.GetById(model.SubjectsOfGroup.Id);
                    model.Session = session;
                    model.SubjectsOfGroup = subjectsOfGroup;
                }
            }
            return exams;
        }

        public override BaseModel GetById(int id)
        {
            Exam exam = null;
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueries.FormSelectByIdQuery(typeof(Exam), id);

                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            exam = new Exam()
                            {
                                Id = (int)reader["Id"],
                                ExamType = (string)reader["ExamType"],
                                Session = new Session { Id = (int)reader["SessionId"] },
                                ExamDate = ((DateTime)reader["ExamDate"]).Date,
                                SubjectsOfGroup = new SubjectsOfGroup { Id = (int)reader["SubjectsOfGroupId"] }
                            };
                        }
                    }
                    query.Connection.Close();
                }
            }
            if(exam != null)
            {
                Session session = (Session)base.DbContext.SessionsRepository.GetById(exam.Session.Id);
                SubjectsOfGroup subjectsOfGroup = (SubjectsOfGroup)base.DbContext.SubjectsOfGroupsRepository.GetById(exam.SubjectsOfGroup.Id);
                exam.Session = session;
                exam.SubjectsOfGroup = subjectsOfGroup;
            }
            return exam;
        }
    }
}
