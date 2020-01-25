using System;
using Task6ORM;
using Task6ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Task6
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class GetAllTest
    {
        private const string connectionString = @"Data Source=User-pc;Initial Catalog=Task6DB;Integrated Security=True";
        private DbContext dbContext = DbContext.GetInstance(connectionString);

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
        /// 
        /// </summary>
        [TestMethod]
        public void GetAllStudentsTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<BaseModel> students = dbContext.StudentsRepository.GetAll();
            foreach (var student in students)
            {
                Student obj1 = (Student)student;
                Student obj2 = studentsCases.Where(o => o.Id == obj1.Id &&
                                                        o.FullName == obj1.FullName &&
                                                        o.Gender == obj1.Gender &&
                                                        o.DateOfBirth == obj1.DateOfBirth.Date &&
                                                        o.Group.Id == obj1.Group.Id)
                                            .FirstOrDefault();
                isEqualList.Add(obj2 == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetAllGroupsTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<BaseModel> groups = dbContext.GroupsRepository.GetAll();
            foreach (var group in groups)
            {
                Group obj1 = (Group)group;
                Group obj2 = groupsCases.Where(o => o.Id == obj1.Id &&
                                                    o.Name == obj1.Name)
                                        .FirstOrDefault();
                isEqualList.Add(obj2 == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetAllSubjectsTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<BaseModel> subjects = dbContext.SubjectsRepository.GetAll();
            foreach (var subject in subjects)
            {
                Subject obj1 = (Subject)subject;
                Subject obj2 = subjectsCases.Where(o => o.Id == obj1.Id &&
                                                        o.Name == obj1.Name)
                                            .FirstOrDefault();
                isEqualList.Add(obj2 == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetAllSessionsTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<BaseModel> sessions = dbContext.SessionsRepository.GetAll();
            foreach (var session in sessions)
            {
                Session obj1 = (Session)session;
                Session obj2 = sessionsCases.Where(o => o.Id == obj1.Id &&
                                                        o.EducationPeriod == obj1.EducationPeriod &&
                                                        o.Semestr == obj1.Semestr)
                                            .FirstOrDefault();
                isEqualList.Add(obj2 == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetAllSubjectOfGroupsTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<BaseModel> subjectsOfGroups = dbContext.SubjectsOfGroupsRepository.GetAll();
            foreach (var subjectsOfGroup in subjectsOfGroups)
            {
                SubjectsOfGroup obj1 = (SubjectsOfGroup)subjectsOfGroup;
                SubjectsOfGroup obj2 = subjectsOfGroupsCases.Where(o => o.Id == obj1.Id &&
                                                                        o.Group.Id == obj1.Group.Id &&
                                                                        o.Subject.Id == obj1.Subject.Id)
                                                            .FirstOrDefault();
                isEqualList.Add(obj2 == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetAllExamsTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<BaseModel> exams = dbContext.ExamsRepository.GetAll();
            foreach (var exam in exams)
            {
                Exam obj1 = (Exam)exam;
                Exam obj2 = examsCases.Where(o => o.Id == obj1.Id &&
                                                  o.ExamDate == obj1.ExamDate.Date &&
                                                  o.Session.Id == obj1.Session.Id &&
                                                  o.SubjectsOfGroup.Id == obj1.SubjectsOfGroup.Id)
                                      .FirstOrDefault();
                isEqualList.Add(obj2 == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetAllResultsOfExamsTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<BaseModel> resultsOfExams = dbContext.ResultsOfExamsRepository.GetAll();
            foreach (var resultsOfExam in resultsOfExams)
            {
                ResultsOfExam obj1 = (ResultsOfExam)resultsOfExam;
                ResultsOfExam obj2 = resultsExamsCases.Where(o => o.Id == obj1.Id &&
                                                                  o.Exam.Id == obj1.Exam.Id &&
                                                                  o.Student.Id == obj1.Student.Id &&
                                                                  o.Result == obj1.Result)
                                                      .FirstOrDefault();
                isEqualList.Add(obj2 == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }
    }
}
