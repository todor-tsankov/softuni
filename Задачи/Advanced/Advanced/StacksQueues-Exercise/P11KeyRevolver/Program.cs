using System;
using System.Collections.Generic;
using System.Linq;

namespace P11KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceForABullet = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());

            var bulletSequence = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

            var locksSequence = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

            var valueOfTheIntelligence = int.Parse(Console.ReadLine());

            var locks = new Queue<int>(locksSequence);
            var bullets = new Stack<int>(bulletSequence);

            var costBullets = 0;
            var gunBarrell = new Queue<int>();

            ReloadGun(gunBarrell, bullets, gunBarrelSize);

            while (locks.Any() && gunBarrell.Any())
            {
                if (gunBarrell.Any())
                {
                    var currenBullet = gunBarrell.Dequeue();
                    var currentLock = locks.Peek();

                    if (currenBullet <= currentLock)
                    {
                        Console.WriteLine("Bang!");

                        locks.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }

                    costBullets += priceForABullet;
                }

                if (!gunBarrell.Any() && bullets.Any())
                {
                    ReloadGun(gunBarrell, bullets, gunBarrelSize);

                    Console.WriteLine("Reloading!");
                }
            }



            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                var moneyEarned = valueOfTheIntelligence - costBullets;

                Console.WriteLine($"{bullets.Count + gunBarrell.Count} bullets left. Earned ${moneyEarned}");
            }
        }

        static void ReloadGun(Queue<int> gunBarell, Stack<int> bullets, int gunBarrelSize)
        {

            for (int i = 0; i < gunBarrelSize; i++)
            {
                if (bullets.Any())
                {
                    var currentBullet = bullets.Pop();

                    gunBarell.Enqueue(currentBullet);
                }
                else
                {
                    break;
                }
            }
        }


    }
}
