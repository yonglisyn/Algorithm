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
    class Matrix
    {
        public bool IsToeplitzMatrix(int[,] matrix)
        {
            var rowNum = matrix.GetUpperBound(0);
            var colNum = matrix.GetUpperBound(1);

            for (var i = rowNum - 1; i > 0; i--)
            {
                for (var j = 0; j < colNum - 1; j++)
                {
                    var expected = matrix[i, j + 1];
                    var actual = matrix[i - 1, j];
                    if (expected != actual)
                        return false;
                }
            }
            return true;
        }

        [Test]
        public void Dummy()
        {
            var input = new[,] {{1, 2},
                {2, 2}};
            IsToeplitzMatrix(input);
        }
    }
}
