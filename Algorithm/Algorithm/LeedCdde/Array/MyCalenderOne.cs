using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Algorithm.LeedCdde.Array
{
    [TestFixture()]
    class MyCalenderOne
    {
        [Test]
        public void MyCalenderOneTest()
        {
            var cal = new MyCalendar();
            Assert.AreEqual(cal.Book(37, 50),true);
            Assert.AreEqual(cal.Book(33, 50),false);
            Assert.AreEqual(cal.Book(4, 17),true);
            Assert.AreEqual(cal.Book(35, 48),false);
            Assert.AreEqual(cal.Book(8, 25),false);
        }

        public class MyCalendar
        {
            private List<int> events;
            public MyCalendar()
            {
                events = new List<int>();
            }

            public bool Book(int start, int end)
            {
                for (var i = 0; i < events.Count / 2; i++)
                {
                    var m = 2 * i;
                    if (start < events[m] && end - 1 > events[m + 1])
                    {
                        return false;
                    }
                    if (start >= events[m] && start <= events[m + 1])
                    {
                        return false;
                    }
                    if (end - 1 >= events[m] && end - 1 <= events[m + 1])
                    {
                        return false;
                    }

                }
                events.Add(start);
                events.Add(end - 1);
                events.Sort();
                return true;

            }
        }
    }
}
