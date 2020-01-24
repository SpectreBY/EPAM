using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Task6ORM.Interfaces;
using Task6ORM.Models;
using Task6Library;

namespace Task6ORM
{
    public abstract class BaseRepository : IService
    {
        private string connectionString;
        private DbContext dbContext;

        public BaseRepository(string connectionString, DbContext dbContext)
        {
            this.connectionString = connectionString;
            this.dbContext = dbContext;
        }

        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }
        public DbContext DbContext
        {
            get
            {
                return dbContext;
            }
        }

        public virtual void Create(BaseModel model)
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
                    query.Connection = connection;
                    query.CommandText = querySql;
                    query.Connection.Open();
                    query.ExecuteNonQuery();
                    query.Connection.Close();
                }
            }
        }

        public virtual void Update(BaseModel model)
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
                    query.Connection = connection;
                    query.CommandText = querySql;
                    query.Connection.Open();
                    query.ExecuteNonQuery();
                    query.Connection.Close();
                }
            }
        }

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

        public abstract void Delete(int id);
        public abstract List<BaseModel> GetAll();
        public abstract BaseModel GetById(int id);
    }
}
