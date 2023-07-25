using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCreation
{
    class projectCreation
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int number = Int32.Parse(Console.ReadLine());
            int hours = number * 3;
            Console.WriteLine($"The architect {name} will need {hours} hours to complete {number} project/s.");

        }
    }
}
