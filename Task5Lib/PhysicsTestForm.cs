using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Lib
{
    /// <summary>
    /// Thats class represents physics subject test form
    /// </summary>
    [Serializable]
    public class PhysicsTestForm
    {
        /// <summary>
        /// Contructor without parameters
        /// </summary>
        public PhysicsTestForm()
        { }

        /// <summary>
        /// Constructor whith few parameters
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="testName"></param>
        /// <param name="testDate"></param>
        /// <param name="testScore"></param>
        public PhysicsTestForm(string studentName, string testName, DateTime testDate, int testScore)
        {
            StudentName = studentName;
            TestName = testName;
            TestDate = testDate;
            TestScore = testScore;
        }

        /// <summary>
        /// Property for storing student name value
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// Property for storing test name value
        /// </summary>
        public string TestName { get; set; }

        /// <summary>
        /// Property for storing test date value
        /// </summary>
        public DateTime TestDate { get; set; }

        /// <summary>
        /// Property for storing result tests score value
        /// </summary>
        public int TestScore { get; set; }
    }
}
