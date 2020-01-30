using System;
using Task7ORM;
using Task7ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Task7
{
    /// <summary>
    /// The unit test that represents testing adding and removing entities
    /// </summary>
    [TestClass]
    public class CreateAndDeleteTest
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
                    Id = 4,
                    Name = "Специальность1"
                },
                new Speciality()
                {
                    Id = 5,
                    Name = "Специальность2"
                }
            };
            #endregion
            #region Teachers entities
            private List<Teacher> teachersCases = new List<Teacher>()
            {
                new Teacher()
                {
                    Id = 10,
                    FullName = "Иванов Иван Иванович Сергей",
                    Gender = "М"
                },
                new Teacher()
                {
                    Id = 11,
                    FullName = "Петров Петр Петрович",
                    Gender = "М"
                }
            };
            #endregion
            #region Students entities
            private List<Student> studentsCases = new List<Student>()
            {
                new Student()
                {
                    Id = 10,
                    FullName = "Иванов Иван Иванович Сергей",
                    Gender = "М",
                    DateOfBirth = DateTime.Parse("07.02.1996"),
                    Group = new Group() { Id = 2 }
                },
                new Student()
                {
                    Id = 11,
                    FullName = "Петров Петр Петрович",
                    Gender = "М",
                    DateOfBirth = DateTime.Parse("07.02.1996"),
                    Group = new Group() { Id = 3 }
                }
            };
            #endregion
            #region Groups entities
            private List<Group> groupsCases = new List<Group>()
            {
                new Group()
                {
                    Id = 4,
                    Name = "ЗИТ-51",
                    SpecialityId = 0
                },
                new Group()
                {
                    Id = 5,
                    Name = "ЗИТ-52",
                    SpecialityId = 0
                }
            };
            #endregion
            #region Subjects entities
            private List<Subject> subjectsCases = new List<Subject>()
            {
                new Subject()
                {
                    Id = 5,
                    Name = "ФФФ"
                },
                new Subject()
                {
                    Id = 6,
                    Name = "МММ"
                }
            };
            #endregion
            #region Sessions entities
            private List<Session> sessionsCases = new List<Session>()
            {
                new Session()
                {
                    Id = 4,
                    EducationPeriod = "2016-2017",
                    Semestr = 1
                },
                new Session()
                {
                    Id = 5,
                    EducationPeriod = "2016-2017",
                    Semestr = 2
                }
            };
        #endregion
            #region Exams entities
            private List<Exam> examsCases = new List<Exam>()
            {
                new Exam()
                {
                    Id = 5,
                    Session = new Session() { Id = 2 },
                    ExamDate = DateTime.Parse("11.11.2011"),
                    SubjectsOfGroup = new SubjectsOfGroup() { Id = 1 }
                },
                new Exam()
                {
                    Id = 6,
                    Session = new Session() { Id = 3 },
                    ExamDate = DateTime.Parse("12.12.2012"),
                    SubjectsOfGroup = new SubjectsOfGroup() { Id = 0 }
                }
            };
        #endregion
            #region ResultsExams entities
            private List<ResultsOfExam> resultsExamsCases = new List<ResultsOfExam>()
            {
                new ResultsOfExam()
                {
                    Id = 10,
                    Student = new Student() { Id = 1 },
                    Exam = new Exam() { Id = 3 },
                    Result = 1
                },
                new ResultsOfExam()
                {
                    Id = 11,
                    Student = new Student() { Id = 2 },
                    Exam = new Exam() { Id = 2 },
                    Result = 1
                }
            };
        #endregion
            #region SubjectsOfGroups entities
            private List<SubjectsOfGroup> subjectsOfGroupsCases = new List<SubjectsOfGroup>()
            {
                new SubjectsOfGroup()
                {
                    Id = 5,
                    Group = new Group() { Id = 1 },
                    Subject = new Subject() { Id = 2 }
                },
                new SubjectsOfGroup()
                {
                    Id = 6,
                    Group = new Group() { Id = 3 },
                    Subject = new Subject() { Id = 4 }
                }
            };
        #endregion
        #endregion

        /// <summary>
        /// Method for testing the creation and removal of teachers in the database
        /// </summary>
        [TestMethod]
        public void CreateAndDeleteTeachersTest()
        {
            List<bool> isCreateAndDeleteList = new List<bool>();
            teachersCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.TeachersRepository.Create(o)));
            teachersCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.TeachersRepository.Delete(o)));
            bool isEqualCollections = isCreateAndDeleteList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the creation and removal of specialities in the database
        /// </summary>
        [TestMethod]
        public void CreateAndDeleteSpecialitiesTest()
        {
            List<bool> isCreateAndDeleteList = new List<bool>();
            specialitiesCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.SpecialitiesRepository.Create(o)));
            specialitiesCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.SpecialitiesRepository.Delete(o)));
            bool isEqualCollections = isCreateAndDeleteList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the creation and removal of students in the database
        /// </summary>
        [TestMethod]
        public void CreateAndDeleteStudentsTest()
        {
            List<bool> isCreateAndDeleteList = new List<bool>();
            studentsCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.StudentsRepository.Create(o)));
            studentsCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.StudentsRepository.Delete(o)));
            bool isEqualCollections = isCreateAndDeleteList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the creation and removal of groups in the database
        /// </summary>
        [TestMethod]
        public void CreateAndDeleteGroupsTest()
        {
            List<bool> isCreateAndDeleteList = new List<bool>();
            groupsCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.GroupsRepository.Create(o)));
            groupsCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.GroupsRepository.Delete(o)));
            bool isEqualCollections = isCreateAndDeleteList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the creation and removal of subjects in the database
        /// </summary>
        [TestMethod]
        public void CreateAndDeleteSubjectsTest()
        {
            List<bool> isCreateAndDeleteList = new List<bool>();
            subjectsCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.SubjectsRepository.Create(o)));
            subjectsCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.SubjectsRepository.Delete(o)));
            bool isEqualCollections = isCreateAndDeleteList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the creation and removal of subjects of groups in the database
        /// </summary>
        [TestMethod]
        public void CreateAndDeleteSubjectsOfGroupsTest()
        {
            List<bool> isCreateAndDeleteList = new List<bool>();
            subjectsOfGroupsCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.SubjectsOfGroupsRepository.Create(o)));
            subjectsOfGroupsCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.SubjectsOfGroupsRepository.Delete(o)));
            bool isEqualCollections = isCreateAndDeleteList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the creation and removal of sessions in the database
        /// </summary>
        [TestMethod]
        public void CreateAndDeleteSessionsTest()
        {
            List<bool> isCreateAndDeleteList = new List<bool>();
            sessionsCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.SessionsRepository.Create(o)));
            sessionsCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.SessionsRepository.Delete(o)));
            bool isEqualCollections = isCreateAndDeleteList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the creation and removal of exams in the database
        /// </summary>
        [TestMethod]
        public void CreateAndDeleteExamsTest()
        {
            List<bool> isCreateAndDeleteList = new List<bool>();
            examsCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.ExamsRepository.Create(o)));
            examsCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.ExamsRepository.Delete(o)));
            bool isEqualCollections = isCreateAndDeleteList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the creation and removal of results of session in the database
        /// </summary>
        [TestMethod]
        public void CreateAndDeleteResultsOfExamsTest()
        {
            List<bool> isCreateAndDeleteList = new List<bool>();
            resultsExamsCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.ResultsOfExamsRepository.Create(o)));
            resultsExamsCases.ForEach(o => isCreateAndDeleteList.Add(dbContext.ResultsOfExamsRepository.Delete(o)));
            bool isEqualCollections = isCreateAndDeleteList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }
    }
}
