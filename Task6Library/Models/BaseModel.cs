using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    /// <summary>
    /// Abstract class which represent abstract base entity of database
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Property which storage id
        /// </summary>
        public int Id { get; set; }
    }
}
