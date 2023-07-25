using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeRope
{
    class TakeRope
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int oddEvenCounter = 1;
            List<char> nonNumbers = new List<char>();
            List<int> oddIndexNumbers = new List<int>();
            List<int> evenIndexNumbers = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (int.TryParse(text[i].ToString(), out int j) && oddEvenCounter % 2 != 0)
                {
                    oddIndexNumbers.Add(j);
                    oddEvenCounter++;
                }
                else if (int.TryParse(text[i].ToString(), out int k) && oddEvenCounter % 2 == 0)
                {
                    evenIndexNumbers.Add(k);
                    oddEvenCounter++;
                }
                else
                {
                    nonNumbers.Add(text[i]);
                }
            }

            string output = string.Empty;
            int counter = 0;

            for (int i = 0; i < oddIndexNumbers.Count; i++)
            {
                for (int l = 0; l < oddIndexNumbers[i] && counter < nonNumbers.Count; l++)
                {
                    output += nonNumbers[counter];
                    counter++;
                }

                counter += evenIndexNumbers[i];
            }

            Console.WriteLine(output);
        }
    }
}
