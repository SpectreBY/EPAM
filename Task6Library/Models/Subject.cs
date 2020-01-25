using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    /// <summary>
    /// Class which represent model of Subject of database
    /// </summary>
    public class Subject : BaseModel
    {
        /// <summary>
        /// Property which storage name of subject
        /// </summary>
        public string Name { get; set; }
    }
}
