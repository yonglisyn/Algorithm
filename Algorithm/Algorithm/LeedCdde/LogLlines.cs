using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Algorithm.LeedCdde
{
    [TestFixture()]
    class LogLlines
    {
        [Test]
        public void Return_Expected_Lines_With_Order()
        {
            var logSize = 5;
            var log = new List<string>
            {
                "a1 9 2 3 1",
                "g1 act car",
                "zo4 4 7",
                "ab1 off key dog",
                "a8 act zoo"
            };

            var log2 = new List<string>
            {
                "9 2 3 1 a1",
                "act car g1",
                "4 7 zo4",
                "off key dog ab1",
                "act zo a8"
            };

            log2.OrderBy(x => x, StringComparer.Ordinal);
            foreach (var log1 in log2)
            {
                TestContext.WriteLine(log1);
            }

            var result = GetMyResult(logSize, log);
            Assert.AreEqual(result,null);
        }

        private List<string> GetMyResult(int logSize, List<string> logs)
        {
            var numberLogs = new List<string>();
            var stringLogs = new List<string>();
            foreach (var log in logs)
            {
                var spaceIndex = log.IndexOf(' ');
                var newLog = $"{log.Substring(spaceIndex + 1)} {log.Substring(0, spaceIndex)}";
                var isNumberLog = IsNumberLog(newLog);
                if (isNumberLog)
                {
                    numberLogs.Add(newLog);
                }
                else
                {
                    stringLogs.Add(newLog);
                }
            }
            
            stringLogs.OrderBy(x => string.Join("",x.Split(new[]{' '})), StringComparer.Ordinal);
            stringLogs.AddRange(numberLogs);
            var result = new List<string>();
            foreach (var log in stringLogs)
            {
                var spaceIndex = log.LastIndexOf(' ');
                var newLog = $"{log.Substring(spaceIndex + 1)} {log.Substring(0, spaceIndex)}";
                result.Add(newLog);
            }
            return result;
        }

        private bool IsNumberLog(string newLog)
        {
            var firstCharacter = newLog[0];
            return int.TryParse(firstCharacter.ToString(),out _);
        }
    }
}
