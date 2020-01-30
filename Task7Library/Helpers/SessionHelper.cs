using System.Collections.Generic;
using System.Linq;
using Task7ORM.Models;
using Task7ORM.DTO;

namespace Task7Library
{
    /// <summary>
    /// Helper class which represents functionality for get expelled student data and get total sessions results data
    /// </summary>
    public class SessionHelper
    {
        /// <summary>
        /// constant field which storage number of first semester
        /// </summary>
        private const int FirstSemester = 1;

        /// <summary>
        ///  constant field which storage number of second semester
        /// </summary>
        private const int SecondSemester = 2;

        /// <summary>
        /// Method which return data with Results Of Session By Speciality
        /// </summary>
        /// <param name="resultsOfExams"></param>
        /// <returns></returns>
        public List<ResultsOfSessionBySpecialityDto> GetResultsOfSessionBySpeciality(List<ResultsOfExam> resultsOfExams)
        {
            List<ResultsOfSessionBySpecialityDto> resultsOfSession = new List<ResultsOfSessionBySpecialityDto>();
            List<IGrouping<string, ResultsOfExam>> results = resultsOfExams.GroupBy(o => o.Student.Group.Speciality.Name).ToList();
            
            foreach(IGrouping<string, ResultsOfExam> result in results)
            {
                
                List<IGrouping<string, ResultsOfExam>> resultsBySessionPeriod = result.GroupBy(o => o.Exam.Session.EducationPeriod)
                                                                                      .ToList();
                foreach (IGrouping<string, ResultsOfExam> period in resultsBySessionPeriod)
                {

                    double firstSemesterMark = result.Where(o => o.Exam.Session.Semestr == FirstSemester).Sum(o => o.Result);
                    double secondSemesterMark = result.Where(o => o.Exam.Session.Semestr == SecondSemester).Sum(o => o.Result);
                    double firstSemesterLength = (double)result.Where(o => o.Exam.Session.Semestr == FirstSemester).Count();
                    double secondSemesterLength = (double)result.Where(o => o.Exam.Session.Semestr == SecondSemester).Count();
                    ResultsOfSessionBySpecialityDto obj = new ResultsOfSessionBySpecialityDto();
                    obj.Speciality = result.Key;
                    obj.SessionPeriod = period.Key;
                    obj.FirstSemestrMiddleMark = firstSemesterMark != 0 ? firstSemesterMark / firstSemesterLength : 0;
                    obj.SecondSemestrMiddleMark = secondSemesterMark != 0 ? secondSemesterMark / secondSemesterLength : 0;
                    resultsOfSession.Add(obj);
                }
            }
            return resultsOfSession;
        }

        /// <summary>
        /// Method which return data with Results Of Session By Teacher
        /// </summary>
        /// <param name="resultsOfExams"></param>
        /// <returns></returns>
        public List<ResultsOfSessionByTeacherDto> GetResultsOfSessionByTeacher(List<ResultsOfExam> resultsOfExams)
        {
            List<ResultsOfSessionByTeacherDto> resultsOfSession = new List<ResultsOfSessionByTeacherDto>();
            List<IGrouping<string, ResultsOfExam>> results = resultsOfExams.GroupBy(o => o.Exam.Teacher.FullName).ToList();

            foreach (IGrouping<string, ResultsOfExam> result in results)
            {

                List<IGrouping<string, ResultsOfExam>> resultsBySessionPeriod = result.GroupBy(o => o.Exam.Session.EducationPeriod)
                                                                                      .ToList();
                foreach (IGrouping<string, ResultsOfExam> period in resultsBySessionPeriod)
                {

                    double firstSemesterMark = result.Where(o => o.Exam.Session.Semestr == FirstSemester).Sum(o => o.Result);
                    double secondSemesterMark = result.Where(o => o.Exam.Session.Semestr == SecondSemester).Sum(o => o.Result);
                    double firstSemesterLength = (double)result.Where(o => o.Exam.Session.Semestr == FirstSemester).Count();
                    double secondSemesterLength = (double)result.Where(o => o.Exam.Session.Semestr == SecondSemester).Count();
                    ResultsOfSessionByTeacherDto obj = new ResultsOfSessionByTeacherDto();
                    obj.Teacher = result.Key;
                    obj.SessionPeriod = period.Key;
                    obj.FirstSemestrMiddleMark = firstSemesterMark != 0 ? firstSemesterMark / firstSemesterLength : 0;
                    obj.SecondSemestrMiddleMark = secondSemesterMark != 0 ? secondSemesterMark / secondSemesterLength : 0;
                    resultsOfSession.Add(obj);
                }
            }
            return resultsOfSession;
        }

        /// <summary>
        /// Method which return data with Results Of Session By Subject
        /// </summary>
        /// <param name="resultsOfExams"></param>
        /// <returns></returns>
        public List<ResultsOfSessionBySubjectDto> GetResultsOfSessionBySubject(List<ResultsOfExam> resultsOfExams)
        {
            List<ResultsOfSessionBySubjectDto> resultsOfSession = new List<ResultsOfSessionBySubjectDto>();
            List<IGrouping<string, ResultsOfExam>> results = resultsOfExams.GroupBy(o => o.Exam.SubjectsOfGroup.Subject.Name).ToList();

            foreach (IGrouping<string, ResultsOfExam> result in results)
            {

                List<IGrouping<string, ResultsOfExam>> resultsBySessionPeriod = result.GroupBy(o => o.Exam.Session.EducationPeriod)
                                                                                      .ToList();
                foreach (IGrouping<string, ResultsOfExam> period in resultsBySessionPeriod)
                {

                    double mark = result.Sum(o => o.Result);
                    double length = (double)result.Count();
                    ResultsOfSessionBySubjectDto obj = new ResultsOfSessionBySubjectDto();
                    obj.Subject = result.Key;
                    obj.SessionPeriod = period.Key;
                    obj.MiddleMark = mark != 0 ? mark / length : 0;
                    resultsOfSession.Add(obj);
                }
            }
            return resultsOfSession;
        }
    }
}
