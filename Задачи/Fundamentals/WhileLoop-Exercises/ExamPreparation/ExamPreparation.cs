using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation
{
    class ExamPreparation
    {
        static void Main(string[] args)
        {
            int numberOfBadGrades = int.Parse(Console.ReadLine());
            int count = 0;
            int badGradesCounter = 0;
            int grade = 0;
            string exerciseName = "";
            bool enoughCheck = false;
            bool poorGradesCheck = false;
            double average = 0;
            string lastExercise = "";

            while (true)
            {
                
                exerciseName = Console.ReadLine();
                if (exerciseName == "Enough")
                {
                    enoughCheck = true;
                    break;
                }

                lastExercise = exerciseName;
                grade = int.Parse(Console.ReadLine());
                average += grade;
                count++;

                if (grade <= 4.00)
                {
                    badGradesCounter++;


                    if (badGradesCounter == numberOfBadGrades)
                    {
                        poorGradesCheck = true;
                        break;
                    }
                    continue;

                }

               

            }
            average /= count;

            if (enoughCheck)
            {
                Console.WriteLine($"Average score: {average:f2}");
                Console.WriteLine($"Number of problems: {count}");
                Console.WriteLine($"Last problem: {lastExercise}");
            }
            else if (poorGradesCheck)
            {
                Console.WriteLine($"You need a break, {numberOfBadGrades} poor grades.");
            }
        }
    }
}
