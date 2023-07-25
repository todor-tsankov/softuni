using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split().ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandLine = command.Split();
                command = commandLine[0];

                if (command == "Delete")
                {
                    while (numbers.Contains(commandLine[1]))
                    {
                        numbers.Remove(commandLine[1]);
                    }
                }
                else if (command == "Insert")
                {
                    numbers.Insert(int.Parse(commandLine[2]), commandLine[1]);
                }
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
