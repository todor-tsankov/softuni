using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tankList = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();   //  ", ", StringSplitOptions.RemoveEmptyEntries
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandParts = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);    // ", ", StringSplitOptions.RemoveEmptyEntries
                string operation = commandParts[0];

                if (operation == "Add")
                {
                    string tankName = commandParts[1];
                    int index = tankList.IndexOf(tankName);

                    if (index < 0)
                    {
                        tankList.Add(tankName);
                        Console.WriteLine("Tank successfully bought");
                    }
                    else
                    {
                        Console.WriteLine("Tank is already bought");
                    }
                }
                else if (operation == "Remove")
                {
                    string tankName = commandParts[1];
                    int index = tankList.IndexOf(tankName);

                    if (index < 0)
                    {
                        Console.WriteLine("Tank not found");
                    }
                    else
                    {
                        Console.WriteLine("Tank successfully sold");
                        tankList.RemoveAt(index);
                    }
                }
                else if (operation == "Remove At")
                {
                    int index = int.Parse(commandParts[1]);

                    if (index >= 0 && index < tankList.Count)
                    {
                        Console.WriteLine("Tank successfully sold");
                        tankList.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
                else if (operation == "Insert")
                {
                    int index = int.Parse(commandParts[1]);
                    string name = commandParts[2];

                    if (index >= 0 && index < tankList.Count)   // possibly index <= tankList.Count
                    {
                        if (tankList.Contains(name))
                        {
                            Console.WriteLine("Tank is already bought");
                        }
                        else
                        {
                            Console.WriteLine("Tank successfully bought");
                            tankList.Insert(index, name);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }

            }

            Console.WriteLine(string.Join(", ", tankList));
        }
    }
}
