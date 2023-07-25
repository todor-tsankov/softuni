using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseParty
{
    class HouseParty
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();
            

            for (int i = 0; i < numberOfCommands; i++)
            {
                List<string> currentPerson = Console.ReadLine().Split().ToList();
                string name = currentPerson[0];
                bool isGoing = currentPerson[2] == "going!";

                if (isGoing)
                {
                    if (guestList.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(name);
                    }
                }
                else
                {
                    if (guestList.Contains(name))
                    {
                        guestList.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            foreach (var item in guestList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
