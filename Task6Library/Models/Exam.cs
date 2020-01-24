using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Models
{
    public class Exam : BaseModel
    {
        public Session Session { get; set; }
        public DateTime ExamDate { get; set; }
        public SubjectsOfGroup SubjectsOfGroup { get; set; }
    }
}
