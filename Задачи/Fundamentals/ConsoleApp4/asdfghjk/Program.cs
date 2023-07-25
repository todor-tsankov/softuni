using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrumSet
{
    class DrumSet
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumsList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> drumsListOriginalState = new List<int>(drumsList.ToList());
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                for (int i = 0; i < drumsList.Count; i++)
                {
                    drumsList[i] -= int.Parse(command);

                    if (drumsList[i] <= 0)
                    {
                        savings -= drumsListOriginalState[i] * 3;

                        if (savings >= 0)
                        {
                            drumsList[i] = drumsListOriginalState[i];
                        }
                        else
                        {
                            savings = 0;
                            drumsList.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", drumsList));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
