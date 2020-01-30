using System.Data.Linq.Mapping;

namespace Task7ORM.Models
{
    /// <summary>
    /// Class which represent model of Subjects of groups of database
    /// </summary>
    [Table(Name = "Groups")]
    public class SubjectsOfGroup
    {
        /// <summary>
        /// Property which storage name of group
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public int Id { get; set; }

        /// <summary>
        /// Property which storage group object
        /// </summary>
        [Column(Name = "GroupId")]
        public int GroupId { get; set; }

        /// <summary>
        /// Property which storage subject object
        /// </summary>
        [Column(Name = "SubjectId")]
        public int SubjectId { get; set; }

        public Group Group { get; set; }

        public Subject Subject { get; set; }
    }
}
