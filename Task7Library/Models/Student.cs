using System;
using System.Data.Linq.Mapping;

namespace Task7ORM.Models
{
    /// <summary>
    /// Class which represent model of Student of database
    /// </summary>
    [Table(Name = "Students")]
    public class Student
    {
        /// <summary>
        /// Property which storage name of group
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public int Id { get; set; }

        /// <summary>
        /// Property which storage full name of student
        /// </summary>
        [Column(Name = "FullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Property which storage gender of student
        /// </summary>
        [Column(Name = "Gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Property which storage date of birth of student
        /// </summary>
        [Column(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Property which storage group object
        /// </summary>
        [Column(Name = "GroupId")]
        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
