using System.Data.Linq.Mapping;

namespace Task7ORM.DTO
{
    /// <summary>
    /// Class which represent model of Session of database
    /// </summary>
    public class SessionDto
    {
        /// <summary>
        /// Property which storage name of group
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property which storage education period of session
        /// </summary>
        public string EducationPeriod { get; set; }

        /// <summary>
        /// Property which storage semestr of education period
        /// </summary>
        public int Semestr { get; set; }
    }
}
