using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName 
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                CommonValidator.ValidateLength(value, 3, "First name cannot contain fewer than 3 symbols!");

                this.firstName = value;
            }
        }
        public string LastName 
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                CommonValidator.ValidateLength(value, 3, "Last name cannot contain fewer than 3 symbols!");

                this.lastName = value;
            }
        }
        public int Age 
        {
            get
            {
                return this.age;
            }
            private set
            {
                CommonValidator.ValidateMin(value, 1, "Age cannot be zero or a negative integer!");

                this.age = value;
            }
        }

        public decimal Salary 
        {
            get
            {
                return this.salary;
            }
            private set
            {
                CommonValidator.ValidateMin(value, 460, "Salary cannot be less than 460 leva!");

                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            var delimiter = 100;

            if (this.Age < 30)
            {
                delimiter = 200;
            }

            this.Salary += this.Salary * percentage / delimiter;
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }

    }
}
