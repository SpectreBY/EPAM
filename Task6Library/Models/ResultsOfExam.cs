using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    /// <summary>
    /// Class which represent model of Results of exam of database
    /// </summary>
    public class ResultsOfExam : BaseModel
    {
        /// <summary>
        /// Property which storage exam object
        /// </summary>
        public Exam Exam { get; set; }

        /// <summary>
        /// Property which storage student object
        /// </summary>
        public Student Student { get; set; }

        /// <summary>
        /// Property which storage result mark
        /// </summary>
        public int Result { get; set; }
    }
}
