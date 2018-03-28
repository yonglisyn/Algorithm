using NUnit.Framework;

namespace Algorithm.LeedCdde.String
{
    [TestFixture]
    class LongestPalindromicString
    {
        [Test]
        public void Should_Return_Longest_Palindromic_String()
        {
            var input = "abadd";
            var output = GetLongestPalindrome(input);
            Assert.AreEqual("aba", output);
        }

        public string GetLongestPalindrome(string s)
        {
            var max = 0;
            var start = 0;
            var end = 0;
            for (var i = 0; i < s.Length; i++)
            {
                TryOddPalindrome(i, s, out var tmpStart, out var tmpEnd);
                if (tmpEnd - tmpStart + 1 > max)
                {
                    max = tmpEnd - tmpStart + 1;
                    start = tmpStart;
                    end = tmpEnd;
                }
                TryEvenPalindrome(i, s, out tmpStart, out tmpEnd);
                if (tmpEnd - tmpStart + 1 > max)
                {
                    max = tmpEnd - tmpStart + 1;
                    start = tmpStart;
                    end = tmpEnd;
                }
            }
            return s.Substring(start, end - start + 1);
        }


        private void TryEvenPalindrome(int start, string source, out int tmpStart, out int tmpEnd)
        {
            var count = 0;
            for (var i = 0; i <= start && i + start+1 < source.Length; i++)
            {
                if (source[start - i] == source[start + i+1])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            tmpStart = start-count+1;
            tmpEnd = start+count;
        }

        private void TryOddPalindrome(int start, string source, out int tmpStart, out int tmpEnd)
        {
            var count = 0;
            for (var i = 1; i <=start && i+start<source.Length; i++)
            {
                if (source[start - i] == source[start + i])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            tmpStart = start-count;
            tmpEnd = start+count;
        }
    }
}
