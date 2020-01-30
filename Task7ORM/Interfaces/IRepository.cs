using System.Collections.Generic;

namespace Task7ORM.Interfaces
{
    /// <summary>
    /// The interface that represents methods for creating an entity, updating, deleting, and selecting in the database
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Method for get all of entities from the database
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Method for get entity by id value from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Method for insert entity into the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Create(T model);

        /// <summary>
        /// Method for update entity in the database
        /// </summary>
        /// <returns></returns>
        bool Update();

        /// <summary>
        /// Method for delete entity by id value from the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Delete(T model);

        /// <summary>
        /// Helper method for generate unique key (id)
        /// </summary>
        /// <returns></returns>
        int GetUniqueKey();
    }
}
