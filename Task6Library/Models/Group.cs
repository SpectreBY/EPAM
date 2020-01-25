using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    /// <summary>
    /// Class which represent model of Group of database
    /// </summary>
    public class Group : BaseModel
    {
        /// <summary>
        /// Property which storage name of group
        /// </summary>
        public string Name { get; set; }
    }
}
