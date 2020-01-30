using System.Data.Linq.Mapping;

namespace Task7ORM.DTO
{
    /// <summary>
    /// Class which represent model with Results Of Session By Teacher
    /// </summary>
    public class ResultsOfSessionByTeacherDto
    {
        /// <summary>
        /// Property which storage name of teacher
        /// </summary>
        public string Teacher { get; set; }

        /// <summary>
        /// Property which storage education period
        /// </summary>
        public string SessionPeriod { get; set; }

        /// <summary>
        /// Property which storage middleMark of first semester
        /// </summary>
        public double FirstSemestrMiddleMark { get; set; }

        /// <summary>
        /// Property which storage middleMark of second semester
        /// </summary>
        public double SecondSemestrMiddleMark { get; set; }
    }
}
