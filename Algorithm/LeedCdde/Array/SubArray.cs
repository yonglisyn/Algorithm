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
    class SubArray
    {
        [Test]
        public void FindLenghCorrect()
        {
            Assert.AreEqual(3,FindLength(new []{1,0,0,0,1}, new[] { 1, 0, 0,1, 1 }));
        }

        private int FindLength(int[] A, int[]B)
        {
            int ans = 0;
            List<List<int>> memo = new List<List<int>>();
            for (int i = 0; i < A.Length+1; i++)
            {
                var tmp = Enumerable.Repeat(0, B.Length + 1).ToList();
                memo.Add(tmp);
            }
            for (int i = A.Length-1; i >=0; i--)
            {
                for (int j = B.Length - 1; j >= 0; j--)
                {
                    if (A[i] == B[j])
                    {
                        memo[i][j] = memo[i + 1][j + 1] + 1;
                        ans = Math.Max(ans, memo[i][j]);
                    }
                }
            }
            return ans;

        }
    }
}
