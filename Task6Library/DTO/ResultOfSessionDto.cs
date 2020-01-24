using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    public class ResultOfSessionDto
    {
        public string EducationPeriod { get; set; }
        public List<string> MaxMarksGroups = new List<string>();
        public List<string> MiddleMarksGroups = new List<string>();
        public List<string> MinMarksGroups = new List<string>();
    }
}
