using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksPlanner
{
    class TasksPlanner
    {
        static void Main(string[] args)
        {
            double[] taskArray = Console.ReadLine().Split().Select(double.Parse).ToArray();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandParts = command.Split();
                string operation = commandParts[0];

                if (operation == "Complete")
                {
                    int index = int.Parse(commandParts[1]);
                    Complete(taskArray, index);

                }
                else if (operation == "Change")
                {
                    int index = int.Parse(commandParts[1]);
                    double time = double.Parse(commandParts[2]);
                    Change(taskArray, index, time);

                }
                else if (operation == "Drop")
                {
                    int index = int.Parse(commandParts[1]);
                    Drop(taskArray, index);
                }
                else if (operation == "Count")
                {
                    string operationSecond = commandParts[1];

                    if (operationSecond == "Completed")
                    {
                        CountCompleted(taskArray);
                    }
                    else if (operationSecond == "Incomplete")
                    {
                        CountIncomplete(taskArray);
                    }
                    else if (operationSecond == "Dropped")
                    {
                        CountDropped(taskArray);
                    }
                }
                
            }

            foreach (var item in taskArray)
            {
                if (item > 0)
                {
                    Console.Write(item + " ");
                }
            }
        }

        static void Complete(double[] taskArray, int index)
        {
            if (index >= 0 && index < taskArray.Length)
            {
                taskArray[index] = 0;
            }
        }
        static void Change(double[] taskArray, int index, double time)
        {
            if (index >= 0 && index < taskArray.Length)
            {
                taskArray[index] = time;
            }
        }

        static void Drop(double[] taskArray, int index)
        {
            if (index >= 0 && index < taskArray.Length)
            {
                taskArray[index] = -1;
            }
        }

        static void CountCompleted(double[] taskArray)
        {
            int counter = 0;

            foreach (var item in taskArray)
            {
                if (item == 0)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
        static void CountIncomplete(double[] taskArray)
        {
            int counter = 0;

            foreach (var item in taskArray)
            {
                if (item > 0)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
        static void CountDropped(double[] taskArray)
        {
            int counter = 0;

            foreach (var item in taskArray)
            {
                if (item == -1)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
