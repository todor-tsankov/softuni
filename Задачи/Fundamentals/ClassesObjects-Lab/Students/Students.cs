using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Students
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Student> listOfStudents = new List<Student>();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] infoParts = command.Split();
                bool isThereEqual = false;
                int indexOfEqual = 0;

                for (int i = 0; i < listOfStudents.Count; i++)
                {
                    if (listOfStudents[i].firstName == infoParts[0] && listOfStudents[i].lastName == infoParts[1])
                    {
                        isThereEqual = true;
                        indexOfEqual = i;
                    }
                }

                if (isThereEqual)
                {
                    listOfStudents[indexOfEqual] = new Student()
                    {
                        firstName = infoParts[0],
                        lastName = infoParts[1],
                        age = infoParts[2],
                        hometown = infoParts[3]
                    };
                }
                else
                {
                    listOfStudents.Add(new Student()
                    {
                        firstName = infoParts[0],
                        lastName = infoParts[1],
                        age = infoParts[2],
                        hometown = infoParts[3]
                    });
                }
            }
                
            string town = Console.ReadLine();

            foreach (var item in listOfStudents)
            {
                if (item.hometown == town)
                {
                    Console.WriteLine($"{item.firstName} {item.lastName} is {item.age} years old.");
                }
            }
        }
    }

    class Student
    {
        
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string age { get; set; }
        public string hometown { get; set; }
    }
}
