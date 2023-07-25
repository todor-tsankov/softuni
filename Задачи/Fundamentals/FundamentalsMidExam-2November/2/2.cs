using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friendList = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList(); // NEEDS ", " ", ", StringSplitOptions.RemoveEmptyEntries
            string command = string.Empty;
            int blackListCount = 0;
            int lostCount = 0;

            while ((command = Console.ReadLine()) != "Report")
            {
                string[] commandParts = command.Split();
                string operation = commandParts[0];

                if (operation == "Blacklist")
                {
                    string name = commandParts[1];
                    int index = friendList.IndexOf(name);

                    if (index >= 0)
                    {
                        friendList[index] = "Blacklisted";
                        Console.WriteLine($"{name} was blacklisted.");
                        blackListCount++;
                    }
                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }
                else if (operation == "Error")
                {
                    int index = int.Parse(commandParts[1]);
                    string currentName = friendList[index];   // Check if index is valid?

                    if (currentName != "Blacklisted" && currentName != "Lost")
                    {
                        friendList[index] = "Lost";
                        Console.WriteLine($"{currentName} was lost due to an error.");
                        lostCount++;
                    }
                }
                else if (operation == "Change")
                {
                    int index = int.Parse(commandParts[1]);
                    string newName = commandParts[2];

                    if (index >= 0 && index < friendList.Count)
                    {
                        Console.WriteLine($"{friendList[index]} changed his username to {newName}.");
                        friendList[index] = newName;
                    }
                }
            }

            Console.WriteLine($"Blacklisted names: {blackListCount} ");
            Console.WriteLine($"Lost names: {lostCount} ");
            Console.WriteLine(string.Join(" ", friendList));
        }
    }
}
