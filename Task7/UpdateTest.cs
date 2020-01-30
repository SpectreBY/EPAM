using System;
using Task7ORM;
using Task7ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Task7
{
    /// <summary>
    /// The unit test that represents testing of update entities
    /// </summary>
    [TestClass]
    public class UpdateTest
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
            #region Speciality
            Speciality specialityObjCase = new Speciality
            {
                Id = 0,
                Name = "Специальность"
            };
            #endregion
            #region Teacher
            private Teacher teacherObjCase = new Teacher
                {
                    Id = 0,
                    FullName = "Иванов Иван Иванович",
                    Gender = "М"
                };
                #endregion
            #region Student
            private Student studentObjCase = new Student
            {
                Id = 0,
                FullName = "Иванов Иван Иванович",
                Gender = "М",
                DateOfBirth = DateTime.Now.Date,
                Group = new Group() { Id = 3 }
            };
            #endregion
            #region Group
            Group groupObjCase = new Group
            {
                Id = 0,
                Name = "ИТ-51",
                SpecialityId = 0
            };
            #endregion
            #region Subject
            private Subject subjectObjCase = new Subject()
            {
                Id = 4,
                Name = "ОМИМОД"
            };
        #endregion
            #region Session
            private Session sessionObjCase = new Session
            {
                Id = 3,
                EducationPeriod = "2010-2011",
                Semestr = 1
            };
            #endregion
            #region Exam
            private Exam examObjCase = new Exam
            {
                Id = 0,
                ExamDate = DateTime.Now.Date
            };
            #endregion
            #region ResultsExam
            private ResultsOfExam resultsExamObjCase = new ResultsOfExam
            {
                Id = 7,
                Result = 2
            };
        #endregion
        #endregion

        /// <summary>
        /// Method for testing the update of speciality in the database
        /// </summary>
        [TestMethod]
        public void UpdateSpecialityTest()
        {
            List<bool> boolList = new List<bool>();
            int id = 0;

            Speciality speciality = dbContext.SpecialitiesRepository.GetById(id);
            Speciality tmp = new Speciality();
            tmp.Name = speciality.Name;

            speciality.Name = "Специальность";
            boolList.Add(dbContext.TeachersRepository.Update());

            Speciality updatedSpeciality = dbContext.SpecialitiesRepository.GetById(id);
            boolList.Add(updatedSpeciality.Name == specialityObjCase.Name ? true : false);

            updatedSpeciality.Name = tmp.Name;
            dbContext.SpecialitiesRepository.Update();

            bool isEqualCollections = boolList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the update of teacher in the database
        /// </summary>
        [TestMethod]
        public void UpdateTeacherTest()
        {
            List<bool> boolList = new List<bool>();
            int id = 0;

            Teacher teacher = dbContext.TeachersRepository.GetById(id);
            Teacher tmp = new Teacher();
            tmp.FullName = teacher.FullName;

            teacher.FullName = "Иванов Иван Иванович";
            boolList.Add(dbContext.TeachersRepository.Update());

            Teacher updatedTeacher = dbContext.TeachersRepository.GetById(id);
            boolList.Add(updatedTeacher.FullName == studentObjCase.FullName ? true : false);

            updatedTeacher.FullName = tmp.FullName;
            dbContext.TeachersRepository.Update();

            bool isEqualCollections = boolList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the update of student in the database
        /// </summary>
        [TestMethod]
        public void UpdateStudentTest()
        {
            List<bool> boolList = new List<bool>();
            int id = 0;

            Student student = dbContext.StudentsRepository.GetById(id);
            Student tmp = new Student();
            tmp.DateOfBirth = student.DateOfBirth;
            tmp.FullName = student.FullName;

            student.DateOfBirth = DateTime.Now.Date;
            student.FullName = "Иванов Иван Иванович";
            boolList.Add(dbContext.StudentsRepository.Update());
            
            Student updatedStudent = dbContext.StudentsRepository.GetById(id);
            boolList.Add(updatedStudent.FullName == studentObjCase.FullName && 
                         updatedStudent.DateOfBirth == studentObjCase.DateOfBirth ? true : false);

            updatedStudent.DateOfBirth = tmp.DateOfBirth;
            updatedStudent.FullName = tmp.FullName;
            dbContext.StudentsRepository.Update();

            bool isEqualCollections = boolList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the update of group in the database
        /// </summary>
        [TestMethod]
        public void UpdateGroupTest()
        {
            List<bool> boolList = new List<bool>();
            int id = 0;

            Group group = dbContext.GroupsRepository.GetById(id);
            Group tmp = new Group();
            tmp.Name = group.Name;

            group.Name = "ИТ-51";
            boolList.Add(dbContext.GroupsRepository.Update());

            Group updatedGroup = dbContext.GroupsRepository.GetById(id);
            boolList.Add(updatedGroup.Name == groupObjCase.Name ? true : false);

            updatedGroup.Name = tmp.Name;
            dbContext.GroupsRepository.Update();

            bool isEqualCollections = boolList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the update of subject in the database
        /// </summary>
        [TestMethod]
        public void UpdateSubjectTest()
        {
            List<bool> boolList = new List<bool>();
            int id = 4;

            Subject subject = dbContext.SubjectsRepository.GetById(id);
            Subject tmp = new Subject();
            tmp.Name = subject.Name;

            subject.Name = "ОМИМОД";
            boolList.Add(dbContext.SubjectsRepository.Update());

            Subject updatedSubject = dbContext.SubjectsRepository.GetById(id);
            boolList.Add(updatedSubject.Name == subjectObjCase.Name ? true : false);

            updatedSubject.Name = tmp.Name;
            dbContext.SubjectsRepository.Update();

            bool isEqualCollections = boolList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the update of session in the database
        /// </summary>
        [TestMethod]
        public void UpdateSessionTest()
        {
            List<bool> boolList = new List<bool>();
            int id = 3;

            Session session = dbContext.SessionsRepository.GetById(id);
            Session tmp = new Session();
            tmp.EducationPeriod = session.EducationPeriod;
            tmp.Semestr = session.Semestr;

            session.EducationPeriod = "2010-2011";
            session.Semestr = 1;
            boolList.Add(dbContext.SubjectsRepository.Update());

            Session updatedSession = dbContext.SessionsRepository.GetById(id);
            boolList.Add(updatedSession.EducationPeriod == sessionObjCase.EducationPeriod && 
                         updatedSession.Semestr == sessionObjCase.Semestr ? true : false);

            updatedSession.EducationPeriod = tmp.EducationPeriod;
            updatedSession.Semestr = tmp.Semestr;
            dbContext.SubjectsRepository.Update();

            bool isEqualCollections = boolList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the update of exam in the database
        /// </summary>
        [TestMethod]
        public void UpdateExamTest()
        {
            List<bool> boolList = new List<bool>();
            int id = 0;

            Exam exam = dbContext.ExamsRepository.GetById(id);
            Exam tmp = new Exam();
            tmp.ExamDate = exam.ExamDate;

            exam.ExamDate = DateTime.Now.Date;
            boolList.Add(dbContext.ExamsRepository.Update());

            Exam updatedExam = dbContext.ExamsRepository.GetById(id);
            boolList.Add(updatedExam.ExamDate == examObjCase.ExamDate ? true : false);

            updatedExam.ExamDate = tmp.ExamDate;
            dbContext.ExamsRepository.Update();

            bool isEqualCollections = boolList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }

        /// <summary>
        /// Method for testing the update of results of exam in the database
        /// </summary>
        [TestMethod]
        public void UpdateResultsOfExamTest()
        {
            List<bool> boolList = new List<bool>();
            int id = 7;

            ResultsOfExam resultsOfExam = dbContext.ResultsOfExamsRepository.GetById(id);
            ResultsOfExam tmp = new ResultsOfExam();
            tmp.Result = resultsOfExam.Result;

            resultsOfExam.Result = 2;
            boolList.Add(dbContext.ResultsOfExamsRepository.Update());

            ResultsOfExam updatedResultsOfExam = dbContext.ResultsOfExamsRepository.GetById(id);
            boolList.Add(updatedResultsOfExam.Result == resultsExamObjCase.Result ? true : false);

            updatedResultsOfExam.Result = tmp.Result;
            dbContext.ResultsOfExamsRepository.Update();

            bool isEqualCollections = boolList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }
    }
}
