using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileLoop_MoreExercise
{
    class DishWasher
    {
        static void Main(string[] args)
        {
            int numberBottles = int.Parse(Console.ReadLine());
            int soapQuantity = numberBottles * 750;
            int counter = 0;
            int counterPots = 0;
            int counterDishes = 0;
            int usedSoap = 0;
            string command = "0";


            while (soapQuantity >= usedSoap && command != "End")
            {
               
                int dishes = int.Parse(command);
                if (counter % 3 == 0 && counter != 1)
                {
                    usedSoap += dishes * 15;
                    counterPots += dishes;
                }
                else
                {
                    usedSoap += dishes * 5;
                    counterDishes += dishes;
                }
                if(soapQuantity < usedSoap)
                {
                    break;
                }
                command = Console.ReadLine();
                counter++;
            }

            if (soapQuantity >= usedSoap)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{counterDishes} dishes and {counterPots} pots were washed.");
                Console.WriteLine($"Leftover detergent {soapQuantity - usedSoap} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {usedSoap - soapQuantity} ml. more necessary!");
            }
        }
    }
}
