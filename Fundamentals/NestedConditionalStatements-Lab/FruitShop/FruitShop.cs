using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitShop
{
    class FruitShop
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    switch (product)
                    {
                        case "banana":
                            Console.WriteLine((quantity * 2.50).ToString("F2"));
                            break;
                        case "apple":
                            Console.WriteLine((quantity * 1.20).ToString("F2"));
                            break;
                        case "orange":
                            Console.WriteLine((quantity * 0.85).ToString("F2"));
                            break;
                        case "grapefruit":
                            Console.WriteLine((quantity * 1.45).ToString("F2"));
                            break;
                        case "kiwi":
                            Console.WriteLine((quantity * 2.70).ToString("F2"));
                            break;
                        case "pineapple":
                            Console.WriteLine((quantity * 5.50).ToString("F2"));
                            break;
                        case "grapes":
                            Console.WriteLine((quantity * 3.85).ToString("F2"));
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                case "Saturday":
                case "Sunday":
                    switch (product)
                    {
                        case "banana":
                            Console.WriteLine((quantity * 2.70).ToString("F2"));
                            break;
                        case "apple":
                            Console.WriteLine((quantity * 1.25).ToString("F2"));
                            break;
                        case "orange":
                            Console.WriteLine((quantity * 0.90).ToString("F2"));
                            break;
                        case "grapefruit":
                            Console.WriteLine((quantity * 1.60).ToString("F2"));
                            break;
                        case "kiwi":
                            Console.WriteLine((quantity * 3.00).ToString("F2"));
                            break;
                        case "pineapple":
                            Console.WriteLine((quantity * 5.60).ToString("F2"));
                            break;
                        case "grapes":
                            Console.WriteLine((quantity * 4.20).ToString("F2"));
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }

        }
    }
}
