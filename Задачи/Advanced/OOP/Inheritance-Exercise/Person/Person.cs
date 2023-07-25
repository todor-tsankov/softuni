﻿using System;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == string.Empty || value == null)
                {
                    throw new InvalidOperationException();
                }

                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException();
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"Name: {this.Name}, Age: {this.Age}");

            return sb.ToString()
                     .Trim();
        }
    }
}
