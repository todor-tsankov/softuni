using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputClothes = Console.ReadLine()
                                      .Split()
                                      .Select(int.Parse);

            var currentRack = 0;
            var rackCounter = 1;

            var rackCapacity = int.Parse(Console.ReadLine());
            var clothesStack = new Stack<int>(inputClothes);

            while (clothesStack.Any())
            {
                var currenCloth = clothesStack.Peek();

                if (currentRack + currenCloth <= rackCapacity)
                {
                    clothesStack.Pop();

                    currentRack += currenCloth;
                }
                else
                {
                    currentRack = 0;

                    rackCounter++;
                }
            }

            Console.WriteLine(rackCounter);
        }
    }
}
