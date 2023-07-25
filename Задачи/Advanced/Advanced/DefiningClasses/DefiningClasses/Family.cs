using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members;
        public Family()
        {
            this.Members = new List<Person>();
        }

        public List<Person> Members
        {
            get
            {
                return this.members;
            }
            set
            {
                this.members = value;
            }
        }

        public void AddMember(Person member)
        {
            this.Members.Add(member);
        }

        public Person GetOldestMember()
        {
            var oldestMember = new Person(-1);

            foreach (var member in this.Members)
            {
                if (member.Age > oldestMember.Age)
                {
                    oldestMember = member;
                }
            }

            return oldestMember;
        }
    }
}
