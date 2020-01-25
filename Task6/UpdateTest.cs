using System;
using Task6ORM;
using Task6ORM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Task6
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
        private const string connectionString = @"Data Source=(local);Initial Catalog=Task6DB;Integrated Security=True";

        /// <summary>
        /// Object for access to repositories
        /// </summary>
        private DbContext dbContext = DbContext.GetInstance(connectionString);

        /// <summary>
        /// Cases for testing entities
        /// </summary>
        #region Test cases
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
                Name = "ИТ-51"
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
        /// Method for testing the update of student in the database
        /// </summary>
        [TestMethod]
        public void UpdateStudentTest()
        {
            List<bool> boolList = new List<bool>();
            int id = 0;

            Student student = (Student)dbContext.StudentsRepository.GetById(id);
            Student tmp = new Student();
            tmp.Id = student.Id;
            tmp.FullName = student.FullName;
            tmp.Gender = student.Gender;
            tmp.DateOfBirth = student.DateOfBirth;
            tmp.Group = student.Group;

            student.DateOfBirth = DateTime.Now.Date;
            student.FullName = "Иванов Иван Иванович";
            boolList.Add(dbContext.SessionsRepository.Update(student));
            
            Student updatedStudent = (Student)dbContext.StudentsRepository.GetById(id);
            boolList.Add(updatedStudent.FullName == studentObjCase.FullName && 
                         updatedStudent.DateOfBirth == studentObjCase.DateOfBirth ? true : false);

            dbContext.SessionsRepository.Update(tmp);

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

            Group group = (Group)dbContext.GroupsRepository.GetById(id);
            Group tmp = new Group();
            tmp.Id = group.Id;
            tmp.Name = group.Name;

            group.Name = "ИТ-51";
            boolList.Add(dbContext.GroupsRepository.Update(group));

            Group updatedGroup = (Group)dbContext.GroupsRepository.GetById(id);
            boolList.Add(updatedGroup.Name == groupObjCase.Name ? true : false);

            dbContext.GroupsRepository.Update(tmp);

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

            Subject subject = (Subject)dbContext.SubjectsRepository.GetById(id);
            Subject tmp = new Subject();
            tmp.Id = subject.Id;
            tmp.Name = subject.Name;

            subject.Name = "ОМИМОД";
            boolList.Add(dbContext.SubjectsRepository.Update(subject));

            Subject updatedSubject = (Subject)dbContext.SubjectsRepository.GetById(id);
            boolList.Add(updatedSubject.Name == subjectObjCase.Name ? true : false);

            dbContext.SubjectsRepository.Update(tmp);

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

            Session session = (Session)dbContext.SessionsRepository.GetById(id);
            Session tmp = new Session();
            tmp.Id = session.Id;
            tmp.EducationPeriod = session.EducationPeriod;
            tmp.Semestr = session.Semestr;

            session.EducationPeriod = "2010-2011";
            session.Semestr = 1;
            boolList.Add(dbContext.SubjectsRepository.Update(session));

            Session updatedSession = (Session)dbContext.SessionsRepository.GetById(id);
            boolList.Add(updatedSession.EducationPeriod == sessionObjCase.EducationPeriod && 
                         updatedSession.Semestr == sessionObjCase.Semestr ? true : false);

            dbContext.SubjectsRepository.Update(tmp);

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

            Exam exam = (Exam)dbContext.ExamsRepository.GetById(id);
            Exam tmp = new Exam();
            tmp.Id = exam.Id;
            tmp.Session = exam.Session;
            tmp.ExamDate = exam.ExamDate;
            tmp.SubjectsOfGroup = exam.SubjectsOfGroup;

            exam.ExamDate = DateTime.Now.Date;
            boolList.Add(dbContext.ExamsRepository.Update(exam));

            Exam updatedExam = (Exam)dbContext.ExamsRepository.GetById(id);
            boolList.Add(updatedExam.ExamDate == examObjCase.ExamDate ? true : false);

            dbContext.ExamsRepository.Update(tmp);

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

            ResultsOfExam resultsOfExam = (ResultsOfExam)dbContext.ResultsOfExamsRepository.GetById(id);
            ResultsOfExam tmp = new ResultsOfExam();
            tmp.Id = resultsOfExam.Id;
            tmp.Exam = resultsOfExam.Exam;
            tmp.Student = resultsOfExam.Student;
            tmp.Result = resultsOfExam.Result;

            resultsOfExam.Result = 2;
            boolList.Add(dbContext.ResultsOfExamsRepository.Update(resultsOfExam));

            ResultsOfExam updatedResultsOfExam = (ResultsOfExam)dbContext.ResultsOfExamsRepository.GetById(id);
            boolList.Add(updatedResultsOfExam.Result == resultsExamObjCase.Result ? true : false);

            dbContext.ResultsOfExamsRepository.Update(tmp);

            bool isEqualCollections = boolList.Contains(false);
            Assert.IsTrue(!isEqualCollections);
        }
    }
}
