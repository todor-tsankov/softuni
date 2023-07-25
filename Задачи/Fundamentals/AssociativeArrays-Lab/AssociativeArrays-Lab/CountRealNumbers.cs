using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociativeArrays_Lab
{
    class CountRealNumbers
    {
        static void Main(string[] args)
        {
            List<string> numberListInString = Console.ReadLine().Split().ToList();
            Dictionary<string, int> numbersWithOccurences = new Dictionary<string, int>();

            foreach (var number in numberListInString)
            {
                if (!numbersWithOccurences.ContainsKey(number))
                {
                    numbersWithOccurences[number] = 1;
                }
                else
                {
                    numbersWithOccurences[number]++;
                }
            }

            numbersWithOccurences = numbersWithOccurences.OrderBy(i => i.Key).ToDictionary(i => i.Key , i => i.Value);

            foreach (var item in numbersWithOccurences)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
