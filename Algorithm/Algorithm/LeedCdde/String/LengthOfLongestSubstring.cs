using System;
using System.Linq;
using NUnit.Framework;

namespace Algorithm.LeedCdde.String
{
    [TestFixture]
    class LengthOfLongestSubstring
    {
        public int GetLengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            var max = 1;

            var sub = string.Empty;
            for (var i = 0; i < s.Length; i++)
            {
                if (sub.Contains(s[i]))
                {
                    max = Math.Max(max, sub.Length);
                    sub = sub.Substring(sub.IndexOf(s[i]) + 1)+s[i];
                }
                else
                {
                    sub += s[i];
                }

                if (i == s.Length - 1)
                    max = Math.Max(max, sub.Length);
            }

            return max;

        }

        [Test]
        public void TestCase_Simpe()
        {
            var input = "aab";
            var output = GetLengthOfLongestSubstring(input);
            Assert.AreEqual(2,output);
        }
    }
}
