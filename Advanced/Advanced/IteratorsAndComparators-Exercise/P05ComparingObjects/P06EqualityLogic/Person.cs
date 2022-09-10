using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace P06EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public int CompareTo(Person other)
        {
            var result = this.name.CompareTo(other.name);

            if (result == 0)
            {
                result = this.age.CompareTo(other.age);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (obj.GetHashCode() != this.GetHashCode())
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            var code = 0;

            foreach (var ch in this.name)
            {
                code += ch;
            }

            var stringCode = "";

            stringCode += code;
            stringCode += age;

            return int.Parse(stringCode);
        }
    }
}
