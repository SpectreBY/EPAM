using System;
using System.Data.SqlClient;
using Task6Library;

namespace Task6ORM
{
    /// <summary>
    /// Class which represents which provides to repositories and deploy database
    /// </summary>
    public class DbContext
    {
        /// <summary>
        /// Field which which storage the instance of DbContext
        /// </summary>
        private static DbContext instance;

        /// <summary>
        /// Field for storage connection string for get access to the database
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Field for storage object of StudentsRepository
        /// </summary>
        private StudentsRepository studentsRepository;

        /// <summary>
        /// Field for storage object of GroupsRepository
        /// </summary>
        private GroupsRepository groupsRepository;

        /// <summary>
        /// Field for storage object of SessionsRepository
        /// </summary>
        private SessionsRepository sessionsRepository;

        /// <summary>
        /// Field for storage object of SubjectsOfGroupsRepository
        /// </summary>
        private SubjectsOfGroupsRepository subjectsOfGroupsRepository;

        /// <summary>
        /// Field for storage object of SubjectsRepository
        /// </summary>
        private SubjectsRepository subjectsRepository;

        /// <summary>
        /// Field for storage object of ExamsRepository
        /// </summary>
        private ExamsRepository examsRepository;

        /// <summary>
        /// Field for storage object of ResultsOfExamsRepository
        /// </summary>
        private ResultsOfExamsRepository resultsOfExamsRepository;

        /// <summary>
        /// Constructor which get connectionString parametr
        /// </summary>
        /// <param name="connectionString"></param>
        private DbContext(string connectionString)
        {
            this.connectionString = connectionString;
            studentsRepository = new StudentsRepository(connectionString, this);
            groupsRepository = new GroupsRepository(connectionString, this);
            sessionsRepository = new SessionsRepository(connectionString, this);
            subjectsOfGroupsRepository = new SubjectsOfGroupsRepository(connectionString, this);
            subjectsRepository = new SubjectsRepository(connectionString, this);
            examsRepository = new ExamsRepository(connectionString, this);
            resultsOfExamsRepository = new ResultsOfExamsRepository(connectionString, this);
        }

        /// <summary>
        /// Static method for obtaining a single instance of DbContext to implement Singletone template
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DbContext GetInstance(string connectionString)
        {
            if (instance == null)
            {
                instance = new DbContext(connectionString);
            }
            return instance;
        }

        #region Properties for access to repositiries
        /// <summary>
        /// Property for get access to StudentsRepository object
        /// </summary>
        public StudentsRepository StudentsRepository
        {
            get { return studentsRepository; }
        }

        /// <summary>
        /// Property for get access to GroupsRepository object
        /// </summary>
        public GroupsRepository GroupsRepository
        {
            get { return groupsRepository; }
        }

        /// <summary>
        /// Property for get access to SubjectsRepository object
        /// </summary>
        public SubjectsRepository SubjectsRepository
        {
            get { return subjectsRepository; }
        }

        /// <summary>
        /// Property for get access to SubjectsOfGroupsRepository object
        /// </summary>
        public SubjectsOfGroupsRepository SubjectsOfGroupsRepository
        {
            get { return subjectsOfGroupsRepository; }
        }

        /// <summary>
        /// Property for get access to SessionsRepository object
        /// </summary>
        public SessionsRepository SessionsRepository
        {
            get { return sessionsRepository; }
        }

        /// <summary>
        /// Property for get access to ExamsRepository object
        /// </summary>
        public ExamsRepository ExamsRepository
        {
            get { return examsRepository; }
        }

        /// <summary>
        /// Property for get access to ResultsOfExamsRepository object
        /// </summary>
        public ResultsOfExamsRepository ResultsOfExamsRepository
        {
            get { return resultsOfExamsRepository; }
        }
        #endregion

        /// <summary>
        /// Method for realize of deploy database and fill it
        /// </summary>
        /// <returns></returns>
        public bool DeployDatabase()
        {
            using (SqlConnection connection = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master"))
            {
                using (var query = new SqlCommand())
                {
                    string deploySql = SqlQueriesHelper.GetDeployScript();
                    string fillSql = SqlQueriesHelper.GetFillDataScript();
                    try
                    {
                        query.Connection = connection;
                        query.CommandText = deploySql;
                        query.Connection.Open();
                        query.ExecuteNonQuery();
                        query.Connection.Close();

                        query.CommandText = fillSql;
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
    }
}
