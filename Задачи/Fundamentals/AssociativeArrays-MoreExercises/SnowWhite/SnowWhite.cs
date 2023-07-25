using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowWhite
{
    class SnowWhite
    {
        static void Main(string[] args)
        {
            List<Dwarf> dwarfList = new List<Dwarf>();
            Dictionary<string, int> hatColorCount = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Once upon a time")
                {
                    break;
                }

                string[] inputParts = input.Split(" <:> "); // " <:> "
                string dwarfName = inputParts[0];
                string hatColor = inputParts[1];
                int physics = int.Parse(inputParts[2]);
                int index = dwarfList.FindIndex(i => i.Name == dwarfName && i.HatColor == hatColor);

                if (!hatColorCount.ContainsKey(hatColor))
                {
                    hatColorCount[hatColor] = 0;
                }

                if (index < 0)
                {
                    dwarfList.Add(new Dwarf(dwarfName, hatColor, physics));
                    hatColorCount[hatColor]++;
                }
                else if(index >= 0)
                {
                    if (dwarfList[index].Physics < physics)
                    {
                        dwarfList[index] = new Dwarf(dwarfName, hatColor, physics);
                        hatColorCount[hatColor]++;
                    }
                }
            }

            var filteredDwarfs = dwarfList.OrderByDescending(i => i.Physics).ThenByDescending(i => hatColorCount[i.HatColor]);

            foreach (var dwarf in filteredDwarfs)
            {
                Console.WriteLine($"({dwarf.HatColor}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }

    class Dwarf
    {
        public Dwarf(string name, string hatColor, int physics)
        {
            Name = name;
            HatColor = hatColor;
            Physics = physics;
        }
        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Physics { get; set; }
    }
}
