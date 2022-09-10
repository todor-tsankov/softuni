using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousThreat
{
    class AnonymousThreat
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "3:1")
            {
                List<string> commandLine = command.Split().ToList();
                string operation = commandLine[0];
                int firstIndex = int.Parse(commandLine[1]);
                int secondIndex = int.Parse(commandLine[2]);

                if (operation == "merge")
                {
                    if (firstIndex < 0)
                    {
                        firstIndex = 0;
                    }

                    if (secondIndex >= input.Count)
                    {
                        secondIndex = input.Count - 1;
                    }

                    for (int i = firstIndex; i < secondIndex; i++)
                    {
                        input[firstIndex] = input[firstIndex] + input[firstIndex + 1];
                        input.RemoveAt(firstIndex + 1);
                    }
                }
                else if (operation == "divide")
                {
                    int lengthOfAllParts = input[firstIndex].Length / secondIndex;
                    int counter = 0;

                    for (int i = 0; i < secondIndex; i++)
                    {
                        string current = string.Empty;

                        if (i == secondIndex - 1)
                        {
                            for (int j = 0; j <= input[firstIndex].Length && counter < input[firstIndex].Length; j++)
                            {
                                current += input[firstIndex][counter];
                                counter++;
                            }
                        }
                        else
                        {
                            for (int j = 0; j < lengthOfAllParts; j++)
                            {
                                current += input[firstIndex][counter];
                                counter++;
                            }
                        }
                        
                        input.Insert( firstIndex + i + 1,current);
                    }

                    input.RemoveAt(firstIndex);
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
