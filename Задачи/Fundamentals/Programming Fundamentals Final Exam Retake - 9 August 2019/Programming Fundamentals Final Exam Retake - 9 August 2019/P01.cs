using System;
using System.Linq;

namespace Programming_Fundamentals_Final_Exam_Retake___9_August_2019
{
    class P01
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Sign up")
            {
                string[] cmdArgs = command.Split();
                string cmdType = cmdArgs[0];

                if (cmdType == "Case")
                {
                    string lowerOrUpper = cmdArgs[1];

                    if (lowerOrUpper == "lower")
                    {
                        username = username.ToLower();
                    }
                    else
                    {
                        username = username.ToUpper();
                    }

                    Console.WriteLine(username);
                }
                else if (cmdType == "Reverse")
                {
                    int start = int.Parse(cmdArgs[1]);
                    int end = int.Parse(cmdArgs[2]);

                    start = Math.Min(start, end);
                    end = Math.Max(start, end);

                    if (start >= 0 && end < username.Length)
                    {
                        string result = new string(username[start..++end].Reverse()
                                                                   .ToArray());
                        Console.WriteLine(result);
                    }
                }
                else if (cmdType == "Cut")
                {
                    string substring = cmdArgs[1];
                    int index = username.IndexOf(substring);

                    if (index >= 0)
                    {
                        username = username.Remove(index, substring.Length);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substring}.");
                    }
                }
                else if (cmdType == "Replace")
                {
                    char replacement = cmdArgs[1][0];
                    username = username.Replace(replacement, '*');
                    Console.WriteLine(username);
                }
                else if (cmdType == "Check")
                {
                    char check = cmdArgs[1][0];

                    if (username.Contains(check))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {check}.");
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
