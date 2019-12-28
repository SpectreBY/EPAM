using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Lib
{
    [Serializable]
    public class MathTestForm
    {
        public MathTestForm()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="testName"></param>
        /// <param name="testDate"></param>
        /// <param name="testScore"></param>
        public MathTestForm(string studentName, string testName, DateTime testDate, int testScore)
        {
            StudentName = studentName;
            TestName = testName;
            TestDate = testDate;
            TestScore = testScore;
        }

        public string StudentName { get; set; }
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public int TestScore { get; set; }
    }
}
