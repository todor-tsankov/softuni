using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderByAge
{
    class OrderByAge
    {
        static void Main(string[] args)
        {
            List<Person> listOfPeople = new List<Person>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                listOfPeople.Add(new Person(input));
            }

            listOfPeople = listOfPeople.OrderBy(i => i.Age).ToList();

            foreach (var item in listOfPeople)
            {
                Console.WriteLine($"{item.Name} with ID: {item.Id} is {item.Age} years old.");
            }
        }
    }

    class Person
    {
        public Person(string input)
        {
            string[] parts = input.Split();
            Name = parts[0];
            Id = parts[1];
            Age = int.Parse(parts[2]);
        }
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
    }
}
