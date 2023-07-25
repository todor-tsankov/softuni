using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualWords
{
    class EqualWords
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string word2 = Console.ReadLine();
            string small = word.ToLower();
            string small2 = word2.ToLower();

            if (small == small2)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
