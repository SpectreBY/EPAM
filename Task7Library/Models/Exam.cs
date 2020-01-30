using System;
using System.Data.Linq.Mapping;

namespace Task7ORM.Models
{
    /// <summary>
    /// Class which represent model of Exam of database
    /// </summary>
    [Table(Name = "Exams")]
    public class Exam
    {
        /// <summary>
        /// Property which storage primary key of exam
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public int Id { get; set; }

        /// <summary>
        /// Property which storage session id
        /// </summary>
        [Column(Name = "SessionId")]
        public int SessionId { get; set; }

        /// <summary>
        /// Property which storage date of exam
        /// </summary>
        [Column(Name = "ExamDate")]
        public DateTime ExamDate { get; set; }

        /// <summary>
        /// Property which storage subjects of group id
        /// </summary>
        [Column(Name = "SubjectsOfGroupId")]
        public int SubjectsOfGroupId { get; set; }

        /// <summary>
        /// Property which storage teacher id
        /// </summary>
        [Column(Name = "TeacherId")]
        public int TeacherId { get; set; }

        /// <summary>
        /// Property which storage object of Session
        /// </summary>
        public Session Session { get; set; }

        /// <summary>
        /// Property which storage object of SubjectsOfGroup
        /// </summary>
        public SubjectsOfGroup SubjectsOfGroup { get; set; }

        /// <summary>
        /// Property which storage object of Teacher
        /// </summary>
        public Teacher Teacher { get; set; }
    }
}
