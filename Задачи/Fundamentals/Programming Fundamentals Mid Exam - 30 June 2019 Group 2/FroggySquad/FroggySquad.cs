using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggySquad
{
    class FroggySquad
    {
        static void Main(string[] args)
        {
            List<string> froggSquad = Console.ReadLine().Split().ToList();
            string command = string.Empty;

            while (true)
            {
                string[] commandParts = Console.ReadLine().Split();
                string operation = commandParts[0];

                if (operation == "Join")
                {
                    string name = commandParts[1];
                    froggSquad.Add(name);
                }
                else if (operation == "Jump")
                {
                    string name = commandParts[1];
                    int index = int.Parse(commandParts[2]);

                    if (index >= 0 && index < froggSquad.Count)
                    {
                        froggSquad.Insert(index, name);
                    }
                }
                else if (operation == "Dive")
                {
                    int index = int.Parse(commandParts[1]);

                    if (index >= 0 && index < froggSquad.Count)
                    {
                        froggSquad.RemoveAt(index);
                    }
                }
                else if (operation == "First")
                {
                    int count = int.Parse(commandParts[1]);
                    PrintFirst(froggSquad, count);
                }
                else if (operation == "Last")
                {
                    int count = int.Parse(commandParts[1]);
                    PrintLast(froggSquad, count);
                }
                else if (operation == "Print")
                {
                    string secondOperation = commandParts[1];
                    Console.Write("Frogs: ");

                    if (secondOperation == "Normal")
                    {
                        Console.Write(string.Join(" ", froggSquad));
                    }
                    else
                    {
                        froggSquad.Reverse();
                        Console.WriteLine(string.Join(" ", froggSquad));
                    }

                    Console.WriteLine();
                    return;
                }
            }
        }

        static void PrintFirst(List<string> froggSquad, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (i < froggSquad.Count)
                {
                    Console.Write(froggSquad[i] + " ");
                }
            }
            Console.WriteLine();
        }

        static void PrintLast(List<string> froggSquad, int count)
        {
            List<string> lastFroggs = new List<string>();

            for (int i = froggSquad.Count - 1; i > froggSquad.Count - 1 - count; i--)
            {
                if (i >= 0)
                {
                    lastFroggs.Add(froggSquad[i]);
                }
            }

            lastFroggs.Reverse();
            Console.WriteLine(string.Join(" ", lastFroggs));
        }
    }
}
