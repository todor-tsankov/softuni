using System;
using System.Linq;

namespace P08Threeuple
{
    public class StartUp
    {
        static void Main()
        {
            var firstInputLine = GetInput();
            var secondInputLine = GetInput();
            var thirdInputLine = GetInput();

            var firstThreeuple = GetFirstThreeuple(firstInputLine);
            var secondThreeuple = GetSecondThreeuple(secondInputLine);
            var thirdThreeuple = GetThirdThreeuple(thirdInputLine);

            Print(firstThreeuple, secondThreeuple, thirdThreeuple);
        }

        private static Threeuple<string, string, string> GetFirstThreeuple(string[] firstInputLine)
        {
            var name = $"{firstInputLine[0]} {firstInputLine[1]}";
            var address = firstInputLine[2];
            var town = firstInputLine.Length == 4 ? firstInputLine[3] : firstInputLine[3] + " " + firstInputLine[4];

            return new Threeuple<string, string, string>(name, address, town);
        }

        private static Threeuple<string, double, bool> GetSecondThreeuple(string[] secondInputLine)
        {
            string name = secondInputLine[0];
            double litresOfBeers = double.Parse(secondInputLine[1]);
            bool drunk = secondInputLine[2] == "drunk" ? true : false;

            return new Threeuple<string, double, bool>(name, litresOfBeers, drunk);
        }

        private static Threeuple<string, double, string> GetThirdThreeuple(string[] thirdInputLine)
        {
            var name = thirdInputLine[0];
            var balance = double.Parse(thirdInputLine[1]);
            var bank = thirdInputLine.Length == 3 ? thirdInputLine[2] : thirdInputLine[2] + " " + thirdInputLine[3];

            return new Threeuple<string, double, string>(name, balance, bank);
        }

        private static void Print(Threeuple<string, string, string> firstThreeuple, Threeuple<string, double, bool> secondThreeuple, Threeuple<string, double, string> thirdThreeuple)
        {
            Console.WriteLine(firstThreeuple.ToString());
            Console.WriteLine(secondThreeuple.ToString());
            Console.WriteLine(thirdThreeuple.ToString());
        }

        private static string[] GetInput()
        {
            return Console.ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();
        }
    }
}
