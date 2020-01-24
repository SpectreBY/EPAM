using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    public class ExpelledStudentDto
    {
        public string Group { get; set; }
        public List<string> ExpelledStudents = new List<string>();
    }
}
