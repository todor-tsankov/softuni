using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldestFamilyMember
{
    class Person
    {
        public Person(string namePlusAge)
        {
            string[] nameAgeSeparated = namePlusAge.Split();
            Name = nameAgeSeparated[0];
            Age = int.Parse(nameAgeSeparated[1]);
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
