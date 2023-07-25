using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeComissions
{
    class TradeComissions
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double volumeSales = double.Parse(Console.ReadLine());
            
            switch (city)
            {
                case "Sofia":
                    if (volumeSales < 0)
                    {
                        Console.WriteLine("error");
                    }
                    else if (volumeSales <= 500)
                    {
                        Console.WriteLine((volumeSales * 0.05).ToString("F2"));
                    }
                    else if (volumeSales <= 1000)
                    {
                        Console.WriteLine((volumeSales * 0.07).ToString("F2"));
                    }
                    else if (volumeSales <= 10000)
                    {
                        Console.WriteLine((volumeSales * 0.08).ToString("F2"));
                    }
                    else
                    {
                        Console.WriteLine((volumeSales * 0.12).ToString("F2"));
                    }
                    break;
                case "Varna":
                    if (volumeSales < 0)
                    {
                        Console.WriteLine("error");
                    }
                    else if(volumeSales <= 500)
                    {
                        Console.WriteLine((volumeSales * 0.045).ToString("F2"));
                    }
                    else if (volumeSales <= 1000)
                    {
                        Console.WriteLine((volumeSales * 0.075).ToString("F2"));
                    }
                    else if (volumeSales <= 10000)
                    {
                        Console.WriteLine((volumeSales * 0.1).ToString("F2"));
                    }
                    else
                    {
                        Console.WriteLine((volumeSales * 0.13).ToString("F2"));
                    }
                    break;
                case "Plovdiv":
                    if (volumeSales < 0)
                    {
                        Console.WriteLine("error");
                    }
                    else if(volumeSales <= 500)
                    {
                        Console.WriteLine((volumeSales * 0.055).ToString("F2"));
                    }
                    else if (volumeSales <= 1000)
                    {
                        Console.WriteLine((volumeSales * 0.08).ToString("F2"));
                    }
                    else if (volumeSales <= 10000)
                    {
                        Console.WriteLine((volumeSales * 0.12).ToString("F2"));
                    }
                    else
                    {
                        Console.WriteLine((volumeSales * 0.145).ToString("F2"));
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
