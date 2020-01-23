using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    public class ResultsOfExam : BaseModel
    {
        public Exam Exam { get; set; }
        public Student Student { get; set; }
        public string Result { get; set; }
    }
}
