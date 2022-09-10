using System;
using System.Collections.Generic;
using System.Linq;

namespace P10CrossRoads
{
    class Program
    {
        static void Main(string[] args)
        {
            var greenLightDuration = int.Parse(Console.ReadLine());
            var freeWindowDuration = int.Parse(Console.ReadLine());

            var currentGreen = greenLightDuration;
            var currentFree = freeWindowDuration;

            var carsPassedSafely = 0;
            var safe = true;
            var crash = true;

            var currentCar = Console.ReadLine();

            var outsideTheCrossroad = new Queue<string>();
            var insideTheCrossroad = new Queue<string>();

            var hitCar = string.Empty;
            var hitAt = 'a';

            while (currentCar != "END" && crash)
            {
                currentGreen = greenLightDuration;
                currentFree = freeWindowDuration;

                if (currentCar != "green")
                {
                    outsideTheCrossroad.Enqueue(currentCar);
                }
                else
                {
                    while (outsideTheCrossroad.Any())
                    {
                        if (currentGreen > 0)
                        {
                            var enteringCar = outsideTheCrossroad.Dequeue();

                            currentGreen -= enteringCar.Length;
                            carsPassedSafely++;

                            if (currentGreen <= 0)
                            {
                                insideTheCrossroad.Enqueue(enteringCar);
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    while (insideTheCrossroad.Any())
                    {
                        var exitCar = insideTheCrossroad.Dequeue();
                        currentFree += currentGreen;

                        if (currentFree < 0)
                        {
                            hitCar = exitCar;
                            hitAt = exitCar[exitCar.Length + currentFree];

                            safe = false;
                            crash = false;

                            break;
                        }
                    }
                }

                currentCar = Console.ReadLine();
            }

            if (safe)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsPassedSafely} total cars passed the crossroads.");
            }
            else
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hitCar} was hit at {hitAt}.");
            }
        }
    }
}
