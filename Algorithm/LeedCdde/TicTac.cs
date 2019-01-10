using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.LeedCdde
{
    [TestFixture]
    public class TicTac
    {
        public bool ValidTicTacToe(string[] board)
        {
            var patterns = new List<string>();
            var row1 = board[0];
            var row2 = board[1];
            var row3 = board[2];
            var col1 = board[0][0].ToString() + board[1][0].ToString() + board[2][0].ToString();
            var col2 = board[0][1].ToString() + board[1][1].ToString() + board[2][1].ToString();
            var col3 = board[0][2].ToString() + board[1][2].ToString() + board[2][2].ToString();
            var cross1 = board[0][0].ToString() + board[1][1].ToString() + board[2][2].ToString();
            var cross2 = board[2][0].ToString() + board[1][1].ToString() + board[0][2].ToString();
            patterns.Add(row1);
            patterns.Add(row2);
            patterns.Add(row3);
            patterns.Add(col1);
            patterns.Add(col2);
            patterns.Add(col3);
            patterns.Add(cross1);
            patterns.Add(cross1);
            var countX = board[0].Count(a => a == 'X') + board[1].Count(a => a == 'X') + board[2].Count(a => a == 'X');
            var countO = board[0].Count(a => a == 'O') + board[1].Count(a => a == 'O') + board[2].Count(a => a == 'O');

            if (patterns.Any(x => x.Count(a => a == 'X') == 3))
            {
                return countX - countO == 1;
            }

            if (patterns.Any(x => x.Count(a => a == 'O') == 3))
            {
                return countX - countO == 0;
            }

            return countX - countO == 0 || countX - countO == 1;
        }

        [Test]
        public void dummy()
        {
            var input = new string[] { "XXO", "XOX", "OXO" };
            ValidTicTacToe(input);
        }
    }
    
}
