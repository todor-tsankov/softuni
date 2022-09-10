using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingScore
{
    class GamingScore
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            string game = "0";
            double spentMoney = 0;

            while (game != "Game Time")
            {
                switch (game)
                {
                    case "OutFall 4":
                        if (balance >= 39.99)
                        {
                            Console.WriteLine($"Bought {game}");
                            spentMoney += 39.99;
                            balance -= 39.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "CS: OG":
                        if (balance >= 15.99)
                        {
                            Console.WriteLine($"Bought {game}");
                            spentMoney += 15.99;
                            balance -= 15.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Zplinter Zell":
                        if (balance >= 19.99)
                        {
                            Console.WriteLine($"Bought {game}");
                            spentMoney += 19.99;
                            balance -= 19.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Honored 2":
                        if (balance >= 59.99)
                        {
                            Console.WriteLine($"Bought {game}");
                            spentMoney += 59.99;
                            balance -= 59.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch":
                        if (balance >= 29.99)
                        {
                            Console.WriteLine($"Bought {game}");
                            spentMoney += 29.99;
                            balance -= 29.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch Origins Edition":
                        if (balance >= 39.99)
                        {
                            Console.WriteLine($"Bought {game}");
                            spentMoney += 39.99;
                            balance -= 39.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }

                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                game = Console.ReadLine();
            }
            if (balance != 0)
            {
                Console.WriteLine($"Total spent: ${spentMoney:f2}. Remaining: ${balance:f2}");
            }
        }
    }
}
