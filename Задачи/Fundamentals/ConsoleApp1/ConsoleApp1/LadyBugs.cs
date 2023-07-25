using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadyBugs
{
    class LadyBugs
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            int[] initialIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] field = new int[sizeOfField];

            for (int i = 0; i < initialIndexes.Length; i++)
            {
                if (initialIndexes[i] >= 0 && initialIndexes[i] < sizeOfField)
                {
                    field[initialIndexes[i]] = 1;
                }
            }

            string input = string.Empty;

            while (input != "end")
            {
                input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string[] commands = input.Split();

                int ladybugIndex = int.Parse(commands[0]);
                string direction = commands[1];
                int flyLength = int.Parse(commands[2]);

                if (flyLength == 0)
                {
                    continue;
                }
                else if (ladybugIndex < 0 || ladybugIndex >= sizeOfField)
                {
                    continue;
                }
                else if (field[ladybugIndex] == 0)
                {
                    continue;
                }
                else if (flyLength < 0)
                {
                    if (direction == "left")
                    {
                        direction = "right";
                    }
                    else
                    {
                        direction = "left";
                    }

                    flyLength = Math.Abs(flyLength);
                }
                
                if (direction == "left")
                {
                    while (ladybugIndex - flyLength >= 0)
                    {
                            if (field[ladybugIndex - flyLength] == 0)
                            {
                                field[ladybugIndex - flyLength] = 1;
                                break;
                            }

                        flyLength *= 2;
                    }
                }
                else if (direction == "right")
                {
                    while (ladybugIndex + flyLength < sizeOfField)
                    {
                                if (field[ladybugIndex + flyLength] == 0 )
                                {
                                        field[ladybugIndex + flyLength] = 1;
                                        break;
                                }

                        flyLength *= 2;
                    }

                }

                field[ladybugIndex] = 0;
            }

            for (int i = 0; i < sizeOfField; i++)
            {
                Console.Write(field[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
