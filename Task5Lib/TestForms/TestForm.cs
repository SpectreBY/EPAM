using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Lib
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class TestForm
    {
        /// <summary>
        /// Contructor without parameters
        /// </summary>
        public TestForm()
        { }

        /// <summary>
        /// Constructor whith few parameters
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="testName"></param>
        /// <param name="testDate"></param>
        /// <param name="testScore"></param>
        public TestForm(string studentName, string testName, DateTime testDate, int testScore)
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
