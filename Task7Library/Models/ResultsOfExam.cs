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
        /// Property which storage name of group
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public int Id { get; set; }

        /// <summary>
        /// Property which storage exam object
        /// </summary>
        [Column(Name = "ExamId")]
        public int ExamId { get; set; }

        /// <summary>
        /// Property which storage student object
        /// </summary>
        [Column(Name = "StudentId")]
        public int StudentId { get; set; }

        /// <summary>
        /// Property which storage result mark
        /// </summary>
        [Column(Name = "Result")]
        public int Result { get; set; }
    }
}
