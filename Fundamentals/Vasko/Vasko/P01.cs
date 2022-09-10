using System;

namespace Vasko
{
    class P01
    {
        static void Main(string[] args)
        {
            // Read the input string from the console

            string str = Console.ReadLine();

            // Create a variable to store the number of row (output)

            int numberOfRow = 0;

            // iterate through the string in reverse
            int position = 1;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                // Take the letter at position i
                char currentLetter = str[i];

                // Find the position of the letter in the alphabet
                int letterPositionInAlphabet = (currentLetter  - 64);

                //Multiply the positionIn the alphabet by the position in the string. Add the result to the total
                // С всяка позиция на ляво буквата има 26 пъти по-голяма стойност

                numberOfRow += letterPositionInAlphabet * position;

                // increase the position
                position *= 26;
            }


            // Print the result
            Console.WriteLine(numberOfRow);
        }
    }
}
