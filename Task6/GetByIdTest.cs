using System;
using Task6ORM;
using Task6ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Task6
{
    /// <summary>
    /// The unit test that represents testing selection of entity by id from database
    /// </summary>
    [TestClass]
    public class GetByIdTest
    {
        /// <summary>
        /// Connection string to access Microsoft SQL Server Database
        /// </summary>
        private const string connectionString = @"Data Source=(local);Initial Catalog=Task6DB;Integrated Security=True";

        /// <summary>
        /// Object for access to repositories
        /// </summary>
        private DbContext dbContext = DbContext.GetInstance(connectionString);

        /// <summary>
        /// Cases for testing entities
        /// </summary>
        #region Test cases
        #region Students entities
        private List<Student> studentsCases = new List<Student>()
            {
                new Student()
                {
                    Id = 0,
                    FullName = "Масловский Сергей Витальевич",
                    Gender = "М",
                    DateOfBirth = DateTime.Parse("07.02.1996"),
                    Group = new Group() { Id = 3 }
                },
                new Student()
                {
                    Id = 1,
                    FullName = "Иванова Мария Олеговна",
                    Gender = "Ж",
                    DateOfBirth = DateTime.Parse("01.05.1998"),
                    Group = new Group() { Id = 2 }
                },
                new Student()
                {
                    Id = 2,
                    FullName = "Гринь Валерий Анатольевич",
                    Gender = "М",
                    DateOfBirth = DateTime.Parse("11.07.1998"),
                    Group = new Group() { Id = 1 }
                },
                new Student()
                {
                    Id = 3,
                    FullName = "Шаповалова Дарья Анатольевна",
                    Gender = "Ж",
                    DateOfBirth = DateTime.Parse("02.08.1998"),
                    Group = new Group() { Id = 1 }
                },
                new Student()
                {
                    Id = 4,
                    FullName = "Иванов Юстин Романович",
                    Gender = "М",
                    DateOfBirth = DateTime.Parse("09.01.2000"),
                    Group = new Group() { Id = 0 }
                },
                new Student()
                {
                    Id = 5,
                    FullName = "Тихонов Юлиан Кириллович",
                    Gender = "М",
                    DateOfBirth = DateTime.Parse("17.02.2001"),
                    Group = new Group() { Id = 0 }
                },
                new Student()
                {
                    Id = 6,
                    FullName = "Гусева Алика Германовна",
                    Gender = "Ж",
                    DateOfBirth = DateTime.Parse("15.11.1998"),
                    Group = new Group() { Id = 2 }
                },
                new Student()
                {
                    Id = 7,
                    FullName = "Лапина Клавдия Прокловна",
                    Gender = "Ж",
                    DateOfBirth = DateTime.Parse("23.12.1995"),
                    Group = new Group() { Id = 3 }
                },
                new Student()
                {
                    Id = 8,
                    FullName = "Кудряшов Гордей Лукьевич",
                    Gender = "М",
                    DateOfBirth = DateTime.Parse("14.09.1999"),
                    Group = new Group() { Id = 1 }
                },
                new Student()
                {
                    Id = 9,
                    FullName = "Марков Афанасий Семёнович",
                    Gender = "М",
                    DateOfBirth = DateTime.Parse("06.06.1996"),
                    Group = new Group() { Id = 3 }
                }
            };
            #endregion
            #region Groups entities
            private List<Group> groupsCases = new List<Group>()
            {
                new Group()
                {
                    Id = 0,
                    Name = "ИТ-11"
                },
                new Group()
                {
                    Id = 1,
                    Name = "ИТ-21"
                },
                new Group()
                {
                    Id = 2,
                    Name = "ИТ-31"
                },
                new Group()
                {
                    Id = 3,
                    Name = "ИТ-41"
                }
            };
        #endregion
            #region Subjects entities
            private List<Subject> subjectsCases = new List<Subject>()
            {
                new Subject()
                {
                    Id = 0,
                    Name = "ПСП"
                },
                new Subject()
                {
                    Id = 1,
                    Name = "КСКР"
                },
                new Subject()
                {
                    Id = 2,
                    Name = "ООП"
                },
                new Subject()
                {
                    Id = 3,
                    Name = "ОАИП"
                },
                new Subject()
                {
                    Id = 4,
                    Name = "ОС"
                }
            };
            #endregion
            #region Sessions entities
            private List<Session> sessionsCases = new List<Session>()
            {
                new Session()
                {
                    Id = 0,
                    EducationPeriod = "2018-2019",
                    Semestr = 1
                },
                new Session()
                {
                    Id = 1,
                    EducationPeriod = "2018-2019",
                    Semestr = 2
                },
                new Session()
                {
                    Id = 2,
                    EducationPeriod = "2019-2020",
                    Semestr = 1
                },
                new Session()
                {
                    Id = 3,
                    EducationPeriod = "2019-2020",
                    Semestr = 2
                }
            };
        #endregion
            #region Exams entities
            private List<Exam> examsCases = new List<Exam>()
            {
                new Exam()
                {
                    Id = 0,
                    Session = new Session() { Id = 0 },
                    ExamDate = DateTime.Parse("21.12.2019"),
                    SubjectsOfGroup = new SubjectsOfGroup() { Id = 4 }

                },
                new Exam()
                {
                    Id = 1,
                    Session = new Session() { Id = 1 },
                    ExamDate = DateTime.Parse("23.12.2019"),
                    SubjectsOfGroup = new SubjectsOfGroup() { Id = 3 }
                },
                new Exam()
                {
                    Id = 2,
                    Session = new Session() { Id = 2 },
                    ExamDate = DateTime.Parse("17.12.2018"),
                    SubjectsOfGroup = new SubjectsOfGroup() { Id = 2 }
                },
                new Exam()
                {
                    Id = 3,
                    Session = new Session() { Id = 3 },
                    ExamDate = DateTime.Parse("20.05.2019"),
                    SubjectsOfGroup = new SubjectsOfGroup() { Id = 1 }
                },
                new Exam()
                {
                    Id = 4,
                    Session = new Session() { Id = 3 },
                    ExamDate = DateTime.Parse("22.05.2019"),
                    SubjectsOfGroup = new SubjectsOfGroup() { Id = 0 }
                }
            };
        #endregion
            #region ResultsExams entities
            private List<ResultsOfExam> resultsExamsCases = new List<ResultsOfExam>()
            {
                new ResultsOfExam()
                {
                    Id = 0,
                    Student = new Student() { Id = 0 },
                    Exam = new Exam() { Id = 4 },
                    Result = 8
                },
                new ResultsOfExam()
                {
                    Id = 1,
                    Student = new Student() { Id = 1 },
                    Exam = new Exam() { Id = 1 },
                    Result = 7
                },
                new ResultsOfExam()
                {
                    Id = 2,
                    Student = new Student() { Id = 2 },
                    Exam = new Exam() { Id = 2 },
                    Result = 3
                },
                new ResultsOfExam()
                {
                    Id = 3,
                    Student = new Student() { Id = 3 },
                    Exam = new Exam() { Id = 1 },
                    Result = 2
                },
                new ResultsOfExam()
                {
                    Id = 4,
                    Student = new Student() { Id = 4 },
                    Exam = new Exam() { Id = 4 },
                    Result = 5
                },
                new ResultsOfExam()
                {
                    Id = 5,
                    Student = new Student() { Id = 5 },
                    Exam = new Exam() { Id = 4 },
                    Result = 2
                },
                new ResultsOfExam()
                {
                    Id = 6,
                    Student = new Student() { Id = 6 },
                    Exam = new Exam() { Id = 1 },
                    Result = 10
                },
                new ResultsOfExam()
                {
                    Id = 7,
                    Student = new Student() { Id = 7 },
                    Exam = new Exam() { Id = 4 },
                    Result = 2
                },
                new ResultsOfExam()
                {
                    Id = 8,
                    Student = new Student() { Id = 8 },
                    Exam = new Exam() { Id = 2 },
                    Result = 6
                },
                new ResultsOfExam()
                {
                    Id = 9,
                    Student = new Student() { Id = 9 },
                    Exam = new Exam() { Id = 4 },
                    Result = 10
                }
            };
        #endregion
            #region SubjectsOfGroups entities
            private List<SubjectsOfGroup> subjectsOfGroupsCases = new List<SubjectsOfGroup>()
            {
                new SubjectsOfGroup()
                {
                    Id = 0,
                    Group = new Group() { Id = 0 },
                    Subject = new Subject() { Id = 3 }
                },
                new SubjectsOfGroup()
                {
                    Id = 1,
                    Group = new Group() { Id = 1 },
                    Subject = new Subject() { Id = 2 }
                },
                new SubjectsOfGroup()
                {
                    Id = 2,
                    Group = new Group() { Id = 1 },
                    Subject = new Subject() { Id = 4 }
                },
                new SubjectsOfGroup()
                {
                    Id = 3,
                    Group = new Group() { Id = 2 },
                    Subject = new Subject() { Id = 1 }
                },
                new SubjectsOfGroup()
                {
                    Id = 4,
                    Group = new Group() { Id = 3 },
                    Subject = new Subject() { Id = 0 }
                }
            };
        #endregion
        #endregion

        /// <summary>
        /// Method for testing the getting of student by id from the database
        /// </summary>
        [TestMethod]
        public void GetStudentsByIdTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<int> ids = new List<int>() { 0, 4, 7 }; 
            foreach(int id in ids)
            {
                Student student = (Student)dbContext.StudentsRepository.GetById(id);
                Student obj = studentsCases.Where(o => o.Id == student.Id &&
                                                        o.FullName == student.FullName &&
                                                        o.Gender == student.Gender &&
                                                        o.DateOfBirth == student.DateOfBirth.Date &&
                                                        o.Group.Id == student.Group.Id)
                                            .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the getting of group by id from the database
        /// </summary>
        [TestMethod]
        public void GetGroupsByIdTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<int> ids = new List<int>() { 1, 3 };
            foreach (int id in ids)
            {
                Group group = (Group)dbContext.GroupsRepository.GetById(id);
                Group obj = groupsCases.Where(o => o.Id == group.Id &&
                                                   o.Name == group.Name)
                                       .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the getting of subject by id from the database
        /// </summary>
        [TestMethod]
        public void GetSubjectsByIdTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<int> ids = new List<int>() { 0, 3, 4 };
            foreach (int id in ids)
            {
                Subject subject = (Subject)dbContext.SubjectsRepository.GetById(id);
                Subject obj = subjectsCases.Where(o => o.Id == subject.Id &&
                                                       o.Name == subject.Name)
                                           .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the getting of session by id from the database
        /// </summary>
        [TestMethod]
        public void GetSessionsByIdTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<int> ids = new List<int>() { 1, 2 };
            foreach (int id in ids)
            {
                Session session = (Session)dbContext.SessionsRepository.GetById(id);
                Session obj = sessionsCases.Where(o => o.Id == session.Id &&
                                                       o.EducationPeriod == session.EducationPeriod &&
                                                       o.Semestr == session.Semestr)
                                           .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the getting of subjects of group by id from the database
        /// </summary>
        [TestMethod]
        public void GetSubjectOfGroupsByIdTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<int> ids = new List<int>() { 1, 3, 4 };
            foreach (int id in ids)
            {
                SubjectsOfGroup subjectsOfGroup = (SubjectsOfGroup)dbContext.SubjectsOfGroupsRepository.GetById(id);
                SubjectsOfGroup obj = subjectsOfGroupsCases.Where(o => o.Id == subjectsOfGroup.Id &&
                                                                        o.Group.Id == subjectsOfGroup.Group.Id &&
                                                                        o.Subject.Id == subjectsOfGroup.Subject.Id)
                                                           .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the exam by id from the database
        /// </summary>
        [TestMethod]
        public void GetExamsByIdTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<int> ids = new List<int>() { 0, 1, 2 };
            foreach (int id in ids)
            {
                Exam exam = (Exam)dbContext.ExamsRepository.GetById(id);
                Exam obj = examsCases.Where(o => o.Id == exam.Id &&
                                                 o.ExamDate == exam.ExamDate.Date &&
                                                 o.Session.Id == exam.Session.Id &&
                                                 o.SubjectsOfGroup.Id == exam.SubjectsOfGroup.Id)
                                     .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }         
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the getting of results of exam by id from the database
        /// </summary>
        [TestMethod]
        public void GetResultsOfExamsByIdTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<int> ids = new List<int>() { 4, 5, 7 };
            foreach (int id in ids)
            {
                ResultsOfExam resultsOfExam = (ResultsOfExam)dbContext.ResultsOfExamsRepository.GetById(id);
                ResultsOfExam obj = resultsExamsCases.Where(o => o.Id == resultsOfExam.Id &&
                                                                 o.Exam.Id == resultsOfExam.Exam.Id &&
                                                                 o.Student.Id == resultsOfExam.Student.Id &&
                                                                 o.Result == resultsOfExam.Result)
                                                     .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }
    }
}
