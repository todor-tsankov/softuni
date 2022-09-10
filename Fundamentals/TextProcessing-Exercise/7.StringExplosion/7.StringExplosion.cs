using System;

namespace _7.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    int strength = int.Parse(input[i + 1].ToString());

                    for (int j = 0; j < strength; j++)
                    {
                        if (i + 2 >= input.Length)
                        {
                            input = input.Remove(i + 1, 1);
                            break;
                        }

                        if (input[i + 1] == '>')
                        {
                            strength += int.Parse(input[i + 2].ToString());
                            strength++;
                            i++;
                        }
                        else
                        {
                            input = input.Remove(i + 1, 1);
                        }
                    }
                }
            }

            Console.WriteLine(input);
        }
    }
}
