using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    /// <summary>
    /// Class which represent model of Exam of database
    /// </summary>
    public class Exam : BaseModel
    {
        /// <summary>
        /// Property which storage session object
        /// </summary>
        public Session Session { get; set; }

        /// <summary>
        /// Property which storage date of exam
        /// </summary>
        public DateTime ExamDate { get; set; }

        /// <summary>
        /// Property which storage subjectds of group object
        /// </summary>
        public SubjectsOfGroup SubjectsOfGroup { get; set; }
    }
}
