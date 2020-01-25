using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    /// <summary>
    /// Class which represent model of Student of database
    /// </summary>
    public class Student : BaseModel
    {
        /// <summary>
        /// Property which storage full name of student
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Property which storage gender of student
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Property which storage date of birth of student
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Property which storage group object
        /// </summary>
        public Group Group { get; set; }
    }
}
