using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonArmy
{
    class DragonArmy
    {
        static void Main(string[] args)
        {
            List<Type> typeList = new List<Type>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string type = inputArgs[0];
                string name = inputArgs[1];
                string stringDamage = inputArgs[2];
                string stringHealth = inputArgs[3];
                string stringArmor = inputArgs[4];
                int damage = 45;
                int health = 250;
                int armor = 10;

                if (stringDamage != "null")
                {
                    damage = int.Parse(stringDamage);
                }

                if (stringHealth != "null")
                {
                    health = int.Parse(stringHealth);
                }

                if (stringArmor != "null")
                {
                    armor = int.Parse(stringArmor);
                }

                int typeIndex = typeList.FindIndex(j => j.NameType == type);

                if (typeIndex < 0)
                {
                    typeList.Add(new Type(type));
                    typeIndex = typeList.FindIndex(j => j.NameType == type);
                }

                int dragonIndex = typeList[typeIndex].DragonList.FindIndex(j => j.Name == name);

                if (dragonIndex < 0)
                {
                    typeList[typeIndex].DragonList.Add(new Dragon(name, damage, health, armor));
                }
                else
                {
                    typeList[typeIndex].DragonList[dragonIndex] = new Dragon(name, damage, health, armor);
                }
            }

            

            for (int i = 0; i < typeList.Count; i++)
            {
                for (int k = 0; k < typeList[i].DragonList.Count; k++)
                {
                    typeList[i].AverageArmor += typeList[i].DragonList[k].Armor;
                    typeList[i].AverageDamage += typeList[i].DragonList[k].Damage;
                    typeList[i].AverageHealth += typeList[i].DragonList[k].Health;
                }

                int count = typeList[i].DragonList.Count;
                typeList[i].AverageArmor /= count;
                typeList[i].AverageHealth /= count;
                typeList[i].AverageDamage /= count;
            }

            foreach (var type in typeList)
            {
                Console.WriteLine($"{type.NameType}::({type.AverageDamage:f2}/{type.AverageHealth:f2}/{type.AverageArmor:f2})");
                var filteredDragons = type.DragonList.OrderBy(i => i.Name);

                foreach (var dragon in filteredDragons)
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
            
        }
    }

    class Dragon
    {
        public Dragon(string name, int damage, int health, int armor)
        {
            Name = name;
            Damage = damage;
            Health = health;
            Armor = armor;
        }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
    }

    class Type
    {
        public Type(string nameType)
        {
            NameType = nameType;
            DragonList = new List<Dragon>();
            AverageDamage = 0;
            AverageArmor = 0;
            AverageHealth = 0;
        }
        public string NameType { get; set; }
        public double AverageDamage { get; set; }
        public double AverageHealth { get; set; }
        public double AverageArmor { get; set; }

        public List<Dragon> DragonList { get; set; }
    }
}
