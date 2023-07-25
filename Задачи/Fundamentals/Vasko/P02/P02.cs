using System;

namespace P02
{
    class P02
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            int m = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            bool containsInvalidCharacters = false;

            for (int i = 0; i < str.Length; i++)
            {
                char currentChar = str[i];

                if (currentChar < 32 || currentChar > 126)
                {
                    containsInvalidCharacters = true;
                }
            }

            if (!containsInvalidCharacters)
            {
                char[] arrayOfChars = str.ToCharArray();

                for (int i = 0; i < arrayOfChars.Length; i++)
                {
                    arrayOfChars[i] = (char)(arrayOfChars[i] + m);
                }


                for (int i = 0; i < l; i++)
                {
                    char savedFirstLetter = arrayOfChars[0];

                    for (int j = 1; j < arrayOfChars.Length; j++)
                    {
                        char nextSaved = arrayOfChars[j];
                        arrayOfChars[j] = savedFirstLetter;

                        savedFirstLetter = nextSaved;
                    }

                    arrayOfChars[0] = savedFirstLetter;
                }

                string newString = new string(arrayOfChars);

                Console.WriteLine(newString);
            }
            else
            {
                Console.WriteLine(str);
            }
        }
    }
}
