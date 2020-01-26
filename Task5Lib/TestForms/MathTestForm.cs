using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Lib
{
    /// <summary>
    /// Thats class represents math subject test form
    /// </summary>
    [Serializable]
    public class MathTestForm : TestForm
    {
        /// <summary>
        /// Contructor without parameters
        /// </summary>
        public MathTestForm()
        { }

        /// <summary>
        /// Constructor whith few parameters
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="testName"></param>
        /// <param name="testDate"></param>
        /// <param name="testScore"></param>
        public MathTestForm(string studentName, string testName, DateTime testDate, int testScore) : base(studentName, testName, testDate, testScore)
        { }
    }
}
