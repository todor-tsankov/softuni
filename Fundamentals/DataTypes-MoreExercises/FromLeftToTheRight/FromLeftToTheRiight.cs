using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FromLeftToTheRight
{
    class FromLeftToTheRiight
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string twoNumbers = Console.ReadLine();
                string firstNumberString = string.Empty;
                string secondNumberString = string.Empty;
                bool firstOrSecond = true;

                for (int j = 0; j < twoNumbers.Length; j++)
                {
                    if (twoNumbers[j] == ' ')
                    {
                        firstOrSecond = false;
                        continue;
                    }

                    if (firstOrSecond)
                    {
                        firstNumberString += twoNumbers[j];

                    }
                    else
                    {
                        secondNumberString += twoNumbers[j];
                    }

                }

                double firstNumber = double.Parse(firstNumberString);
                double secondNumber = double.Parse(secondNumberString);
                double sum = 0;

                if (firstNumber > secondNumber)
                {
                    for (int l = 0; l < firstNumberString.Length; l++)
                    {
                        if (firstNumberString[l] == '.' || firstNumberString[l] == '-')
                        {
                            continue;
                        }
                        sum += double.Parse(firstNumberString[l].ToString());
                    }
                }
                else
                {
                    for (int m = 0; m < secondNumberString.Length; m++)
                    {
                        if (secondNumberString[m] == '.' || secondNumberString[m] == '-')
                        {
                            continue;
                        }
                        sum += double.Parse(secondNumberString[m].ToString());
                    }
                }

                Console.WriteLine(sum);
            }
        }
    }
}
