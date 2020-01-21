using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    public class Group : BaseModel
    {
        public string Name { get; set; }
        public int Course { get; set; }
    }
}
