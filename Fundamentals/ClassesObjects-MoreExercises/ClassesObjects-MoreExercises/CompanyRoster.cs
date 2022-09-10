using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesObjects_MoreExercises
{
    class CompanyRoster
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> listWorkers = new List<Employee>();
            List<Department> departments = new List<Department>();
            double bestSalary = 0;

            for (int i = 0; i < n; i++)
            {
                string workerInfo = Console.ReadLine();
                string currentDepartment = workerInfo.Split()[2];
                listWorkers.Add(new Employee(workerInfo));
                int index = departments.FindIndex(j => j.Name == currentDepartment);

                if (index < 0)
                {
                    departments.Add(new Department(currentDepartment));
                }
            }

            foreach (var department in departments)
            { 
                double counter = 0;

                foreach (var worker in listWorkers)
                {
                    if (worker.Department == department.Name)
                    {
                        department.salary += worker.Salary;
                        counter++;
                    }
                }
                department.salary /= counter;
            }

            departments = departments.OrderByDescending(i => i.salary).ToList();
            listWorkers = listWorkers.OrderByDescending(i => i.Salary).ToList();
            Console.WriteLine($"Highest Average Salary: {departments[0].Name}");

            foreach (var item in listWorkers)
            {
                if (item.Department == departments[0].Name)
                {
                    Console.WriteLine($"{item.Name} {item.Salary:f2}");
                }
            }
        }



    }

    class Employee
    {
        public Employee(string info)
        {
            string[] infoParts = info.Split();
            Name = infoParts[0];
            Salary = double.Parse(infoParts[1]);
            Department = infoParts[2];
        }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }

    class Department
    {
        public Department(string name)
        {
            Name = name;
        }
        public double salary { get; set; }
        public string Name { get; set; }
    }
}
