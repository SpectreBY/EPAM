using System.Data.Linq.Mapping;

namespace Task7ORM.Models
{
    /// <summary>
    /// Class which represent model of Session of database
    /// </summary>
    [Table(Name = "Sessions")]
    public class Session
    {
        /// <summary>
        /// Property which storage primary key of session
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public int Id { get; set; }

        /// <summary>
        /// Property which storage education period of session
        /// </summary>
        [Column(Name = "EducationPeriod")]
        public string EducationPeriod { get; set; }

        /// <summary>
        /// Property which storage semestr of education period
        /// </summary>
        [Column(Name = "Semestr")]
        public int Semestr { get; set; }
    }
}
