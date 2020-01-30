using System.Data.Linq.Mapping;

namespace Task7ORM.Models
{
    /// <summary>
    /// Class which represent model of Speciality of database
    /// </summary>
    [Table(Name = "Specialities")]
    public class Speciality
    {
        /// <summary>
        /// Property which storage primary key of speciality
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public int Id { get; set; }

        /// <summary>
        /// Property which storage name of speciality
        /// </summary>
        [Column(Name = "Name")]
        public string Name { get; set; }
    }
}
