using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class Elevator
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses = 0;

            while (numberOfPeople > 0)
            {
                numberOfPeople -= capacity;
                courses++;
            }

            Console.WriteLine(courses);
        }
    }
}
