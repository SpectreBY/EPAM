using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Task6ORM.Interfaces;
using Task6ORM.Models;
using Task6Library;
using System;

namespace Task6ORM
{
    /// <summary>
    /// Abstract repository class which represents base realization of CRUD queries
    /// </summary>
    public abstract class BaseRepository : IService
    {
        /// <summary>
        /// Field for storage connection string for get access to the database
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Field for storage database context object
        /// </summary>
        private DbContext dbContext;

        /// <summary>
        /// Construtor which get connectionString and dbContext parametres
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbContext"></param>
        public BaseRepository(string connectionString, DbContext dbContext)
        {
            this.connectionString = connectionString;
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Property for access to connectionString field value
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return connectionString;
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
        public virtual bool Create(BaseModel model)
        {
            StringBuilder columns = new StringBuilder();
            StringBuilder columnValues = new StringBuilder();

            string tableName = model.GetType().Name.Insert(model.GetType().Name.Length, "s");

            var properties = model.GetType()
                                  .GetProperties()
                                  .Where(o => !o.Name.Equals("Id"));
            var propertyId = model.GetType().GetProperty("Id");

            foreach (var prop in properties)
            {
                if (prop.PropertyType.BaseType.Name.Equals("BaseModel"))
                {
                    columns.Append(string.Format("{0}Id,", prop.Name));
                }
                else
                {
                    columns.Append(string.Format("{0},", prop.Name));
                }
            }
            string columnsLine = columns.ToString().Substring(0, columns.ToString().Length - 1);
            foreach (var prop in properties)
            {
                if (prop.PropertyType.BaseType.Name.Equals("BaseModel"))
                {
                    BaseModel obj = (BaseModel)prop.GetValue(model);
                    columnValues.Append(string.Format("'{0}',", obj.Id));
                }
                else
                {
                    columnValues.Append(string.Format("'{0}',", prop.GetValue(model)));
                }
            }
            string columnValuesLine = columnValues.ToString().Substring(0, columnValues.ToString().Length - 1);

            int newId = GetUniqueKey(tableName);
            columnsLine = columnsLine.Insert(0, string.Format("{0}, ", propertyId.Name));
            columnValuesLine = columnValuesLine.Insert(0, string.Format("'{0}', ", newId));

            string querySql = string.Format(SqlQueriesHelper.Insert, tableName, columnsLine, columnValuesLine);
 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (var query = new SqlCommand())
                {
                    try
                    {
                        query.Connection = connection;
                        query.CommandText = querySql;
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
        /// Method for update entity in the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual bool Update(BaseModel model)
        {
            StringBuilder columns = new StringBuilder();

            string tableName = model.GetType().Name.Insert(model.GetType().Name.Length, "s");

            var properties = model.GetType()
                                  .GetProperties()
                                  .Where(o => !o.Name.Equals("Id"));
            var propertyId = model.GetType().GetProperty("Id");

            foreach (var prop in properties)
            {
                if (prop.PropertyType.BaseType.Name.Equals("BaseModel"))
                {
                    BaseModel obj = (BaseModel)prop.GetValue(model);
                    columns.Append(string.Format("{0}Id='{1}', ", prop.Name, obj.Id));
                }
                else
                {
                    columns.Append(string.Format("{0}='{1}', ", prop.Name, prop.GetValue(model)));
                }
            }

            string columnsLine = columns.ToString().Substring(0, columns.ToString().Length - 2);

            string querySql = string.Format(SqlQueriesHelper.Update, tableName, columnsLine, propertyId.Name, propertyId.GetValue(model));

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (var query = new SqlCommand())
                {
                    try
                    {
                        query.Connection = connection;
                        query.CommandText = querySql;
                        query.Connection.Open();
                        query.ExecuteNonQuery();
                        query.Connection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Helper method for generate unique key (id)
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int GetUniqueKey(string tableName)
        {
            List<int> keys = new List<int>();
            string querySqlSelect = string.Format(SqlQueriesHelper.Select, tableName.Insert(tableName.Length, ".Id"), tableName);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = querySqlSelect;

                    query.Connection.Open();
                    SqlDataReader reader = query.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            keys.Add((int)reader["Id"]);
                        }
                    }
                    query.Connection.Close();
                }
            }
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
        /// Abstract method for delete entity by id value from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract bool Delete(int id);

        /// <summary>
        /// Abstract method for get all of entities from the database
        /// </summary>
        /// <returns></returns>
        public abstract List<BaseModel> GetAll();

        /// <summary>
        /// Abstract method for get entity by id value from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract BaseModel GetById(int id);
    }
}
