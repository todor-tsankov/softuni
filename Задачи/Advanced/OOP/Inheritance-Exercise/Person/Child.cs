using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
        }

        public override string Name
        {
            get
            {
                return this.Name;
            }
            set
            {
                if (this.Age > 15)
                {
                    throw new InvalidOperationException();
                }

                this.Name = value;
            }
        }
    }
}
