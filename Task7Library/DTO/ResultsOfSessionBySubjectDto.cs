using System.Data.Linq.Mapping;

namespace Task7ORM.DTO
{
    /// <summary>
    /// Class which represent model with Results Of Session By Subject
    /// </summary>
    public class ResultsOfSessionBySubjectDto
    {
        /// <summary>
        /// Property which storage name of subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Property which storage education period
        /// </summary>
        public string SessionPeriod { get; set; }

        /// <summary>
        /// Property which storage middleMark of education period
        /// </summary>
        public double MiddleMark { get; set; }
    }
}
