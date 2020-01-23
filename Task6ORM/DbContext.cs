using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM
{
    public class DbContext
    {
        private static DbContext instance;
        private string connectionString;

        private StudentsRepository studentsRepository;
        private GroupsRepository groupsRepository;
        private SessionsRepository sessionsRepository;
        private SubjectsOfGroupsRepository subjectsOfGroupsRepository;
        private SubjectsRepository subjectsRepository;
        private ExamsRepository examsRepository;
        private ResultsOfSessionRepository resultsOfSessionRepository;

        private DbContext(string connectionString)
        {
            this.connectionString = connectionString;
            studentsRepository = new StudentsRepository(connectionString, this);
            groupsRepository = new GroupsRepository(connectionString, this);
            sessionsRepository = new SessionsRepository(connectionString, this);
            subjectsOfGroupsRepository = new SubjectsOfGroupsRepository(connectionString, this);
            subjectsRepository = new SubjectsRepository(connectionString, this);
            examsRepository = new ExamsRepository(connectionString, this);
            resultsOfSessionRepository = new ResultsOfSessionRepository(connectionString, this);
        }

        public static DbContext GetInstance(string connectionString)
        {
            if (instance == null)
            {
                instance = new DbContext(connectionString);
            }
            return instance;
        }

        #region Properties for access to repositiries
        public StudentsRepository StudentsRepository
        {
            get { return studentsRepository; }
        }

        public GroupsRepository GroupsRepository
        {
            get { return groupsRepository; }
        }

        public SubjectsRepository SubjectsRepository
        {
            get { return subjectsRepository; }
        }

        public SubjectsOfGroupsRepository SubjectsOfGroupsRepository
        {
            get { return subjectsOfGroupsRepository; }
        }

        public SessionsRepository SessionsRepository
        {
            get { return sessionsRepository; }
        }

        public ExamsRepository ExamsRepository
        {
            get { return examsRepository; }
        }

        public ResultsOfSessionRepository ResultsOfSessionRepository
        {
            get { return resultsOfSessionRepository; }
        }
        #endregion

        public void DeployDatabase(string script)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = connection;
                    query.CommandText = script;
                    query.Connection.Open();
                    query.ExecuteNonQuery();
                    query.Connection.Close();
                }
            }
        }
    }
}
