using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P04OnTheWayToAnapurna
{
    class P04OnTheWayToAnapurna
    {
        static void Main(string[] args)
        {
            var stores = new Dictionary<string, List<string>>();
            string[] delimiterChars = {"->", ","};

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                string cmdType = commandArgs[0];
                string storeName = commandArgs[1];

                if (cmdType == "Add")
                {
                    if (!stores.ContainsKey(storeName))
                    {
                        stores[storeName] = new List<string>();
                    }

                    for (int i = 2; i < commandArgs.Length; i++)
                    {
                        string currentItem = commandArgs[i];

                        stores[storeName].Add(currentItem);
                    }
                }
                else if (cmdType == "Remove")
                {
                    stores.Remove(storeName);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Stores list:");

            var sortedStores = stores.OrderByDescending(i => i.Value.Count)
                                     .ThenByDescending(i => i.Key);

            foreach (var st in sortedStores)
            {
                Console.WriteLine(st.Key);

                foreach (var item in st.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
