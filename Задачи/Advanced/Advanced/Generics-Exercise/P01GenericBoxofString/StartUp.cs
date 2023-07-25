using System;

namespace P01GenericBoxofString
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var box = new Box<int>(int.Parse(Console.ReadLine()));

                Console.WriteLine(box.ToString());
            }
        }
    }
}
