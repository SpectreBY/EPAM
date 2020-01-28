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
    public class SubjectsOfGroupRepository : IRepository<SubjectsOfGroup>
    {
        /// <summary>
        /// Field for storage database context object
        /// </summary>
        private DataContext dataContext;
        private Table<SubjectsOfGroup> table;

        /// <summary>
        /// Construtor which get dataContext parametres
        /// </summary>
        /// <param name="dataContext"></param>
        public SubjectsOfGroupRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
            this.table = dataContext.GetTable<SubjectsOfGroup>();
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
        public bool Create(SubjectsOfGroup model)
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
        public bool Delete(SubjectsOfGroup model)
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
        public List<SubjectsOfGroup> GetAll()
        {
            return table.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SubjectsOfGroup GetById(int id)
        {
            return table.Where(o => o.Id == id).FirstOrDefault();
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
    }
}
