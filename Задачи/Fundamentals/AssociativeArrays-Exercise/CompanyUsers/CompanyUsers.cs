using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyUsers
{
    class CompanyUsers
    {
        static void Main(string[] args)
        {
            var companies = new Dictionary<string, List<string>>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandParts = command.Split();
                string company = commandParts[0];
                string employeeId = commandParts[2];

                if (!companies.ContainsKey(company))
                {
                    companies[company] = new List<string>();
                }

                if (!companies[company].Contains(employeeId))
                {
                    companies[company].Add(employeeId);
                }
            }

            companies = companies
                         .OrderBy(i => i.Key)
                         .ToDictionary(i => i.Key, i => i.Value);

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);

                foreach (string item in company.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
