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
            int n = int.Parse(Console.ReadLine());
            List<Student> listOfStudents = new List<Student>(n);

            for (int i = 0; i < n; i++)
            {
                string currentStudent = Console.ReadLine();
                listOfStudents.Add(new Student(currentStudent));
            }

            listOfStudents = listOfStudents.OrderByDescending(i => i.Grade).ToList();

            foreach (var item in listOfStudents)
            {
                item.Print();
            }
        }
    }

    class Student
    {
        public Student(string info)
        {
            string[] infoParts = info.Split();
            FirstName = infoParts[0];
            SecondName = infoParts[1];
            Grade = double.Parse(infoParts[2]);
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }

        public void Print()
        {
            Console.WriteLine($"{FirstName} {SecondName}: {Grade:f2}");
        }
    }
}
