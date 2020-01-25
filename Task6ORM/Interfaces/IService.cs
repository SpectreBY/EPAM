using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6ORM.Models;

namespace Task6ORM.Interfaces
{
    /// <summary>
    /// The interface that represents methods for creating an entity, updating, deleting, and selecting in the database
    /// </summary>
    interface IService
    {
        /// <summary>
        /// Method for get all of entities from the database
        /// </summary>
        /// <returns></returns>
        List<BaseModel> GetAll();

        /// <summary>
        /// Method for get entity by id value from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BaseModel GetById(int id);

        /// <summary>
        /// Method for insert entity into the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Create(BaseModel model);

        /// <summary>
        /// Method for update entity in the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(BaseModel model);

        /// <summary>
        /// Method for delete entity by id value from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// Helper method for generate unique key (id)
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        int GetUniqueKey(string tableName);
    }
}
