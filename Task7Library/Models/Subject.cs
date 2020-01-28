using System.Data.Linq.Mapping;

namespace Task7ORM.Models
{
    /// <summary>
    /// Class which represent model of Subject of database
    /// </summary>
    [Table(Name = "Subjects")]
    public class Subject
    {
        /// <summary>
        /// Property which storage name of group
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public int Id { get; set; }

        /// <summary>
        /// Property which storage name of subject
        /// </summary>
        [Column(Name = "Name")]
        public string Name { get; set; }
    }
}
