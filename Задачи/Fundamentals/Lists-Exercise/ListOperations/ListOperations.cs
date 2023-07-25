using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOperations
{
    class ListOperations
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                List<string> commandList = command.Split().ToList();
                string operation = commandList[0];

                switch (operation)
                {
                    case "Add":
                        numbersList.Add(int.Parse(commandList[1]));
                        break;
                    case "Insert":
                        if (int.Parse(commandList[2]) >= 0 && int.Parse(commandList[2]) < numbersList.Count)
                        {
                            numbersList.Insert(int.Parse(commandList[2]), int.Parse(commandList[1]));
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Remove":
                        if (int.Parse(commandList[1]) >= 0 && int.Parse(commandList[1]) < numbersList.Count)
                        {
                            numbersList.RemoveAt(int.Parse(commandList[1]));
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Shift":
                        switch (commandList[1])
                        {
                            case "left":
                                for (int i = 0; i < int.Parse(commandList[2]); i++)
                                {
                                    numbersList.Add(numbersList[0]);
                                    numbersList.RemoveAt(0);
                                }
                                break;
                            case "right":
                                for (int i = 0; i < int.Parse(commandList[2]); i++)
                                {
                                    numbersList.Insert(0, numbersList[numbersList.Count - 1]);
                                    numbersList.RemoveAt(numbersList.Count - 1);
                                }
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbersList));
        }
    }
}
