using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForceBook
{
    class ForceBook
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, List<string>>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] commandParts = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                bool one = false;

                if (commandParts.Length > 1)
                {
                    one = true;
                }
                else
                {
                    commandParts = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                }

                if (one)
                {
                    string forceUser = commandParts[1];
                    string forceSide = commandParts[0];

                    if (!users.ContainsKey(forceSide))
                    {
                        users[forceSide] = new List<string>();
                    }

                    if (!ContainsInDict(users, forceUser))
                    {
                        users[forceSide].Add(forceUser);
                    }

                }
                else
                {
                    string forceUser = commandParts[0];
                    string  forceSide = commandParts[1];

                    if (!users.ContainsKey(forceSide))
                    {
                        users[forceSide] = new List<string>();
                    }

                    if (!ContainsInDict(users, forceUser))
                    {
                        users[forceSide].Add(forceUser);
                    }
                    else
                    {
                        RemoveUser(users, forceUser);
                        users[forceSide].Add(forceUser);
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            users = users.OrderByDescending(i => i.Value.Count).ThenBy(i => i.Key).ToDictionary(i => i.Key, i => i.Value);

            foreach (var force in users)
            {
                if (force.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {force.Key}, Members: {force.Value.Count}");
                    var filter = force.Value.OrderBy(i => i);

                    foreach (var item in filter)
                    {
                        Console.WriteLine($"! {item}");
                    }
                }
            }
        }

        static bool ContainsInDict(Dictionary<string, List<string>> users, string userName)
        {
            foreach (var item in users)
            {
                if (item.Value.Contains(userName))
                {
                    return true;
                }
            }
            return false;
        }

        static void RemoveUser(Dictionary<string, List<string>> users, string userName)
        {
            int index = 0;
            string force = string.Empty;

            foreach (var item in users)
            {
                index = item.Value.IndexOf(userName);

                if (index >= 0)
                {
                    force = item.Key;
                    break;
                }
            }

            users[force].RemoveAt(index);
        }
    }
}
