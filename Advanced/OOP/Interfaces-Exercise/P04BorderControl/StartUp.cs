using System;
using System.Linq;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var buyersList = ReadBuyers(n);
            BuyFood(buyersList);

            var totalBoughFood = buyersList.Sum(p => p.Food);

            Console.WriteLine(totalBoughFood);
        }

        private static void BuyFood(List<IBuyer> buyersList)
        {
            while (true)
            {
                var name = Console.ReadLine();

                if (name == "End")
                {
                    break;
                }

                var currentBuyer = buyersList.FirstOrDefault(p => p.Name == name);

                if (currentBuyer != null)
                {
                    currentBuyer.BuyFood();
                }
            }
        }

        private static List<IBuyer> ReadBuyers(int n)
        {
            var peopleList = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                var cmdArgs = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();

                var name = cmdArgs[0];
                var age = int.Parse(cmdArgs[1]);

                IBuyer current = null;

                if (cmdArgs.Length == 4)
                {
                    var id = cmdArgs[2];
                    var birthdate = cmdArgs[3];

                    current = new Citizen(id, name, age, birthdate);
                }
                else
                {
                    var group = cmdArgs[2];

                    current = new Rebel(name, age, group);
                }

                if (current != null)
                {
                    peopleList.Add(current);
                }
            }

            return peopleList;
        }

        private static List<IBithdate> ReadEntryList()
        {
            var enterCityList = new List<IBithdate>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                         .ToArray();

                var cmdType = commandArgs[0];

                IBithdate current = null;

                if (cmdType == "Citizen")
                {
                    var name = commandArgs[1];
                    var age = int.Parse(commandArgs[2]);
                    var id = commandArgs[3];
                    var birthdate = commandArgs[4];

                    current = new Citizen(id, name, age, birthdate);
                }
                else if (cmdType == "Pet")
                {
                    var name = commandArgs[1];
                    var birthdate = commandArgs[2];

                    current = new Pet(name, birthdate);
                }

                if (current != null)
                {
                    enterCityList.Add(current);
                }
            }

            return enterCityList;
        }
    }
}
