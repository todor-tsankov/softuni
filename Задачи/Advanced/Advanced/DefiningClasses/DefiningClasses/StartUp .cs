using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine().Split();

                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);

                people.Add(new Person(name, age));
            }

            people.Where(p => p.Age > 30)
                  .OrderBy(p => p.Name)
                  .ToList()
                  .ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }
    }
}
