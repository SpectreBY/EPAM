using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    public class Student : BaseModel
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Group Group { get; set; }
    }
}
