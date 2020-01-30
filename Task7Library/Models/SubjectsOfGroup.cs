using System.Data.Linq.Mapping;

namespace Task7ORM.Models
{
    /// <summary>
    /// Class which represent model of Subjects of groups of database
    /// </summary>
    [Table(Name = "SubjectsOfGroups")]
    public class SubjectsOfGroup
    {
        /// <summary>
        /// Property which storage primary key of subjects of group
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public int Id { get; set; }

        /// <summary>
        /// Property which storage group id
        /// </summary>
        [Column(Name = "GroupId")]
        public int GroupId { get; set; }

        /// <summary>
        /// Property which storage subject id
        /// </summary>
        [Column(Name = "SubjectId")]
        public int SubjectId { get; set; }

        /// <summary>
        /// Property which storage group object
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// Property which storage subject object
        /// </summary>
        public Subject Subject { get; set; }
    }
}
