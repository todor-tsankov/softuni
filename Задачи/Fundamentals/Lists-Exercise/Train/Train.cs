using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class Train
    {
        static void Main(string[] args)
        {
            List<int> waggonPassengers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int max = int.Parse(Console.ReadLine());
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                List<string> commandLine = command.Split().ToList();

                if (commandLine[0] == "Add")
                {
                    waggonPassengers.Add(int.Parse(commandLine[1]));
                }
                else
                {
                    int passengers = int.Parse(commandLine[0]);

                    for (int i = 0; i < waggonPassengers.Count; i++)
                    {
                        if (passengers + waggonPassengers[i] <= max)
                        {
                            waggonPassengers[i] += passengers;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", waggonPassengers));
        }
    }
}
