using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Algorithm.LeedCdde.Array
{
    [TestFixture]
    class Permutation
    {
        [Test]
        public void MaxChunksToMakeSorted()
        {
            var input = new int[] {1, 2, 0, 3, 4};
            var expected = 3;
            var result = GetMaxNumberOfChunksToMakeSorted(input);
        }

        private int GetMaxNumberOfChunksToMakeSorted(int[] input)
        {
            var anchor = 0;
            var count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == anchor)
                    count++;
                anchor = Math.Max(anchor, input[i]);
            }
            return count;
        }
    }
}
