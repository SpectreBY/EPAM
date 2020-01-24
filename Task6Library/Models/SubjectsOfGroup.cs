using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    public class SubjectsOfGroup : BaseModel
    {
        public Group Group { get; set; }
        public Subject Subject { get; set; }
    }
}
