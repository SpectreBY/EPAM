using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using Task7ORM.Interfaces;
using Task7ORM.Models;

namespace Task7ORM
{
    /// <summary>
    /// Repository class which represents realization of CRUD queries for Exams table
    /// </summary>
    public class ResultsOfExamsRepository : IRepository<ResultsOfExam>
    {
        /// <summary>
        /// Field for storage database context object
        /// </summary>
        private DataContext dataContext;
        private DbContext dbContext;
        private Table<ResultsOfExam> table;

        /// <summary>
        /// Construtor which get dataContext parametres
        /// </summary>
        /// <param name="dataContext"></param>
        /// <param name="dbContext"></param>
        public ResultsOfExamsRepository(DataContext dataContext, DbContext dbContext)
        {
            this.dataContext = dataContext;
            this.dbContext = dbContext;
            this.table = dataContext.GetTable<ResultsOfExam>();
        }

        /// <summary>
        /// Property for access to dbContext field value
        /// </summary>
        public DataContext DataContext
        {
            get
            {
                return dataContext;
            }
        }

        /// <summary>
        /// Property for access to dbContext field value
        /// </summary>
        public DbContext DbContext
        {
            get
            {
                return dbContext;
            }
        }

        /// <summary>
        /// Method for insert entity into the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Create(ResultsOfExam model)
        {
            try
            {
                model.Id = GetUniqueKey();
                table.InsertOnSubmit(model);
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }        
        }

        /// <summary>
        /// Method for delete entity from the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(ResultsOfExam model)
        {
            try
            {
                table.DeleteOnSubmit(model);
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for select all entities from the database
        /// </summary>
        /// <returns></returns>
        public List<ResultsOfExam> GetAll()
        {
            List<ResultsOfExam> resultsOfExams = table.ToList();
            List<int> examsIds = resultsOfExams.Select(o => o.ExamId).ToList();
            List<int> studentsIds = resultsOfExams.Select(o => o.StudentId).ToList();

            List<Exam> exams = dbContext.ExamsRepository
                                        .GetAll()
                                        .Where(o => examsIds.Contains(o.Id))
                                        .ToList();

            List<Student> students = dbContext.StudentsRepository
                                              .GetAll()
                                              .Where(o => studentsIds.Contains(o.Id))
                                              .ToList();

            foreach (ResultsOfExam resultsOfExam in resultsOfExams)
            {
                Exam exam = exams.FirstOrDefault(o => o.Id == resultsOfExam.ExamId);
                Student student = students.FirstOrDefault(o => o.Id == resultsOfExam.StudentId);
                resultsOfExam.Exam = exam;
                resultsOfExam.Student = student;
            }

            return resultsOfExams;
        }

        /// <summary>
        /// Method for select entity from the database by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResultsOfExam GetById(int id)
        {
            ResultsOfExam resultsOfExam = table.FirstOrDefault(o => o.Id == id);
            resultsOfExam.Exam = dataContext.GetTable<Exam>()
                                            .FirstOrDefault(o => o.Id == resultsOfExam.ExamId);
            resultsOfExam.Student = dataContext.GetTable<Student>()
                                               .FirstOrDefault(o => o.Id == resultsOfExam.StudentId);
            return resultsOfExam;
        }

        /// <summary>
        /// Method for update entity in the database
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            try
            {
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Helper method for generate unique key (id)
        /// </summary>
        /// <returns></returns>
        public int GetUniqueKey()
        {
            List<int> keys = table.Select(o => o.Id).ToList();
            int newId = 0;
            while (true)
            {
                if (keys.Contains(newId))
                {
                    newId++;
                }
                else
                {
                    break;
                }
            }
            return newId;
        }
    }
}
