using System;

namespace Programming_Fundamentals_Final_Exam___03_August_2019_Group_1
{
    class P01StringManipulator
    {
        static void Main(string[] args)
        {
            string currentString = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split();
                string commandType = commandArgs[0];

                if (commandType == "Translate")
                {
                    char currentChar = commandArgs[1][0];
                    char replacement = commandArgs[2][0];

                    currentString = currentString.Replace(currentChar, replacement);
                    Console.WriteLine(currentString);
                }
                else if (commandType == "Includes")
                {
                    string match = commandArgs[1];
                    bool isPresent = currentString.Contains(match);

                    Console.WriteLine(isPresent);
                }
                else if (commandType == "Start")
                {
                    string match = commandArgs[1];
                    bool isStart = currentString.StartsWith(match);

                    Console.WriteLine(isStart);
                }
                else if (commandType == "Lowercase")
                {
                    currentString = currentString.ToLower();

                    Console.WriteLine(currentString);
                }
                else if (commandType == "FindIndex")
                {
                    char match = commandArgs[1][0];
                    int index = currentString.LastIndexOf(match);

                    Console.WriteLine(index);
                }
                else if (commandType == "Remove")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int count = int.Parse(commandArgs[2]);

                    currentString = currentString.Remove(startIndex, count);
                    Console.WriteLine(currentString);
                }

                command = Console.ReadLine();
            }
        }
    }
}
