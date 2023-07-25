using System;
using System.Collections.Generic;
using System.Linq;

namespace P06ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingLot = new HashSet<string>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var directionAndCarNumber = command.Split(", ");

                var direction = directionAndCarNumber[0];
                var carNumber = directionAndCarNumber[1];

                if (direction == "IN")
                {
                    parkingLot.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    parkingLot.Remove(carNumber);
                }
            }

            if (parkingLot.Any())
            {
                foreach (var number in parkingLot)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
