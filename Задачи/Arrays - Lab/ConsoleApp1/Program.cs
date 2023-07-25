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
                string[] commands = input.Split();

                int ladybugIndex = int.Parse(commands[0]);
                string direction = commands[1];
                int flyLength = int.Parse(commands[2]);

                if (direction == "left")
                {
                    if (flyLength > sizeOfField - ladybugIndex)
                    {
                        field[ladybugIndex] = 0;
                    }
                    else
                    {
                        field[ladybugIndex] = 0;

                        if (field[ladybugIndex + flyLength] == 1)
                        {
                            ladybugIndex = ladybugIndex + 2 * flyLength;

                            if (flyLength < ladybugIndex)
                            {
                                field[ladybugIndex] = 1;
                            }
                        }
                        else
                        {
                            field[ladybugIndex + flyLength] = 1;
                        }

                    }
                }
                else if (direction == "right")
                {
                    if (flyLength > ladybugIndex)
                    {
                        field[ladybugIndex] = 0;
                    }
                    else
                    {
                        field[ladybugIndex] = 0;

                        if (field[ladybugIndex - flyLength] == 1)
                        {
                            ladybugIndex = ladybugIndex + 2 * flyLength;

                            if (flyLength < ladybugIndex)
                            {
                                field[ladybugIndex] = 1;
                            }
                        }
                        else
                        {
                            field[ladybugIndex + flyLength] = 1;
                        }

                    }
                }
            }

            for (int i = 0; i < sizeOfField; i++)
            {
                Console.Write(field[i] + " ");
            }
        }
    }
}
