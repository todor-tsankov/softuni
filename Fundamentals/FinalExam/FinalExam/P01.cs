using System;
using System.Linq;

namespace FinalExam
{
    class P01
    {
        static void Main(string[] args)
        {
            string currentString = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Finish")
            {
                string[] commandParts = command.Split();
                string commandType = commandParts[0];

                if (commandType == "Replace")
                {
                    char currentChar = commandParts[1][0];
                    char newChar = commandParts[2][0];

                    currentString = currentString.Replace(currentChar, newChar);

                    Console.WriteLine(currentString);
                }
                else if (commandType == "Cut")
                {
                    int startIndex = int.Parse(commandParts[1]);
                    int endIndex = int.Parse(commandParts[2]);

                    int start = Math.Min(startIndex, endIndex);
                    int end = Math.Max(startIndex, endIndex);


                    if (start >= 0 && end < currentString.Length)
                    {
                        int count = end - start + 1;   // check if needed

                        currentString = currentString.Remove(startIndex, count);
                        Console.WriteLine(currentString);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                else if (commandType == "Make")
                {
                    string upperOrLower = commandParts[1];

                    if (upperOrLower == "Upper")
                    {
                        currentString = currentString.ToUpper();
                    }
                    else if (upperOrLower == "Lower")
                    {
                        currentString = currentString.ToLower();
                    }

                    Console.WriteLine(currentString);
                }
                else if (commandType == "Check")   // "Check"
                {
                    string match = commandParts[1];

                    if (currentString.Contains(match))
                    {
                        Console.WriteLine($"Message contains {match}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {match}");
                    }
                }
                else if (commandType == "Sum")
                {
                    int startIndex = int.Parse(commandParts[1]);
                    int endIndex = int.Parse(commandParts[2]);

                    int start = Math.Min(startIndex, endIndex);
                    int end = Math.Max(startIndex, endIndex);


                    if (start >= 0 && end < currentString.Length)  //  chek if neeeded
                    {
                        int sum = currentString[start..++end].Select(i => (int)i).Sum();   // check if end + 1

                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
