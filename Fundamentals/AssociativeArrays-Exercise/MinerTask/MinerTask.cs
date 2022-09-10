using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerTask
{
    class MinerTask
    {
        static void Main(string[] args)
        {
            var resources = new Dictionary<string, int>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(command))
                {
                    resources[command] = 0;
                }

                resources[command] += quantity;
            }

            foreach (var rsrc in resources)
            {
                Console.WriteLine(rsrc.Key + " -> " + rsrc.Value);
            }
        }
    }
}
