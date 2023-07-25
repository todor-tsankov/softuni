using System;
using System.Collections.Generic;
using System.Linq;

namespace Technology_Fundamentals_Mid_Exam___10_March_2019_Group_2
{
    class TheHuntingGames
    {
        static void Main(string[] args)
        {
            List<string> listWords = Console.ReadLine().Split().ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] commandParts = command.Split();
                string operation = commandParts[0];

                if (operation == "Delete")
                {
                    int index = int.Parse(commandParts[1]) + 1;

                    if (index >= 0 && index < listWords.Count)
                    {
                        listWords.RemoveAt(index);
                    }
                }
                else if (operation == "Swap")
                {
                    string firstWord = commandParts[1];
                    string secondWord = commandParts[2];
                    int firstIndex = listWords.FindIndex(i => i == firstWord);
                    int secondIndex = listWords.FindIndex(i => i == secondWord);

                    if (firstIndex >= 0 && secondIndex >= 0)
                    {
                        listWords[firstIndex] = secondWord;
                        listWords[secondIndex] = firstWord;
                    }
                }
                else if (operation == "Put")
                {
                    string word = commandParts[1];
                    int index = int.Parse(commandParts[2]) - 1;

                    if (index >= 0 && index <= listWords.Count)
                    {
                        listWords.Insert(index, word);
                    }
                   
                }
                else if(operation == "Sort")
                {
                    listWords = listWords.OrderByDescending(i => i).ToList();
                }
                else if (operation == "Replace")
                {
                    string firstWord = commandParts[1];
                    string secondWord = commandParts[2];

                    if (listWords.Contains(secondWord))
                    {
                        listWords[listWords.IndexOf(secondWord)] = firstWord;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", listWords));
        }
    }
}
