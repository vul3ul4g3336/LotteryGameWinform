using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 樂透
{
    public class Utility
    {
        public static List<string> GenerateNum(int n, int m)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            List<string> WinningNumbers = new List<string>();
            HashSet<string> WinningNum = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                int Num = random.Next(1, m + 1);
                WinningNum.Add(Num.ToString());
                if (WinningNum.Count == i)
                {
                    i -= 1;
                }
            }
            WinningNumbers = WinningNum.ToList();
            return WinningNumbers;
        }

        public static (int, string) CountofRepeatNum(List<string> SelectedNum, List<string> OpeningNum)
        {
            int CountofPlayerWinningNum = 0;
            string RepeatNum = "";
            for (int i = 0; i < SelectedNum.Count; i++)
            {
                if (OpeningNum.Contains(SelectedNum[i]))
                {
                    CountofPlayerWinningNum++;
                    RepeatNum += SelectedNum[i] + " ";
                }
            }
            return (CountofPlayerWinningNum, RepeatNum);
        }
    }
}
