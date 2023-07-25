using System;
using System.Linq;

namespace P01ListyIterator
{
    public class StartUp
    {
        static void Main()
        {
            var createCommand = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .ToList()
                                       .Skip(1);

            var list = new ListyIterator<string>(createCommand);

            while (true)
            {
                var currentCommand = Console.ReadLine();

                if (currentCommand == "END")
                {
                    break;
                }

                if (currentCommand == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (currentCommand == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
                else if (currentCommand == "Print")
                {
                    try
                    {
                        list.Print();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (currentCommand == "PrintAll")
                {
                    try
                    {
                        list.PrintAll();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
        }
    }
}
