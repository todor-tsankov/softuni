using System;

namespace TextProcessing_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine().Split(", ");

            foreach (var user in userNames)
            {
                bool length = user.Length >= 3 && user.Length <= 16;
                bool conatains = true;

                foreach (var symbol in user)
                {
                    if (!char.IsLetterOrDigit(symbol) 
                          && symbol != '_' 
                          && symbol != '-')
                    {
                        conatains = false;
                        break;
                    }
                }

                if (length && conatains)
                {
                    Console.WriteLine(user);
                }
            }
        }
    }
}
