using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAcademy
{
    class StudentAcademy
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double currentGrade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students[name] = new List<double>();
                }

                students[name].Add(currentGrade);
            }

            var filteredStudents = students
                                    .Where(i => i.Value.Average() >= 4.50)
                                    .OrderByDescending(i => i.Value.Average())
                                    .ToDictionary(i => i.Key, i => i.Value);

            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
            }
        }
    }
}
