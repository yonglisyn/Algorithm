using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Algorithm.LeedCdde.Array
{
    [TestFixture()]
    class NoTag
    {
        [Test]
        public void AddCalender()
        {
            var cal = new MyCalendarTwo();
            Assert.IsTrue(cal.Book(10, 20));
            Assert.IsTrue(cal.Book(50, 60));
            Assert.IsTrue(cal.Book(10, 40));
            Assert.IsFalse(cal.Book(5, 15));
            Assert.IsTrue(cal.Book(5, 10));
            Assert.IsTrue(cal.Book(25, 55));
        }
    }

    /// <summary>
    /// </summary>
    public class MyCalendarTwo
    {
        private Dictionary<int, int> records = new Dictionary<int, int>();
        private List<KeyValuePair<int, int>> EventSchemaTraceListener = new List<KeyValuePair<int, int>>();


        /// <summary>
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool Book(int start, int end)
        {

            for (var i = start; i < end; i++)
            {
                if (records.TryGetValue(i, out var value))
                {
                    if (value == 2)
                        return false;
                }

            }

            for (var i = start; i < end; i++)
            {
                if (records.ContainsKey(i))
                {
                    records[i]++;
                }
                else
                {
                    records.Add(i,1);
                }
            }
            return true;
        }
    }

    /**
     * Your MyCalendarTwo object will be instantiated and called as such:
     * MyCalendarTwo obj = new MyCalendarTwo();
     * bool param_1 = obj.Book(start,end);
     */
}
