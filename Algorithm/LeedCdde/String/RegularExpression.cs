using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Algorithm.LeedCdde.String
{
    [TestFixture()]
    class RegularExpression
    {
        [Test]
        public void Should_Return_Expected_Result()
        {
            var s = "ab";
            var p = ".*";
            var result = IsMatch(s, p);
            Assert.IsTrue(result);
        }
        public bool IsMatch(string s, string p)
        {

            var expectedChar = s[0];
            var extectedCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == expectedChar)
                    extectedCount++;
                else
                {
                    if (!IsTmpMatch(expectedChar, extectedCount, ref p))
                        return false;
                    expectedChar = s[i];
                    extectedCount = 1;
                }
            }
            return false;
        }

        private bool IsTmpMatch(char expectedChar, int extectedCount, ref string p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                if(p[i] == '.' || p[i] == expectedChar)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
