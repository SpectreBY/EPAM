using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    /// <summary>
    /// Class which represent model of Session of database
    /// </summary>
    public class Session : BaseModel
    {
        /// <summary>
        /// Property which storage education period of session
        /// </summary>
        public string EducationPeriod { get; set; }

        /// <summary>
        /// Property which storage semestr of education period
        /// </summary>
        public int Semestr { get; set; }
    }
}
