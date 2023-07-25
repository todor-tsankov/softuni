using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumRightLeft
{
    class sumRightLeft
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                string iInString = i + "";
                int sumFirst = 0;
                int sumLast = 0;

                for (int j = 0; j < i.ToString().Length; j++)
                {
                    if (j == 0 || j == 1)
                    {
                        sumFirst += int.Parse(iInString[j] + "");
                    }
                    else if (j == iInString.Length - 1 || j == iInString.Length - 2)
                    {
                        sumLast += int.Parse(iInString[j] + "");
                    }
                }

                if (sumFirst == sumLast)
                {
                    Console.Write(i + " ");
                }
                else if (sumFirst > sumLast)
                {
                    sumLast += int.Parse(iInString[iInString.Length / 2] + "");

                    if (sumFirst == sumLast)
                    {
                        Console.Write(i + " ");
                    }
                } 
                else
                {
                    sumFirst += int.Parse(iInString[iInString.Length / 2] + "");

                    if (sumFirst == sumLast)
                    {
                        Console.Write(i + " ");
                    }
                }
                
            }
        }
    }
}
