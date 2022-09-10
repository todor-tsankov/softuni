using System;
using System.Collections.Generic;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        private Dictionary<string, Student> repo = new Dictionary<string, Student>();

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            if (args[0] == "Create")
            {
                var name = args[1];
                var age = int.Parse(args[2]);
                var grade = double.Parse(args[3]);

                CreateStudent(name, age, grade);
            }
            else if (args[0] == "Show")
            {
                var name = args[1];

                ShowStudent(name);

            }
            else if (args[0] == "Exit")
            {
                Environment.Exit(0);
            }
        }

        private void CreateStudent(string name, int age, double grade)
        {
            if (!repo.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                repo[name] = student;
            }
        }

        private void ShowStudent(string name)
        {
            if (repo.ContainsKey(name))
            {
                var student = repo[name];

                Console.WriteLine(student.ToString());
            }
        }
    }

}