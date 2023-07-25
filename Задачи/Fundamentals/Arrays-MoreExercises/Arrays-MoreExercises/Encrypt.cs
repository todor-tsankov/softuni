using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_MoreExercises
{
    class Encrypt
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());
            int[] results = new int[100];

            for (int i = 0; i < numberOfStrings; i++)
            {
                string input = Console.ReadLine();
                int result = 0;

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'a' || input[j] == 'e' || input[j] == 'o' || input[j] == 'i' || input[j] == 'u' || input[j] == 'A' || input[j] == 'E' || input[j] == 'O' || input[j] == 'U'|| input[j] == 'I')
                    {
                        result += input[j] * input.Length;
                    }
                    else 
                    {
                        result += input[j]  / input.Length;
                    }
                }

                results[i] = result;
            }

            var sortedCopy = results.OrderBy(i => i);

            foreach (var item in sortedCopy)
            {
                if (item != 0)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
