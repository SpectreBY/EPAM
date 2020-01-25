using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6ORM.Models;

namespace Task6Library
{
    /// <summary>
    /// Helper class which represents functionality for get expelled student data and get total sessions results data
    /// </summary>
    public class SessionHelper
    {
        /// <summary>
        /// constant field which storage minimum mark for grade a exam
        /// </summary>
        private const int MinimalMark = 4;

        /// <summary>
        /// Method which return data with expelled students
        /// </summary>
        /// <param name="resultsOfExams"></param>
        /// <returns></returns>
        public List<ExpelledStudentDto> GetExpelledStudents(List<BaseModel> resultsOfExams)
        {
            List<ExpelledStudentDto> expelledStudents = new List<ExpelledStudentDto>();
            List<ResultsOfExam> results = new List<ResultsOfExam>();
            resultsOfExams.ForEach(o => results.Add((ResultsOfExam)o));
            var groups = results.Where(o => o.Result < MinimalMark)
                                             .GroupBy(o => o.Student.Group.Name)
                                             .ToList();
            foreach(var group in groups)
            {
                ExpelledStudentDto expelledStudentDto = new ExpelledStudentDto();
                expelledStudentDto.Group = group.Key;
                foreach(ResultsOfExam resultsOfExam in group)
                {
                    expelledStudentDto.ExpelledStudents.Add(resultsOfExam.Student.FullName);
                }
                expelledStudents.Add(expelledStudentDto);
            }
            return expelledStudents;
        }

        /// <summary>
        /// Method which return data with total results of sessions
        /// </summary>
        /// <param name="resultsOfExams"></param>
        /// <returns></returns>
        public List<ResultOfSessionDto> GetTotalResultsOfSessions (List<BaseModel> resultsOfExams)
        {
            List<List<IGrouping<string, ResultsOfExam>>> list = new List<List<IGrouping<string, ResultsOfExam>>>();
            List<ResultOfSessionDto> resultOfSessions = new List<ResultOfSessionDto>();
            List<ResultsOfExam> results = new List<ResultsOfExam>();

            resultsOfExams.ForEach(o => results.Add((ResultsOfExam)o));
            var sessions = results.GroupBy(o => o.Exam.Session.EducationPeriod);

            foreach(var session in sessions)
            {
                var obj = session.GroupBy(o => o.Student.Group.Name).ToList();
                list.Add(obj);
            }
            
            foreach (var session in list)
            {
                ResultOfSessionDto resultOfSessionDto = new ResultOfSessionDto();
                foreach (var group in session)
                {
                    int max = group.Max(o => o.Result);
                    int min = group.Min(o => o.Result);
                    double middle = group.Sum(o => o.Result) / (double)group.Count();
                    string period = group.Select(o => o.Exam.Session.EducationPeriod).FirstOrDefault();
                    string groupStr = group.Key;
                    string maxStr = string.Format("Группа: {0}. Максимальный балл: {1}", groupStr, max);
                    string minStr = string.Format("Группа: {0}. Минимальный балл: {1}", groupStr, min);
                    string middleStr = string.Format("Группа: {0}. Средний балл: {1}", groupStr, middle);
                    resultOfSessionDto.MaxMarksGroups.Add(maxStr);
                    resultOfSessionDto.MinMarksGroups.Add(minStr);
                    resultOfSessionDto.MiddleMarksGroups.Add(middleStr);
                    if (string.IsNullOrEmpty(resultOfSessionDto.EducationPeriod))
                    {
                        resultOfSessionDto.EducationPeriod = period;
                    }
                }
                resultOfSessions.Add(resultOfSessionDto);
            }
            return resultOfSessions;
        }

    }
}
