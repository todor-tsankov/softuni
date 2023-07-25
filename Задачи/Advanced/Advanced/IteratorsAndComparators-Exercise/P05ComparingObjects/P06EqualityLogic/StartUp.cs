using System;
using System.Collections.Generic;

namespace P06EqualityLogic
{
    public class StartUp
    {
        static void Main()
        {
            var sortedSet = new SortedSet<Person>();
            var justSet = new HashSet<Person>();

            var n = int.Parse(Console.ReadLine());

            ReadInputPersons(sortedSet, justSet, n);

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(justSet.Count);
        }

        static void ReadInputPersons(SortedSet<Person> sortedSet, HashSet<Person> justSet, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);

                var currentPerson = new Person(name, age);

                sortedSet.Add(currentPerson);
                justSet.Add(currentPerson);
            }
        }
    }
}
