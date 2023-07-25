using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            string[] manArray = Console.ReadLine().Split();
            string command = string.Empty;

            while (true)
            {
                command = Console.ReadLine();

                if (command == "end")
                {
                    Console.Write("[");

                    for (int i = 0; i < manArray.Length; i++)
                    {
                        Console.Write(manArray[i]);

                        if (i < manArray.Length - 1)
                        {
                            Console.Write(", ");
                        }
                    }

                    Console.Write("]");
                    Console.WriteLine();

                    break;
                }

                string[] commandArray = command.Split();

                if (commandArray[0] == "exchange")
                {
                    manArray = Exchange(manArray , commandArray);
                }
                else if (commandArray[0] == "max")
                {
                    string result = string.Empty;

                    if (commandArray[1] == "even")
                    {
                        result = MaxEven(manArray);
                    }
                    else if (commandArray[1] == "odd")
                    {
                        result = MaxOdd(manArray);
                    }

                    Console.WriteLine(result);
                }
                else if (commandArray[0] == "min")
                {
                    string result = string.Empty;

                    if (commandArray[1] == "even")
                    {
                        result = MinEven(manArray);
                    }
                    else if (commandArray[1] == "odd")
                    {
                        result = MinOdd(manArray);
                    }

                    Console.WriteLine(result);
                }
                else if (commandArray[0] == "first")
                {
                    int count = int.Parse(commandArray[1]);

                    if (commandArray[2] == "even")
                    {
                        FirstEven(manArray, count);
                    }
                    else if (commandArray[2] == "odd")
                    {
                        FirstOdd(manArray, count);
                    }
                }
                else if (commandArray[0] == "last")
                {
                    int count = int.Parse(commandArray[1]);

                    if (commandArray[2] == "even")
                    {
                        LastEven(manArray, count);
                    }
                    else if (commandArray[2] == "odd")
                    {
                        LastOdd(manArray, count);
                    }
                }
            }
        }

        static string[] Exchange(string[] manArray, string[] command)
        {
            int length = manArray.Length;
            int index = int.Parse(command[1]);

            if (index >= 0 && index < length)
            {
                string[] firstPart = new string[index + 1];
                string[] secondPart = new string[length - index - 1];
                int counter = 0;

                for (int i = 0; i <= index ; i++)
                {
                    firstPart[i] = manArray[i];
                }

                for (int i = index + 1; i < length; i++)
                {
                    secondPart[counter] = manArray[i];
                    counter++;
                }

                manArray = secondPart.Concat(firstPart).ToArray();
            }
            else
            {
                Console.WriteLine("Invalid index");
                return manArray;
            }
            return manArray;
        }

        static string MaxOdd(string[] manArray)
        {
            string result = string.Empty;
            int max = int.MinValue;
            int index = -1;

            for (int i = 0; i < manArray.Length; i++)
            {
                int currentNumber = int.Parse(manArray[i]);

                if (currentNumber % 2 != 0 && currentNumber >= max)
                {
                    max = currentNumber;
                    index = i;
                }
            }

            if (index == -1)
            {
                return "No matches";
            }
            else
            {
                return index.ToString();
            }
        }

        static string MaxEven(string[] manArray)
        {
            string result = string.Empty;
            int max = int.MinValue;
            int index = -1;

            for (int i = 0; i < manArray.Length; i++)
            {
                int currentNumber = int.Parse(manArray[i]);

                if (currentNumber % 2 == 0 && currentNumber >= max)
                {
                    max = currentNumber;
                    index = i;
                }
            }

            if (index == -1)
            {
                return "No matches";
            }
            else
            {
                return index.ToString();
            }
        }

        static string MinOdd(string[] manArray)
        {
            string result = string.Empty;
            int min = int.MaxValue;
            int index = -1;

            for (int i = 0; i < manArray.Length; i++)
            {
                int currentNumber = int.Parse(manArray[i]);

                if (currentNumber % 2 != 0 && currentNumber <= min)
                {
                    min = currentNumber;
                    index = i;
                }
            }

            if (index == -1)
            {
                return "No matches";
            }
            else
            {
                return index.ToString();
            }
        }

        static string MinEven(string[] manArray)
        {
            string result = string.Empty;
            int min = int.MaxValue;
            int index = -1;

            for (int i = 0; i < manArray.Length; i++)
            {
                int currentNumber = int.Parse(manArray[i]);

                if (currentNumber % 2 == 0 && currentNumber <= min)
                {
                    min = currentNumber;
                    index = i;
                }
            }

            if (index == -1)
            {
                return "No matches";
            }
            else
            {
                return index.ToString();
            }
        }

        static void FirstEven(string[] manArray, int count)
        {
            int counter = 0;
            string[] result = new string[count];

            if (count > manArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            for (int i = 0; i < manArray.Length; i++)
            {
                int currentNumber = int.Parse(manArray[i]);

                if (currentNumber % 2 == 0 && counter < count)
                {
                    result[counter] = currentNumber.ToString();
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.Write("[");

                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] == null)
                    {
                        continue;
                    }

                    Console.Write(result[i]);

                    if (i < result.Length - 1 && result[i + 1] != null)
                    {
                        Console.Write(", ");
                    }
                }

                Console.Write("]");
                Console.WriteLine();
            }

        }

        static void FirstOdd(string[] manArray, int count)
        {
            int counter = 0;
            string[] result = new string[count];

            if (count > manArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            for (int i = 0; i < manArray.Length; i++)
            {
                int currentNumber = int.Parse(manArray[i]);

                if (currentNumber % 2 != 0 && counter < count)
                {
                    result[counter] = currentNumber.ToString();
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.Write("[");

                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] == null)
                    {
                        continue;
                    }

                    Console.Write(result[i]);

                    if (i < result.Length - 1 && result[i + 1] != null)
                    {
                        Console.Write(", ");
                    }
                }

                Console.Write("]");
                Console.WriteLine();
            }
        }

        static void LastEven(string[] manArray, int count)
        {
            int counter = 0;
            string[] result = new string[count];

            if (count > manArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            for (int i = manArray.Length - 1; i >= 0; i--)
            {
                int currentNumber = int.Parse(manArray[i]);

                if (currentNumber % 2 == 0 && counter < count)
                {
                    result[counter] = currentNumber.ToString();
                    counter++;
                }
            }

            Array.Reverse(result);

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.Write("[");

                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] == null)
                    {
                        continue;
                    }

                    Console.Write(result[i]);

                    if (i < result.Length - 1 && result[i + 1] != null)
                    {
                        Console.Write(", ");
                    }
                }

                Console.Write("]");
                Console.WriteLine();
            }
        }

        static void LastOdd(string[] manArray, int count)
        {
            int counter = 0;
            string[] result = new string[count];

            if (count > manArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            for (int i = manArray.Length - 1; i >= 0; i--)
            {
                int currentNumber = int.Parse(manArray[i]);

                if (currentNumber % 2 != 0 && counter < count)
                {
                    result[counter] = currentNumber.ToString();
                    counter++;
                }
            }

            Array.Reverse(result);

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.Write("[");

                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] == null)
                    {
                        continue;
                    }

                    Console.Write(result[i]);
                    
                    if (i < result.Length - 1 && result[i+1] != null)
                    {
                        Console.Write(", ");
                    }
                }

                Console.Write("]");
                Console.WriteLine();
            }
        }
    }
}
