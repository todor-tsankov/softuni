using System;
using System.Linq;
using System.Text;

namespace _5.DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var letters = new StringBuilder();
            var digits = new StringBuilder();
            var characters = new StringBuilder();

            foreach (var item in input)
            {
                if (char.IsLetter(item))
                {
                    letters.Append(item);
                }
                else if (char.IsDigit(item))
                {
                    digits.Append(item);
                }
                else
                {
                    characters.Append(item);
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(characters);
        }
    }
}
