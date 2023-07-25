using System;
using System.Linq;
using System.Text;

namespace _3.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine()
                               .Split()
                               .Select(int.Parse)
                               .ToArray();

            while (true)
            {
                string currenEncryptedMessage = Console.ReadLine();
                int length = currenEncryptedMessage.Length;

                if (currenEncryptedMessage == "find")
                {
                    break;
                }

                StringBuilder message = new StringBuilder(length);
                int counter = 0;

                for (int i = 0; i < length; i++)
                {
                    char newSymbol =(char) (currenEncryptedMessage[i] - key[counter]);
                    message.Append(newSymbol);
                    counter++;

                    if (counter >= key.Length)
                    {
                        counter = 0;
                    }
                }

                string messageString = message.ToString();
                string treasure = messageString.Split('&')[1];
                string coordinates = messageString.Split('<','>')[1];

                Console.WriteLine($"Found {treasure} at {coordinates}");
            }
        }
    }
}
