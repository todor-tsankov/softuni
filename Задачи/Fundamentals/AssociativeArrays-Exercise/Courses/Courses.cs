using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    class Courses
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandParts = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string courseName = commandParts[0];
                string studentName = commandParts[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses[courseName] = new List<string>();
                }
                
                courses[courseName].Add(studentName);
            }

            courses = courses
                       .OrderByDescending(i => i.Value.Count)
                       .ToDictionary(i => i.Key, i => i.Value);

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                var orderredStudents = course.Value.OrderBy(i => i);

                foreach (var student in orderredStudents)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
