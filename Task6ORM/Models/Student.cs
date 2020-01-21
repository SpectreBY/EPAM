using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6ORM.Enums;

namespace Task6ORM.Models
{
    public class Student : BaseModel
    {
        public string FullName { get; set; }
        public Genders Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Group Group { get; set; }
        public string GenderDescription => Gender == Genders.Male ? "Мужской" : "Женский";
    }
}
