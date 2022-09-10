using System;
using System.Linq;

namespace P03Telephony
{
    public class StartUp
    {
        static void Main()
        {
            var numbers = ReadInputArray();
            var urls = ReadInputArray();

            CallNumbers(numbers);
            BrowseURLs(urls);
        }

        private static void BrowseURLs(string[] urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    var smartphone = new Smartphone();

                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static void CallNumbers(string[] numbers)
        {
            foreach (var number in numbers)
            {
                var numLength = number.Length;

                try
                {
                    var result = string.Empty;

                    if (numLength == 7)
                    {
                        var stationaryPhone = new StationaryPhone();

                        result = stationaryPhone.Call(number);
                    }
                    else if (numLength == 10)
                    {
                        var smartphone = new Smartphone();

                        result = smartphone.Call(number);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid number!");
                    }

                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static string[] ReadInputArray()
        {
            return Console.ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();
        }
    }
}
