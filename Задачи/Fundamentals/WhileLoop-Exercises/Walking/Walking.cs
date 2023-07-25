using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking
{
    class Walking
    {
        static void Main(string[] args)
        {
            int stepsCounter = 0;
            string step = string.Empty;
            int goalSteps = 10000;

            while (stepsCounter < goalSteps)
            {
                step = Console.ReadLine();

                if (step == "Going home")
                {
                    step = Console.ReadLine();
                    stepsCounter += int.Parse(step);
                    break;
                }
                else
                {
                    stepsCounter += int.Parse(step);
                }
                    
            }

            if (stepsCounter >= goalSteps)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                Console.WriteLine($"{goalSteps - stepsCounter} more steps to reach goal.");
            }
        }
    }
}
