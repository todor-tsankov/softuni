using System;
using System.Collections.Generic;
using System.Linq;

namespace P02AverageStudentGrades
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                var studentAndGrade = Console.ReadLine()
                                             .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var student = studentAndGrade[0];
                var grade = decimal.Parse(studentAndGrade[1]);

                if (!students.ContainsKey(student))
                {
                    students[student] = new List<decimal>();
                }

                students[student].Add(grade);
            }

            foreach (var (studentName, gradeList) in students)
            {
                var grades = string.Join(" ", gradeList.Select(i => i.ToString("f2")));
                var average = gradeList.Average();

                Console.WriteLine($"{studentName} -> {grades} (avg: {average:f2})");
            }
        }
    }
}
