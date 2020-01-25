using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    /// <summary>
    /// Class which represent model of Subjects of groups of database
    /// </summary>
    public class SubjectsOfGroup : BaseModel
    {
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
