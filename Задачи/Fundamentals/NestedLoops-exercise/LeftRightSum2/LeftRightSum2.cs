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
                string iInString = i.ToString();

                int sumFirst = int.Parse(iInString[0].ToString()) + int.Parse(iInString[1].ToString());
                int sumLast =  int.Parse(iInString[4].ToString()) + int.Parse(iInString[3].ToString());

                
                if (sumFirst > sumLast)
                {
                    sumLast += int.Parse(iInString[2].ToString());
                }
                else if (sumFirst < sumLast)
                {
                    sumFirst += int.Parse(iInString[2].ToString());
                }

                if (sumFirst == sumLast)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
