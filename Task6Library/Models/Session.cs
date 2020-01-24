using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    public class Session : BaseModel
    {
        public string EducationPeriod { get; set; }
        public int Semestr { get; set; }
    }
}
