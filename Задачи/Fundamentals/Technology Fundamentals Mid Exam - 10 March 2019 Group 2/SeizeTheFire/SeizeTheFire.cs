using System;
using System.Collections.Generic;

namespace Technology_Fundamentals_Mid_Exam___10_March_2019_Group_2
{
    class TheHuntingGames
    {
        static void Main(string[] args)
        {
            string[] fires = Console.ReadLine().Split('#');
            int water = int.Parse(Console.ReadLine());
            double effort = 0;

            List<int> putOutFires = new List<int>();

            for (int i = 0; i < fires.Length; i++)
            {
                bool isValid = false;
                string[] currentFire = fires[i].Split(" = ", StringSplitOptions.RemoveEmptyEntries);
                int valueOfCell = int.Parse(currentFire[1]);
                string typeOfFire = currentFire[0];

                if (water < valueOfCell)
                {
                    continue;
                }

                switch (typeOfFire)
                {
                    case "High":
                        if (valueOfCell >= 81 && valueOfCell <= 125)
                        {
                            water -= valueOfCell;
                            isValid = true;
                        }
                        break;
                    case "Medium":
                        if (valueOfCell >= 51 && valueOfCell <= 80)
                        {
                            water -= valueOfCell;
                            isValid = true;
                        }
                        break;
                    case "Low":
                        if (valueOfCell >= 1 && valueOfCell <= 50)
                        {
                            water -= valueOfCell;
                            isValid = true;
                        }
                        break;
                }

                if (isValid)
                {
                    effort += valueOfCell * 0.25;
                    putOutFires.Add(valueOfCell);
                }
            }

            Console.WriteLine("Cells:");
            int fire = 0;
            foreach (var item in putOutFires)
            {
                Console.WriteLine($" - {item}");
                fire += item;
            }

            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {fire}");
        }
    }
}
