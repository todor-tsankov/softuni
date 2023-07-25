using System;

namespace Test
{
    class Program
    {
        static void Main()
        {
            var countPresents = int.Parse(Console.ReadLine());
            var size = int.Parse(Console.ReadLine());

            var firstLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var secondLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var thirdLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var forthLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //if (thirdLine[1][0] == 'V')
            //{
            //    throw new Exception();
            //}

            var firstCommand = Console.ReadLine();

            if (firstCommand == "up")
            {

            }
        }
    }
}
