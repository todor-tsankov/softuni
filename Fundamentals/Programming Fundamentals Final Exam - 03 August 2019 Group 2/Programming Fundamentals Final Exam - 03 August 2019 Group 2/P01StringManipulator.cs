using System;

namespace Programming_Fundamentals_Final_Exam___03_August_2019_Group_2
{
    class P01StringManipulator
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            string cmd = Console.ReadLine();

            while (cmd != "Done")
            {
                string[] cmdArgs = cmd.Split();
                string cmdType = cmdArgs[0];
                bool printString = true;

                if (cmdType == "Change")
                {
                    char oldChar = cmdArgs[1][0];
                    char newChar = cmdArgs[2][0];

                    inputString = inputString.Replace(oldChar, newChar);
                }
                else if (cmdType == "Includes")
                {
                    string match = cmdArgs[1];
                    bool isMatch = inputString.Contains(match);

                    Console.WriteLine(isMatch);
                    printString = false;
                }
                else if (cmdType == "End")
                {
                    string matchEnd = cmdArgs[1];
                    bool isMatch = inputString.EndsWith(matchEnd);

                    Console.WriteLine(isMatch);
                    printString = false;
                }
                else if (cmdType == "Uppercase")
                {
                    inputString = inputString.ToUpper();
                }
                else if (cmdType == "FindIndex")
                {
                    char match = cmdArgs[1][0];
                    int index = inputString.IndexOf(match);

                    Console.WriteLine(index);
                    printString = false;
                }
                else if (cmdType == "Cut")
                {
                    int start = int.Parse(cmdArgs[1]);
                    int length = int.Parse(cmdArgs[2]);

                    inputString = inputString.Substring(start, length);
                }

                if (printString)
                {
                    Console.WriteLine(inputString);
                }

                cmd = Console.ReadLine();
            }
        }
    }
}
