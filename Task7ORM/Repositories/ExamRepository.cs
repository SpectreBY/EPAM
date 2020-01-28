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
    public class ExamRepository : IRepository<Exam>
    {
        /// <summary>
        /// Field for storage database context object
        /// </summary>
        private DataContext dataContext;
        private Table<Exam> table;

        /// <summary>
        /// Construtor which get dataContext parametres
        /// </summary>
        /// <param name="dataContext"></param>
        public ExamRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
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
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Exam> GetAll()
        {
            List<Exam> exams = table.ToList();
            List<int> sessionsIds = exams.Select(o => o.SessionId).ToList();
            List<Session> sessions = dataContext.GetTable<Session>().Where(o => sessionsIds.Contains(o.Id)).ToList();
            foreach(Exam exam in exams)
            {
                Session session = sessions.Where(o => o.Id == exam.SessionId).FirstOrDefault();
                exam.Session = session;
            }
            return table.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Exam GetById(int id)
        {
            return table.Where(o => o.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 
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

        /// <summary>
        /// 
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
    }
}
