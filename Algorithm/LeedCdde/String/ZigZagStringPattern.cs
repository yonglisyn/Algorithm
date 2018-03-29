using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Algorithm.LeedCdde.String
{
    [TestFixture]
    class ZigZagStringPattern
    {
        [Test]
        public void Should_return_Valid_Result()
        {
            var timer = new Stopwatch();
            timer.Start();
            var input = "yjvsbxetkierlqfbxyetjbyqqgrtrurpfmkhjocwyjpjzunxsrqdurtkxngqjxgokqxvgarejgqkadhuuayortbqgjhpgpgsfdolffrqmhbokklgklxdeywnhfepukibqwoxbfqpnrgzdrgocdtidpxmucbqojrghfelnuaangzszhibmcmptjbqnfgcoykyfojskluzuwstdaxqejhyuloiqumguwecnnuzbpzvntoqvliawsatdobtkpzhlejytfauwzrjugcptmrserlhhoaudcboimpdrpaqqrzmxddtqvluoweymgspitfshwwynwqfnqrnvvilstiirmgduyuftzxawvbjrrphjiwffgszzcisqoxlprqkqnloloaehrltzjahpsgqxoknfhywyogrethphhtrahkcsmjkgpcdgnrnwpjxgpqkjxbshwlhfxjyjskqkmtqbkdycovidnuokvjrtubzukzdfjtpxphzzmzbawlfjfuvcfpwbqxvcyzhhuygjhhltgoteaznhvlkaaidqhzsfacoucwekerfmfzrhagpxrbxtlajsbezbgnwklcupvaeabviddxaxazqlbcddgcgoreacixudzyeavofanfxngqyhubmaftqyzqcinylowrotfvusctfijdsdggfnbxnbqsjfqwupokitgcmiwtthxlnfruvtsiuiafprbjgpuq";
            var output = Convert(input, 415);
            timer.Stop();
            TestContext.WriteLine(timer.Elapsed.Milliseconds);

            Assert.AreEqual("yjvsbxetkierlqfbxyetjbyqqgrtrurpfmkhjocwyjpjzunxsrqdurtkxngqjxgokqxvgarejgqkadhuuayortbqgjhpgpgsfdolffrqmhbokklgklxqduepygwjnbhrfpefpauikuiibsqtwvouxrbffnqlpxnhrtgtzwdirmgcogctditkiodppuxwmqufcjbsqqobjnrxgbhnffeglgndusadajnigfztsczshuivbfmtcomrpwtojlbyqnnifcgqczoyyqktyffaomjbsukhlyuqzgunwxsftndaafxoqveajehyyzudluoxiiqcuamegruowgeccgndnduczbblpqzzvanxtaoxqdvdliivabwaseaatvdpoubctlkkpwznhglbezjeybtsfjaaulwtzxrbjruxgpcgpathmrrzsfemrflrhehkoeawucducobcoaifmspzdhrqpdaiqaqarkzlmvxhdndztaqevtlougotwlehyhmjggsypuihthfzsyhcwvwxyqnbwwqpffncqvrunfvjvfillwsatbizimrzmzghdpuxyputfjtfzdxzakwuvzbbjurtrrpjhvjkiowufnfdgisvzozccyidskqboqxtlmpkrqqkksqjnyljoxlfohalewhhrslbtxzjjkaqhppgsxgjqpxwonkrnnfghdycwpygokgjrmestchkphhahrt", output);
        }

        public string Convert2(string s, int numRows)
        {
                if (numRows == 0)
                    return string.Empty;

                string[] str = new string[numRows];
                int strNext = 0;
                bool increasing = true;
                for (int i = 0; i < s.Length; i++)
                {
                    str[strNext] = str[strNext] + s[i].ToString();

                    if (increasing && strNext == str.Count() - 1)
                    {
                        strNext--;
                        increasing = false;
                    }
                    else if (increasing && strNext < str.Count() - 1)
                    {
                        strNext++;
                    }
                    else if (!increasing && strNext > 0)
                    {
                        strNext--;
                    }
                    else if (!increasing && strNext == 0)
                    {
                        strNext++;
                        increasing = true;
                    }

                    // extreme case, when the rows count is 1
                    if (numRows == 1)
                    {
                        strNext = 0;
                    }
                }

                StringBuilder output = new StringBuilder();
                for (int i = 0; i < numRows; i++)
                {
                    output.Append(str[i]);
                }
                return output.ToString();
            }

        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }
            var result = new List<string>();
            for (int i = 0; i < numRows; i++)
            {
                result.Add(string.Empty);
            }
            var currentStateIncrease = true;
            var row = 0;
            for (var j = 0; j < s.Length; j++)
            {
                result[row]+= s[j];
                currentStateIncrease = IsIncrease(currentStateIncrease, row,j, numRows);
                if (currentStateIncrease)
                    row++;
                else
                {
                    row--;
                }

            }
            var resutlStr = string.Concat(result.Select(x => string.Concat(x)));
            return resutlStr.Replace(" ", string.Empty);
        }

        private bool IsIncrease(bool currentStateIncrease, int row, int i, int numRows)
        {
            if (currentStateIncrease && row < numRows-1)
                return true;
            if (currentStateIncrease && row == numRows - 1)
                return false;
            if (!currentStateIncrease && row > 0)
                return false;
            if (!currentStateIncrease && row == 0)
                return true;
            return true;
        }
    }
}
