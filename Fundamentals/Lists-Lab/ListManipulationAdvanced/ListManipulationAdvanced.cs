using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManipulatingBesics
{
    class ListManipulatingBesics
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<string> command;
            bool changes = false;

            while ((command = Console.ReadLine().Split().ToList())[0] != "end")
            {
                string firstCommand = command[0];

                if (firstCommand == "Add")
                {
                    numbersList.Add(int.Parse(command[1]));
                    changes = true;
                }
                else if (firstCommand == "Remove")
                {
                    numbersList.Remove(int.Parse(command[1]));
                    changes = true;
                }
                else if (firstCommand == "RemoveAt")
                {
                    numbersList.RemoveAt(int.Parse(command[1]));
                    changes = true;
                }
                else if (firstCommand == "Insert")
                {
                    numbersList.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    changes = true;
                }
                else if (firstCommand == "Contains")
                {
                    Contains(numbersList,int.Parse(command[1]));
                }
                else if (firstCommand == "PrintEven")
                {
                    PrintEven(numbersList);
                }
                else if (firstCommand == "PrintOdd")
                {
                    PrintOdd(numbersList);
                }
                else if (firstCommand == "GetSum")
                {
                    GetSum(numbersList);
                }
                else if (firstCommand == "Filter")
                {
                    Filter(numbersList, command[1] , int.Parse(command[2]));
                }
            }

            if (changes)
            {
                Console.WriteLine(string.Join(" ", numbersList));
            }
        }

        static void Contains(List<int> numbersList, int number)
        {
            bool contains = numbersList.Contains(number);

            if (contains)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        static void PrintEven(List<int> numbersList)
        {
            foreach (int item in numbersList)
            {
                if (item % 2 == 0)
                {
                    Console.Write(item + " ");
                }
            }

            Console.WriteLine();
        }

        static void PrintOdd(List<int> numbersList)
        {
            foreach (int item in numbersList)
            {
                if (item % 2 != 0)
                {
                    Console.Write(item + " ");
                }
            }

            Console.WriteLine();
        }

        static void GetSum(List<int> numbersList)
        {
            int sum = 0;

            foreach (var item in numbersList)
            {
                sum += item;
            }

            Console.WriteLine(sum);
        }

        static void Filter(List<int> numbersList, string op, int number)
        {
            List<int> result = new List<int>();
            int count = numbersList.Count;

            switch (op)
            {
                case "<":

                    for (int i = 0; i < count; i++)
                    {
                        int currentNumber = numbersList[i];

                        if (currentNumber < number)
                        {
                            result.Add(currentNumber);
                        }
                    }

                    break;
                case ">":

                    for (int i = 0; i < count; i++)
                    {
                        int currentNumber = numbersList[i];

                        if (currentNumber > number)
                        {
                            result.Add(currentNumber);
                        }
                    }

                    break;
                case "<=":

                    for (int i = 0; i < count; i++)
                    {
                        int currentNumber = numbersList[i];

                        if (currentNumber <= number)
                        {
                            result.Add(currentNumber);
                        }
                    }

                    break;
                case ">=":

                    for (int i = 0; i < count; i++)
                    {
                        int currentNumber = numbersList[i];

                        if (currentNumber >= number)
                        {
                            result.Add(currentNumber);
                        }
                    }

                    break;
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }

}
