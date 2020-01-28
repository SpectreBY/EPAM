using System.Data.Linq.Mapping;

namespace Task7ORM.Models
{
    /// <summary>
    /// Class which represent model of Teacher of database
    /// </summary>
    [Table(Name = "Teachers")]
    public class Teacher
    {
        /// <summary>
        /// Property which storage name of group
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public int Id { get; set; }

        /// <summary>
        /// Property which storage full name of teacher
        /// </summary>
        [Column(Name = "FullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Property which storage gender of teacher
        /// </summary>
        [Column(Name = "Gender")]
        public string Gender { get; set; }
    }
}
