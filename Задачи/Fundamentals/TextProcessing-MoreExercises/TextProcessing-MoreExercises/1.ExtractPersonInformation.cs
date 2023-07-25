using System;
using System.Text;

namespace TextProcessing_MoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string person = string.Empty;
                string age = string.Empty;
                bool personCheck = false;
                bool ageCheck = false;

                for (int j = 0; j < input.Length; j++)
                {
                    char currenSymbol = input[j];

                    if (currenSymbol == '@')
                    {
                        personCheck = true;
                    }
                    else if (currenSymbol == '|')
                    {
                        personCheck = false;
                    }

                    if (personCheck && currenSymbol != '@')
                    {
                        person += currenSymbol;
                    }

                    if (currenSymbol == '#')
                    {
                        ageCheck = true;
                    }
                    else if (currenSymbol == '*')
                    {
                        ageCheck = false;
                    }

                    if (ageCheck && currenSymbol != '#')
                    {
                        age += currenSymbol;
                    }
                }

                Console.WriteLine($"{person} is {age} years old.");
            }
        }
    }
}
