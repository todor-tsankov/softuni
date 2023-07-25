using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldestFamilyMember
{
    class OldestFamilyMember
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                Person currentPerson = new Person(Console.ReadLine());
                family.AddMember(currentPerson);
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
