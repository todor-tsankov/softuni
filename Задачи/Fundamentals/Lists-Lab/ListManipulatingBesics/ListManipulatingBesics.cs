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

            while ((command = Console.ReadLine().Split().ToList() )[0] != "end")
            {
                int number = int.Parse(command[1]);
                string firstCommand = command[0];

                if (firstCommand == "Add")
                {
                    numbersList.Add(number);
                }
                else if (firstCommand == "Remove")
                {
                    numbersList.Remove(number);
                }
                else if (firstCommand == "RemoveAt")
                {
                    numbersList.RemoveAt(number);
                }
                else if (firstCommand == "Insert")
                {
                    numbersList.Insert(int.Parse(command[2]), number);
                }
            }

            Console.WriteLine(string.Join(" ", numbersList));
        }
    }
}
