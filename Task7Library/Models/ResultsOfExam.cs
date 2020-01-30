using System.Data.Linq.Mapping;

namespace Task7ORM.Models
{
    /// <summary>
    /// Class which represent model of Results of exam of database
    /// </summary>
    [Table(Name = "ResultsOfExams")]
    public class ResultsOfExam
    {
        /// <summary>
        /// Property which storage primary key of results of exam
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public int Id { get; set; }

        /// <summary>
        /// Property which storage exam id
        /// </summary>
        [Column(Name = "ExamId")]
        public int ExamId { get; set; }

        /// <summary>
        /// Property which storage student id
        /// </summary>
        [Column(Name = "StudentId")]
        public int StudentId { get; set; }

        /// <summary>
        /// Property which storage result mark
        /// </summary>
        [Column(Name = "Result")]
        public int Result { get; set; }

        /// <summary>
        /// Property which storage object of Exam
        /// </summary>
        public Exam Exam { get; set; }

        /// <summary>
        /// Property which storage object of Student
        /// </summary>
        public Student Student { get; set; }
    }
}
