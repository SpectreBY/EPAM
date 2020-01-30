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
    public class GroupsRepository : IRepository<Group>
    {
        /// <summary>
        /// Field for storage database context object
        /// </summary>
        private DataContext dataContext;
        private DbContext dbContext;
        private Table<Group> table;

        /// <summary>
        /// Construtor which get dataContext parametres
        /// </summary>
        /// <param name="dataContext"></param>
        /// <param name="dbContext"></param>
        public GroupsRepository(DataContext dataContext, DbContext dbContext)
        {
            this.dataContext = dataContext;
            this.dbContext = dbContext;
            this.table = dataContext.GetTable<Group>();
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
        public bool Create(Group model)
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
        public bool Delete(Group model)
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
        public List<Group> GetAll()
        {
            List<Group> groups = table.ToList();
            List<int> specialitiesIds = groups.Select(o => o.SpecialityId).ToList();

            List<Speciality> specialities = dbContext.SpecialitiesRepository
                                                     .GetAll()
                                                     .Where(o => specialitiesIds.Contains(o.Id))
                                                     .ToList();

            foreach (Group group in groups)
            {
                Speciality speciality = specialities.FirstOrDefault(o => o.Id == group.SpecialityId);
                group.Speciality = speciality;
            }

            return groups;
        }

        /// <summary>
        /// Method for select entity from the database by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Group GetById(int id)
        {
            Group group = table.FirstOrDefault(o => o.Id == id);
            group.Speciality = dataContext.GetTable<Speciality>()
                                          .FirstOrDefault(o => o.Id == group.SpecialityId);
            return group;
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
