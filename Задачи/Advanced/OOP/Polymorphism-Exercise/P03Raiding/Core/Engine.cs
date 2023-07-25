using System;
using System.Linq;
using System.Collections.Generic;
using P03Raiding.Models;

namespace P03Raiding.Core
{
    public class Engine
    {
        private List<BaseHero> heroes = new List<BaseHero>();
        public void Run()
        {
            var n = int.Parse(Console.ReadLine());
            ReadInputHeroes(n);

            var bossPower = int.Parse(Console.ReadLine());
            PrintResult(bossPower);
        }

        private void PrintResult(int bossPower)
        {
            this.heroes.ForEach(h => Console.WriteLine(h.CastAbility()));

            var sum = this.heroes.Sum(h => h.Power);

            if (sum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private void ReadInputHeroes(int n)
        {
            while (this.heroes.Count < n)
            {
                var heroName = Console.ReadLine();
                var heroType = Console.ReadLine();

                var currentHero = CreateHeroOrDefault(heroName, heroType);

                if (currentHero != null)
                {
                    this.heroes.Add(currentHero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }
        }

        public BaseHero CreateHeroOrDefault(string name, string type)
        {
            BaseHero baseHero = null;

            if (type == "Druid")
            {
                baseHero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                baseHero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                baseHero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                baseHero = new Warrior(name);
            }

            return baseHero;
        }
    }
}
