using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    /// <summary>
    /// Model which represents result of sessions with extra info about groups
    /// </summary>
    public class ResultOfSessionDto
    {
        /// <summary>
        /// Property which storage of education period
        /// </summary>
        public string EducationPeriod { get; set; }

        /// <summary>
        /// Property which storage list of maximum of groups marks
        /// </summary>
        public List<string> MaxMarksGroups = new List<string>();

        /// <summary>
        /// Property which storage list of minimal of groups marks
        /// </summary>
        public List<string> MiddleMarksGroups = new List<string>();

        /// <summary>
        /// Property which storage list of middle of groups marks
        /// </summary>
        public List<string> MinMarksGroups = new List<string>();
    }
}
