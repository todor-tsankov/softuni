using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendArrays
{
    class AppendArrays
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split('|').ToList();
            input.Reverse();
            List<string> finalList = string.Join(" ",input).Split().ToList();
            Console.WriteLine(string.Join(" ",finalList));
        }
    }
}
