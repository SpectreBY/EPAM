using System;
using Task7ORM;
using Task7ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Task7
{
    /// <summary>
    /// The unit test that represents testing selection of all of entities from database
    /// </summary>
    [TestClass]
    public class GetAllTest
    {
        /// <summary>
        /// Connection string to access Microsoft SQL Server Database
        /// </summary>
        private const string connectionString = @"Data Source=(local);Initial Catalog=Task7DB;Integrated Security=True";

        /// <summary>
        /// Object for access to repositories
        /// </summary>
        private DbContext dbContext = DbContext.GetInstance(connectionString);

        /// <summary>
        /// Cases for testing entities
        /// </summary>
        #region Test cases
            #region Specialities entities
            private List<Speciality> specialitiesCases = new List<Speciality>()
            {
                new Speciality()
                {
                    Id = 0,
                    Name = "Инженер-программист"
                },
                new Speciality()
                {
                    Id = 1,
                    Name = "Инженер-системный программист"
                }
            };
            #endregion
            #region Teachers entities
            private List<Teacher> teachersCases = new List<Teacher>()
            {
                new Teacher()
                {
                    Id = 0,
                    FullName = "Зиновьев Георгий Сергеевич",
                    Gender = "М"
                },
                new Teacher()
                {
                    Id = 1,
                    FullName = "Морозова София Вадимовна",
                    Gender = "Ж"
                },
                new Teacher()
                {
                    Id = 2,
                    FullName = "Петренко Борис Максимович",
                    Gender = "М"
                },
                new Teacher()
                {
                    Id = 3,
                    FullName = "Котовска Олеся Григорьевна",
                    Gender = "Ж"
                },
                new Teacher()
                {
                    Id = 4,
                    FullName = "Суханов Давид Петрович",
                    Gender = "М"
                }
            };
            #endregion
            #region Students entities
            private List<Student> studentsCases = new List<Student>()
            {
                new Student()
                {
                    Id = 0,
                    FullName = "Масловский Сергей Витальевич",
                    Gender = "М",
                    DateOfBirth = DateTime.Parse("07.02.1996"),
                    GroupId = 3
                },
                new Student()
                {
                    Id = 1,
                    FullName = "Иванова Мария Олеговна",
                    Gender = "Ж",
                    DateOfBirth = DateTime.Parse("01.05.1998"),
                    GroupId = 2
                },
                new Student()
                {
                    Id = 2,
                    FullName = "Гринь Валерий Анатольевич",
                    Gender = "М",
                    DateOfBirth = DateTime.Parse("11.07.1998"),
                    GroupId = 1
                },
                new Student()
                {
                    Id = 3,
                    FullName = "Шаповалова Дарья Анатольевна",
                    Gender = "Ж",
                    DateOfBirth = DateTime.Parse("02.08.1998"),
                    GroupId = 1
                },
                new Student()
                {
                    Id = 4,
                    FullName = "Иванов Юстин Романович",
                    Gender = "М",
                    DateOfBirth = DateTime.Parse("09.01.2000"),
                    GroupId = 0
                },
                new Student()
                {
                    Id = 5,
                    FullName = "Тихонов Юлиан Кириллович",
                    Gender = "М",
                    DateOfBirth = DateTime.Parse("17.02.2001"),
                    GroupId = 0
                },
                new Student()
                {
                    Id = 6,
                    FullName = "Гусева Алика Германовна",
                    Gender = "Ж",
                    DateOfBirth = DateTime.Parse("15.11.1998"),
                    GroupId = 2
                },
                new Student()
                {
                    Id = 7,
                    FullName = "Лапина Клавдия Прокловна",
                    Gender = "Ж",
                    DateOfBirth = DateTime.Parse("23.12.1995"),
                    GroupId = 3
                },
                new Student()
                {
                    Id = 8,
                    FullName = "Кудряшов Гордей Лукьевич",
                    Gender = "М",
                    DateOfBirth = DateTime.Parse("14.09.1999"),
                    GroupId = 1
                },
                new Student()
                {
                    Id = 9,
                    FullName = "Марков Афанасий Семёнович",
                    Gender = "М",
                    DateOfBirth = DateTime.Parse("06.06.1996"),
                    GroupId = 3
                }
            };
            #endregion
            #region Groups entities
            private List<Group> groupsCases = new List<Group>()
            {
                new Group()
                {
                    Id = 0,
                    SpecialityId = 1,
                    Name = "ИТП-11"
                },
                new Group()
                {
                    Id = 1,
                    SpecialityId = 1,
                    Name = "ИТП-21"
                },
                new Group()
                {
                    Id = 2,
                    SpecialityId = 0,
                    Name = "ИТ-31"
                },
                new Group()
                {
                    Id = 3,
                    SpecialityId = 0,
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
                    SessionId = 0,
                    ExamDate = DateTime.Parse("21.12.2019"),
                    SubjectsOfGroupId = 4,
                    TeacherId = 1

                },
                new Exam()
                {
                    Id = 1,
                    SessionId = 1,
                    ExamDate = DateTime.Parse("23.12.2019"),
                    SubjectsOfGroupId = 3,
                    TeacherId = 4
                },
                new Exam()
                {
                    Id = 2,
                    SessionId = 2,
                    ExamDate = DateTime.Parse("17.12.2018"),
                    SubjectsOfGroupId = 3,
                    TeacherId = 3
                },
                new Exam()
                {
                    Id = 3,
                    SessionId = 2,
                    ExamDate = DateTime.Parse("20.05.2018"),
                    SubjectsOfGroupId = 1,
                    TeacherId = 2
                },
                new Exam()
                {
                    Id = 4,
                    SessionId = 2,
                    ExamDate = DateTime.Parse("22.05.2018"),
                    SubjectsOfGroupId = 0,
                    TeacherId = 0
                }
            };
        #endregion
            #region ResultsExams entities
            private List<ResultsOfExam> resultsExamsCases = new List<ResultsOfExam>()
            {
                new ResultsOfExam()
                {
                    Id = 0,
                    StudentId = 0,
                    ExamId = 4,
                    Result = 8
                },
                new ResultsOfExam()
                {
                    Id = 1,
                    StudentId = 1,
                    ExamId = 1,
                    Result = 7
                },
                new ResultsOfExam()
                {
                    Id = 2,
                    StudentId = 2,
                    ExamId = 2,
                    Result = 3
                },
                new ResultsOfExam()
                {
                    Id = 3,
                    StudentId = 3,
                    ExamId = 1,
                    Result = 2
                },
                new ResultsOfExam()
                {
                    Id = 4,
                    StudentId = 4,
                    ExamId = 4,
                    Result = 5
                },
                new ResultsOfExam()
                {
                    Id = 5,
                    StudentId = 5,
                    ExamId = 4,
                    Result = 2
                },
                new ResultsOfExam()
                {
                    Id = 6,
                    StudentId = 6,
                    ExamId = 1,
                    Result = 10
                },
                new ResultsOfExam()
                {
                    Id = 7,
                    StudentId = 7,
                    ExamId = 4,
                    Result = 2
                },
                new ResultsOfExam()
                {
                    Id = 8,
                    StudentId = 8,
                    ExamId = 2,
                    Result = 6
                },
                new ResultsOfExam()
                {
                    Id = 9,
                    StudentId = 9,
                    ExamId = 4,
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
                    GroupId = 0,
                    SubjectId = 3
                },
                new SubjectsOfGroup()
                {
                    Id = 1,
                    GroupId = 1,
                    SubjectId = 2
                },
                new SubjectsOfGroup()
                {
                    Id = 2,
                    GroupId = 1,
                    SubjectId = 4
                },
                new SubjectsOfGroup()
                {
                    Id = 3,
                    GroupId = 2,
                    SubjectId = 1
                },
                new SubjectsOfGroup()
                {
                    Id = 4,
                    GroupId = 3,
                    SubjectId = 0
                }
            };
        #endregion
        #endregion

        /// <summary>
        /// Method for testing the gettion all of specialities from the database
        /// </summary>
        [TestMethod]
        public void GetAllSpecialitiesTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<Speciality> specialities = dbContext.SpecialitiesRepository.GetAll();
            foreach (var speciality in specialities)
            {
                Speciality obj = specialitiesCases.Where(o => o.Id == speciality.Id &&
                                                         o.Name == speciality.Name)
                                            .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the gettion all of teachers from the database
        /// </summary>
        [TestMethod]
        public void GetAllTeachersTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<Teacher> teachers = dbContext.TeachersRepository.GetAll();
            foreach (var teacher in teachers)
            {
                Teacher obj = teachersCases.Where(o => o.Id == teacher.Id &&
                                                       o.FullName == teacher.FullName &&
                                                       o.Gender == teacher.Gender)
                                            .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the gettion all of students from the database
        /// </summary>
        [TestMethod]
        public void GetAllStudentsTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<Student> students = dbContext.StudentsRepository.GetAll();
            foreach (var student in students)
            {
                Student obj = studentsCases.Where(o => o.Id == student.Id &&
                                                       o.FullName == student.FullName &&
                                                       o.Gender == student.Gender &&
                                                       o.DateOfBirth == student.DateOfBirth.Date &&
                                                       o.GroupId == student.GroupId)
                                            .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the gettion all of groups from the database
        /// </summary>
        [TestMethod]
        public void GetAllGroupsTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<Group> groups = dbContext.GroupsRepository.GetAll();
            foreach (var group in groups)
            {
                Group obj = groupsCases.Where(o => o.Id == group.Id &&
                                                   o.Name == group.Name &&
                                                   o.SpecialityId == group.SpecialityId)
                                        .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the gettion all of subjects from the database
        /// </summary>
        [TestMethod]
        public void GetAllSubjectsTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<Subject> subjects = dbContext.SubjectsRepository.GetAll();
            foreach (var subject in subjects)
            {
                Subject obj = subjectsCases.Where(o => o.Id == subject.Id &&
                                                       o.Name == subject.Name)
                                            .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the gettion all of sessions from the database
        /// </summary>
        [TestMethod]
        public void GetAllSessionsTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<Session> sessions = dbContext.SessionsRepository.GetAll();
            foreach (var session in sessions)
            {
                Session obj = sessionsCases.Where(o => o.Id == session.Id &&
                                                       o.EducationPeriod == session.EducationPeriod &&
                                                       o.Semestr == session.Semestr)
                                            .FirstOrDefault();
                isEqualList.Add(session == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the gettion all of subject of groups from the database
        /// </summary>
        [TestMethod]
        public void GetAllSubjectOfGroupsTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<SubjectsOfGroup> subjectsOfGroups = dbContext.SubjectsOfGroupsRepository.GetAll();
            foreach (var subjectsOfGroup in subjectsOfGroups)
            {
                SubjectsOfGroup obj = subjectsOfGroupsCases.Where(o => o.Id == subjectsOfGroup.Id &&
                                                                       o.GroupId == subjectsOfGroup.GroupId &&
                                                                       o.SubjectId == subjectsOfGroup.SubjectId)
                                                            .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the gettion all of exams from the database
        /// </summary>
        [TestMethod]
        public void GetAllExamsTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<Exam> exams = dbContext.ExamsRepository.GetAll();
            foreach (var exam in exams)
            {
                Exam obj = examsCases.Where(o => o.Id == exam.Id &&
                                                 o.ExamDate == exam.ExamDate.Date &&
                                                 o.SessionId == exam.SessionId &&
                                                 o.SubjectsOfGroupId == exam.SubjectsOfGroupId &&
                                                 o.TeacherId == exam.TeacherId)
                                     .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the gettion all of results of exams from the database
        /// </summary>
        [TestMethod]
        public void GetAllResultsOfExamsTest()
        {
            List<bool> isEqualList = new List<bool>();
            List<ResultsOfExam> resultsOfExams = dbContext.ResultsOfExamsRepository.GetAll();
            foreach (var resultsOfExam in resultsOfExams)
            {
                ResultsOfExam obj = resultsExamsCases.Where(o => o.Id == resultsOfExam.Id &&
                                                                 o.ExamId == resultsOfExam.ExamId &&
                                                                 o.StudentId == resultsOfExam.StudentId &&
                                                                 o.Result == resultsOfExam.Result)
                                                      .FirstOrDefault();
                isEqualList.Add(obj == null ? false : true);
            }
            bool isEqualCollections = isEqualList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }
    }
}
