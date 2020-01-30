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
        /// Property which storage name of group
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public int Id { get; set; }

        /// <summary>
        /// Property which storage session object
        /// </summary>
        [Column(Name = "SessionId")]
        public int SessionId { get; set; }

        /// <summary>
        /// Property which storage date of exam
        /// </summary>
        [Column(Name = "ExamDate")]
        public DateTime ExamDate { get; set; }

        /// <summary>
        /// Property which storage subjectds of group object
        /// </summary>
        [Column(Name = "SubjectsOfGroupId")]
        public int SubjectsOfGroupId { get; set; }

        /// <summary>
        /// Property which storage subjectds of group object
        /// </summary>
        [Column(Name = "TeacherId")]
        public int TeacherId { get; set; }

        public Session Session { get; set; }

        public SubjectsOfGroup SubjectsOfGroup { get; set; }

        public Teacher Teacher { get; set; }
    }
}
