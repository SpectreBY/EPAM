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
    public class ExamsRepository : IRepository<Exam>
    {
        /// <summary>
        /// Field for storage database context object
        /// </summary>
        private DataContext dataContext;
        private DbContext dbContext;
        private Table<Exam> table;

        /// <summary>
        /// Construtor which get dataContext parametres
        /// </summary>
        /// <param name="dataContext"></param>
        /// <param name="dbContext"></param>
        public ExamsRepository(DataContext dataContext, DbContext dbContext)
        {
            this.dataContext = dataContext;
            this.dbContext = dbContext;
            this.table = dataContext.GetTable<Exam>();
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
        public bool Create(Exam model)
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
        public bool Delete(Exam model)
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
        public List<Exam> GetAll()
        {
            List<Exam> exams = table.ToList();
            List<int> sessionsIds = exams.Select(o => o.SessionId).ToList();
            List<int> teachersIds = exams.Select(o => o.TeacherId).ToList();
            List<int> subjectsOfGroupsIds = exams.Select(o => o.SubjectsOfGroupId).ToList();

            List<Session> sessions = dbContext.SessionsRepository
                                              .GetAll()
                                              .Where(o => sessionsIds.Contains(o.Id))
                                              .ToList();

            List<Teacher> teachers = dbContext.TeachersRepository
                                              .GetAll()
                                              .Where(o => teachersIds.Contains(o.Id))
                                              .ToList();

            List<SubjectsOfGroup> subjectsOfGroups = dbContext.SubjectsOfGroupsRepository
                                                              .GetAll()
                                                              .Where(o => subjectsOfGroupsIds.Contains(o.Id))
                                                              .ToList();
            foreach(Exam exam in exams)
            {
                Session session = sessions.FirstOrDefault(o => o.Id == exam.SessionId);
                Teacher teacher = teachers.FirstOrDefault(o => o.Id == exam.TeacherId);
                SubjectsOfGroup subjectsOfGroup = subjectsOfGroups.FirstOrDefault(o => o.Id == exam.SubjectsOfGroupId);
                exam.Session = session;
                exam.Teacher = teacher;
                exam.SubjectsOfGroup = subjectsOfGroup;
            }

            return exams;
        }

        /// <summary>
        /// Method for select entity from the database by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Exam GetById(int id)
        {
            Exam exam = table.FirstOrDefault(o => o.Id == id);
            exam.Session = dataContext.GetTable<Session>()
                                      .FirstOrDefault(o => o.Id == exam.SessionId);
            exam.Teacher = dataContext.GetTable<Teacher>()
                                      .FirstOrDefault(o => o.Id == exam.TeacherId);
            exam.SubjectsOfGroup = dataContext.GetTable<SubjectsOfGroup>()
                                              .FirstOrDefault(o => o.Id == exam.SubjectsOfGroupId);
            return exam;
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
