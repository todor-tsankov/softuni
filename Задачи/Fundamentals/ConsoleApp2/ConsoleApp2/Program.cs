using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monets
{
    class Monets
    {
        static void Main(string[] args)
        {
            double sum = double.Parse(Console.ReadLine());
            double rest = 1;
            int monetCount = 0;

            while (rest != 0)
            {
                rest = sum % 2;
                if (rest == sum / 2)
                {
                    monetCount++;
                }
                if (rest == 0)
                {
                    break;
                }
                
                rest = sum % 1;
                if (rest == sum / 2)
                {
                    monetCount++;
                }
                if (rest == 0)
                {
                    break;
                }
                
                rest = sum % 0.5;
                if (rest == sum / 2)
                {
                    monetCount++;
                }
                if (rest == 0)
                {
                    break;
                }
               
                rest = sum % 0.2;
                if(rest == sum / 2)
                {
                    monetCount++;
                }
                if (rest == 0)
                {
                    break;
                }
                
                rest = sum % 0.1;
                if (rest == sum / 2)
                {
                    monetCount++;
                }
                if (rest == 0)
                {
                    break;
                }
                
                rest = sum % 0.05;
                if (rest == sum / 2)
                {
                    monetCount++;
                }
                if (rest == 0)
                {
                    break;
                }
                
                rest = sum % 0.02;
                if (rest == sum / 2)
                {
                    monetCount++;
                }
                if (rest == 0)
                {
                    break;
                }
                
                rest = sum % 0.01;
                if (rest == sum / 2)
                {
                    monetCount++;
                }
                if (rest == 0)
                {
                    break;
                }
                
                break;

            }
            Console.WriteLine(monetCount);
        }
    }
}
