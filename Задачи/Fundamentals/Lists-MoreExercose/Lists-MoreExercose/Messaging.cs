using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists_MoreExercose
{
    class Messaging
    {
        static void Main(string[] args)
        {
            List<string> numbersList = Console.ReadLine().Split().ToList();
            List<char> text = Console.ReadLine().ToList();
            string result = string.Empty;

            foreach (string item in numbersList)
            {
                int index = SumDigits(item);

                while (true)
                {
                    if (index >= 0 && index < text.Count)
                    {
                        result += text[index];
                        text.RemoveAt(index);
                        break;
                    }
                    else
                    {
                        index -= text.Count;
                    }
                }
            }

            Console.WriteLine(result);
        }

        static int SumDigits(string number)
        {
            int sum = 0;

            foreach (char item in number)
            {
                sum += int.Parse(item.ToString());
            }

            return sum;
        }
    }
}
