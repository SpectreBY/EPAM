using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    /// <summary>
    /// Model which represents expelled students
    /// </summary>
    public class ExpelledStudentDto
    {
        /// <summary>
        /// Property which storage of group name
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Property which storage list of expelled students
        /// </summary>
        public List<string> ExpelledStudents = new List<string>();
    }
}
