using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBrackets
{
    class BalancedBrackets
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int openingBracketCounter = 0;
            int closingBracketCounter = 0;
            bool firstShouldBeFollowedBySecond = false;

            for (int i = 0; i < n; i++)
            {
                char characeter = Console.ReadLine()[0];

                if (characeter == '(')
                {
                    openingBracketCounter++;
                    firstShouldBeFollowedBySecond = true;
                }
                else if (characeter == ')' && firstShouldBeFollowedBySecond == true)
                {
                    closingBracketCounter++;
                    firstShouldBeFollowedBySecond = false;
                }
            }

            if (openingBracketCounter == closingBracketCounter)
            {
                Console.WriteLine("BALANCED");
            }
            else 
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
