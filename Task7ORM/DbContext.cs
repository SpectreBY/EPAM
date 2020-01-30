using System;
using System.Data.Linq;
using System.Data.SqlClient;
using Task7ORM.Interfaces;
using Task7ORM.Models;

namespace Task7ORM
{
    /// <summary>
    /// Class which represents which provides to repositories and deploy database
    /// </summary>
    public class DbContext
    {
        /// <summary>
        /// Field for storage object of DataContext
        /// </summary>
        private DataContext _dataContext;

        /// <summary>
        /// Field for storage object of ExamsRepository
        /// </summary>
        private IRepository<Exam> _examsRepository;

        /// <summary>
        /// Field for storage object of GroupsRepository
        /// </summary>
        private IRepository<Group> _groupsRepository;

        /// <summary>
        /// Field for storage object of SessionsRepository
        /// </summary>
        private IRepository<Session> _sessionsRepository;

        /// <summary>
        /// Field for storage object of SubjectsRepository
        /// </summary>
        private IRepository<Subject> _subjectsRepository;

        /// <summary>
        /// Field for storage object of ResultsOfExamsRepository
        /// </summary>
        private IRepository<ResultsOfExam> _resultsOfExamsRepository;

        /// <summary>
        /// Field for storage object of StudentsRepository
        /// </summary>
        private IRepository<Student> _studentsRepository;

        /// <summary>
        /// Field for storage object of SubjectsOfGroupsRepository
        /// </summary>
        private IRepository<SubjectsOfGroup> _subjectsOfGroupsRepository;

        /// <summary>
        /// Field for storage object of TeachersRepository
        /// </summary>
        private IRepository<Teacher> _teachersRepository;

        /// <summary>
        /// Field for storage object of SpecialitiesRepository
        /// </summary>
        private IRepository<Speciality> _specialitiesRepository;

        /// <summary>
        /// Field which which storage the instance of DbContext
        /// </summary>
        private static DbContext instance;

        /// <summary>
        /// Constructor which get connectionString parametr
        /// </summary>
        /// <param name="connectionString"></param>
        public DbContext(string connectionString)
        {
            _dataContext = new DataContext(connectionString);
            _examsRepository = new ExamsRepository(_dataContext, this);
            _groupsRepository = new GroupsRepository(_dataContext, this);
            _sessionsRepository = new SessionsRepository(_dataContext, this);
            _subjectsRepository = new SubjectsRepository(_dataContext, this);
            _resultsOfExamsRepository = new ResultsOfExamsRepository(_dataContext, this);
            _studentsRepository = new StudentsRepository(_dataContext, this);
            _subjectsOfGroupsRepository = new SubjectsOfGroupsRepository(_dataContext, this);
            _teachersRepository = new TeachersRepository(_dataContext, this);
            _specialitiesRepository = new SpecialitiesRepository(_dataContext, this);
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
        /// Property for get access to TeachersRepository object
        /// </summary>
        public IRepository<Teacher> TeachersRepository
        {
            get { return _teachersRepository; }
        }

        /// <summary>
        /// Property for get access to SpecialitiesRepository object
        /// </summary>
        public IRepository<Speciality> SpecialitiesRepository
        {
            get { return _specialitiesRepository; }
        }

        /// <summary>
        /// Property for get access to StudentsRepository object
        /// </summary>
        public IRepository<Student> StudentsRepository
        {
            get { return _studentsRepository; }
        }

        /// <summary>
        /// Property for get access to GroupsRepository object
        /// </summary>
        public IRepository<Group> GroupsRepository
        {
            get { return _groupsRepository; }
        }

        /// <summary>
        /// Property for get access to SubjectsRepository object
        /// </summary>
        public IRepository<Subject> SubjectsRepository
        {
            get { return _subjectsRepository; }
        }

        /// <summary>
        /// Property for get access to SubjectsOfGroupsRepository object
        /// </summary>
        public IRepository<SubjectsOfGroup> SubjectsOfGroupsRepository
        {
            get { return _subjectsOfGroupsRepository; }
        }

        /// <summary>
        /// Property for get access to SessionsRepository object
        /// </summary>
        public IRepository<Session> SessionsRepository
        {
            get { return _sessionsRepository; }
        }

        /// <summary>
        /// Property for get access to ExamsRepository object
        /// </summary>
        public IRepository<Exam> ExamsRepository
        {
            get { return _examsRepository; }
        }

        /// <summary>
        /// Property for get access to ResultsOfExamsRepository object
        /// </summary>
        public IRepository<ResultsOfExam> ResultsOfExamsRepository
        {
            get { return _resultsOfExamsRepository; }
        }
        #endregion
    }
}
