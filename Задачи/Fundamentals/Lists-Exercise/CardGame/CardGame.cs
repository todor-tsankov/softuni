using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class CardGame
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondPlayerCards = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (firstPlayerCards.Count != 0 && secondPlayerCards.Count != 0)
            {
                for (int i = 0; i < Math.Min(firstPlayerCards.Count, secondPlayerCards.Count); i++)
                {
                    if (firstPlayerCards[0] > secondPlayerCards[0])
                    {
                        firstPlayerCards.Add(firstPlayerCards[0]);
                        firstPlayerCards.Add(secondPlayerCards[0]);
                        
                    }
                    else if (firstPlayerCards[0] < secondPlayerCards[0])
                    {
                        secondPlayerCards.Add(secondPlayerCards[0]);
                        secondPlayerCards.Add(firstPlayerCards[0]);
                    }
                    
                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);
                }
            }

            if (firstPlayerCards.Count == 0)
            {
                int sum = 0;

                foreach (var item in secondPlayerCards)
                {
                    sum += item;
                }
                Console.WriteLine($"Second player wins! Sum: {sum}"); 
            }
            else
            {
                int sum = 0;

                foreach (var item in firstPlayerCards)
                {
                    sum += item;
                }
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
        }
    }
}
