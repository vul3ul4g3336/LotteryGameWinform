using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 樂透
{
    public class LotteryService
    {
        List<string> SelectedNumbers = new List<string>();
        List<string> OpeningNumbers = new List<string>();
        public (bool, string) ChooseNumbers(string number)
        {
            if (SelectedNumbers.Count >= 6)
            {
                return (false, "不可以選超過六位以上的數字!");
            }

            if (SelectedNumbers.Contains(number))
            {
                return (false, "該數字已經選擇過了!");
            }
            SelectedNumbers.Add(number);
            return (true, "");
        }
        public bool ConfirmNum()
        {
            if (SelectedNumbers.Count == 6) { return true; }
            return false;
        }
        public string GetSelectNumber()
        {
            String NumList = null;
            for (int i = 0; i < SelectedNumbers.Count; i++)
            {
                NumList += SelectedNumbers[i] + " ";
            }
            return NumList;
        }
        public (bool, string) DeleteNum()
        {

            String LastNum = SelectedNumbers.LastOrDefault();
            if (LastNum != null)
            {
                SelectedNumbers.Remove(LastNum);

                return (true, LastNum);

                //int index = textBox1.Text.IndexOf(lastNumber);
                //textBox1.Text = textBox1.Text.Substring(0, index);
                //List<string> numbers = textBox1.Text.Split(' ').ToList(); // 1 2 3 4  => [1,2,3,4]
                //numbers.RemoveAt(numbers.Count - 1);
                //textBox1.Text = string.Join(" ", numbers);

            }
            return (false, null);
        }
        public string GetOpeningNum()
        {
            string numbers = null;
            OpeningNumbers = Utility.GenerateNum(7, 49);
            for (int i = 0; i < OpeningNumbers.Count; i++)
            {
                numbers += OpeningNumbers[i] + " ";
            }
            return numbers;
        }
        public (string, string) LotteryDraw()
        {
            bool specialNum = false;
            if (SelectedNumbers.Contains(OpeningNumbers[OpeningNumbers.Count - 1]))
            {
                specialNum = true;
                //SelectedNumbers.Remove(OpeningNumbers[OpeningNumbers.Count - 1]);
            }
            var result = Utility.CountofRepeatNum(SelectedNumbers, OpeningNumbers);
            string prizeName = PrizeName(specialNum, result.Item1);
            return (result.Item2, prizeName);
        }
        public string PrizeName(bool specialNum, int NumOfWinning)
        {
            string awardName = null;
            if (NumOfWinning == 6)
            {
                if (!specialNum)
                {
                    return awardName = "頭獎";
                }
                else
                {
                    return awardName = "二獎";
                }

            }
            if (NumOfWinning == 5)
            {
                if (!specialNum)
                {
                    return awardName = "三獎";
                }
                else
                {
                    return awardName = "四獎";
                }

            }
            if (NumOfWinning == 4)
            {
                if (!specialNum)
                {
                    return awardName = "五獎";
                }
                else
                {
                    return awardName = "六獎";
                }

            }
            if (NumOfWinning == 3)
            {
                if (!specialNum)
                {
                    return awardName = "普獎";
                }
                else
                {
                    return awardName = "七獎";
                }

            }
            return awardName = "未中獎";
        }
    }
}
