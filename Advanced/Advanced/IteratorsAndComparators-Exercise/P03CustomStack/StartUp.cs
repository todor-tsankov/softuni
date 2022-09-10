using System;
using System.Linq;

namespace P03CustomStack
{
    public class StartUp
    {
        static void Main()
        {
            var customStack = new CustomStack<string>();

            ProcessInput(customStack);

            Print(customStack);
            Print(customStack);
        }

        private static void ProcessInput(CustomStack<string> customStack)
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                if (command == "Pop")
                {
                    try
                    {
                        customStack.Pop();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    

                    continue;
                }

                var toBePushed = command.Split(new char[] {' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Skip(1);

                customStack.Push(toBePushed);
            }
        }

        private static void Print(CustomStack<string> customStack)
        {
            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
