using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldestFamilyMember
{
    class Family
    {
        public Family()
        {
            listOfMembers = new List<Person>();
        }
        public List<Person> listOfMembers { get; set; }
        public void AddMember(Person person)
        {
            listOfMembers.Add(person);
        }

        public string GetOldestMember()
        {
            listOfMembers = listOfMembers.OrderByDescending(i => i.Age).ToList();
            return listOfMembers[0].Name + " " + listOfMembers[0].Age;
        }
    }
}
