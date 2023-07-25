using System;
using System.Linq;

namespace P07Tuple
{
    class StartUp
    {
        public static void Main()
        {
            var input = GetInput();

            var tuple = new Tuple<string, string>()
            {
                Item1 = $"{input[0]} {input[1]}",
                Item2 = input[2]
            };

            input = GetInput();

            var tuple2 = new Tuple<string, int>()
            {
                Item1 = input[0],
                Item2 = int.Parse(input[1])
            };


            input = GetInput();

            var tuple3 = new Tuple<int, double>()
            {
                Item1 = int.Parse(input[0]),
                Item2 = double.Parse(input[1])
            };

            Print(tuple);
            Print(tuple2);
            Print(tuple3);
        }

        private static void Print<T, K>(Tuple<T, K> tuple)
        {
            Console.WriteLine($"{tuple.Item1} -> {tuple.Item2}");
        }

        private static string[] GetInput()
        {
            return Console.ReadLine().Split().ToArray();
        }
    }
}
