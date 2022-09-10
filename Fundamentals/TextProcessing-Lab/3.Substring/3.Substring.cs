using System;

namespace _3.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string match = Console.ReadLine().ToLower();
            string text = Console.ReadLine();

            while (text.Contains(match))
            {
                text = text.Replace(match, "");
            }

            Console.WriteLine(text);
        }
    }
}
