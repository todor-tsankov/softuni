using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    class SoftUniParking
    {
        static void Main(string[] args)
        {
            var usersDict = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandParts = Console.ReadLine().Split();
                string operation = commandParts[0];
                string username = commandParts[1];

                if (operation == "register")
                {
                    string licensePlateNumber = commandParts[2];

                    if (usersDict.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                    else
                    {
                        usersDict[username] = licensePlateNumber;
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }
                else if (operation == "unregister")
                {
                    if (!usersDict.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        usersDict.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var item in usersDict)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
