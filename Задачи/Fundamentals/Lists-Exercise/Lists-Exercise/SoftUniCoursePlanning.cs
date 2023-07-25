using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists_Exercise
{
    class SoftUniCoursePlanning
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine().Split(", ").ToList();
            List<string> commandList = new List<string>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "course start")
            {
                commandList = command.Split(':').ToList();
                string operation = commandList[0];
                string lessonTitle = commandList[1];

                switch (operation)
                {
                    case "Add":
                        if (!schedule.Contains(lessonTitle))
                        {
                            schedule.Add(lessonTitle);
                        }
                        break;
                    case "Insert":
                        if (!schedule.Contains(lessonTitle))
                        {
                            schedule.Insert(int.Parse(commandList[2]),lessonTitle);
                        }
                        break;
                    case "Remove":
                        if (schedule.Contains(lessonTitle))
                        {
                            schedule.Remove(lessonTitle);
                        }
                        break;
                    case "Swap":
                        int index = schedule.IndexOf(lessonTitle);
                        int index2 = schedule.IndexOf(commandList[2]);
                        string exercise1 = $"{lessonTitle}-Exercise";
                        string exercise2 = $"{commandList[2]}-Exercise";

                        if (schedule.Contains(lessonTitle) && schedule.Contains(commandList[2]))
                        {
                            schedule[index] = commandList[2];
                            schedule[index2] = lessonTitle;
                        }

                        if (schedule.Contains(exercise1))
                        {
                            schedule.Remove(exercise1);
                            schedule.Insert(index2 + 1, exercise1);
                        }

                        if (schedule.Contains(exercise2))
                        {
                            schedule.Remove(exercise2);
                            schedule.Insert(index+ 1, exercise2);
                        }

                        break;
                    case "Exercise":
                        if (schedule.Contains(lessonTitle) && !schedule.Contains($"{lessonTitle}-Exercise"))
                        {
                            schedule.Insert(schedule.IndexOf(lessonTitle) + 1, $"{lessonTitle}-Exercise");
                        }
                        else if(!schedule.Contains($"{lessonTitle}-Exercise"))
                        {
                            schedule.Add(lessonTitle);
                            schedule.Add($"{lessonTitle}-Exercise");
                        }
                        break;
                }
            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }
    }
}
