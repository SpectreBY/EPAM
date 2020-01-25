using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Task6ORM.Interfaces;
using Task6ORM.Models;
using Task6Library;

namespace Task6ORM
{
    /// <summary>
    /// Repository class which represents realization of CRUD queries for Exams table
    /// </summary>
    public class ExamsRepository : BaseRepository
    {
        /// <summary>
        /// Constructor which inherits parameters connectionString and dbContext from the base repository
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbContext"></param>
        public ExamsRepository(string connectionString, DbContext dbContext) : base(connectionString, dbContext)
        {}

        /// <summary>
        /// Method for delete exam by id value from the database
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
                        query.CommandText = SqlQueriesHelper.FormDeleteQuery(typeof(Exam), id);
                        query.Connection.Open();
                        query.ExecuteNonQuery();
                        query.Connection.Close();
                        return true;
                    }
                    catch(Exception ex)
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Method for get all of exams from the database
        /// </summary>
        /// <returns></returns>
        public override List<BaseModel> GetAll()
        {
            List<BaseModel> exams = new List<BaseModel>();
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormSelectQuery(typeof(Exam));
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

        /// <summary>
        /// Method for get exam by id value from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override BaseModel GetById(int id)
        {
            Exam exam = null;
            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = SqlQueriesHelper.FormSelectByIdQuery(typeof(Exam), id);

                    query.Connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            exam = new Exam()
                            {
                                Id = (int)reader["Id"],
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
