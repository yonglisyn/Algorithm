using NUnit.Framework;

namespace Algorithm.LeedCdde.String
{
    [TestFixture]
    class StringToInt
    {
        [TestCase("   111111asdfa", 111111)]
        [TestCase("   -", 0)]
        [TestCase("   -1.1111", -1)]
        [TestCase("   -a1.1111", 0)]
        [TestCase("   1.1111", 1)]
        [TestCase("   1.1111", 1)]
        [TestCase("   +1.1111", 1)]
        public void String_To_Int(string input,int result)
        {
            var output = MyAtoi(input);
            Assert.AreEqual(result, output);
        }

        private int MyAtoi(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;
            var trimed = input.Replace(" ", "");
            var firstNonIntIndex = -1;
            bool isNegative = trimed[0]=='-';
            bool isPositive = trimed[0] == '+';
            bool shouldCut = true;
            var tmp = 0;
            for (int i = 0; i < trimed.Length; i++)
            {
                if (!((isNegative|| isPositive) && i == 0) && !int.TryParse(trimed[i].ToString(), out tmp))
                {
                    shouldCut = false;
                    break;
                }
                firstNonIntIndex++;
            }

            if (firstNonIntIndex == -1)
            {
                return 0;
            }

            var intString = trimed.Substring(0, firstNonIntIndex + 1);
            var max = int.MaxValue;
            var min = int.MinValue;

            if (intString == "-" || intString == "+")
                return 0;


            if (isNegative && !int.TryParse(intString,out tmp))
            {
                return min;
            }

            if (!int.TryParse(intString, out tmp))
            {
                return max;
            }

            return int.Parse(intString);

        }
    }
}
