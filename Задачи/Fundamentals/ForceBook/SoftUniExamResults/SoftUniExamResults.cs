using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniExamResults
{
    class SoftUniExamResults
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, Submission>();
            string command;

            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] commandParts = command.Split('-');
                string name = commandParts[0];
                string lenguage = commandParts[1];

                if (lenguage == "banned")
                {
                    people[name].Result = -1;
                }
                else
                {
                    int result = int.Parse(commandParts[2]);

                    if (!people.ContainsKey(name))
                    {
                        people[name] = new Submission(lenguage, result);
                    }
                    else
                    {
                        if (result > people[name].Result)
                        {
                            people[name].Result = result;
                        }

                        people[name].Lenguage.Add(lenguage);
                    }
                }
            }

            people = people
                      .OrderByDescending(i => i.Value.Result)
                      .ThenBy(i => i.Key)
                      .ToDictionary(i => i.Key, i => i.Value);

            var lenguages = new Dictionary<string, int>();
            Console.WriteLine("Results:");

            foreach (var man in people)
            {
                if (man.Value.Result > 0)
                {
                    Console.WriteLine($"{man.Key} | {man.Value.Result}");
                }

                foreach (var lenguage in man.Value.Lenguage)
                {
                    if (!lenguages.ContainsKey(lenguage))
                    {
                        lenguages[lenguage] = 0;
                    }

                    lenguages[lenguage]++;
                }
            }

            lenguages = lenguages.OrderByDescending(i => i.Value).ThenBy(i => i.Key).ToDictionary(i => i.Key, i => i.Value);
            Console.WriteLine("Submissions:");

            foreach (var item in lenguages)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }

    class Submission
    {
        public Submission(string lenguage, int result)
        {
            Lenguage = new List<string>();
            Lenguage.Add(lenguage);
            Result = result;
        }
        public List<string> Lenguage { get; set; }
        public int Result { get; set; }

    }
}
