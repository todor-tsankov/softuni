using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFilter
{
    class WordFilter
    {
        static void Main(string[] args)
        {
            List<string> wordsList = Console.ReadLine().Split().ToList();
            List<string> filteredWordsList = wordsList.Where(i => i.Length % 2 == 0).ToList();
            filteredWordsList.ForEach(i => Console.WriteLine(i));
        }
    }
}
