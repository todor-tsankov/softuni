using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombNumbers
{
    class BombNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> special = Console.ReadLine().Split().Select(int.Parse).ToList();

            int specialNumber = special[0];
            int power = special[1];

            while (numbersList.Contains(specialNumber))
            {
                for (int i = 0; i < numbersList.Count; i++)
                {
                    if (numbersList[i] == specialNumber)
                    {
                        int firstIndex = i - power;

                        if (firstIndex < 0)
                        {
                            firstIndex = 0;
                        }

                        int lastIndex = i + power;

                        if (lastIndex >= numbersList.Count)
                        {
                            lastIndex = numbersList.Count - 1;
                        }

                        for (int j = firstIndex; j <= lastIndex; j++)
                        {
                            numbersList.RemoveAt(firstIndex);
                        }

                    }
                }
            }
            
            int sum = 0;

            foreach (var item in numbersList)
            {
                sum += item;
            }

            Console.WriteLine(sum);
        }
    }
}
