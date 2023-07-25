using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileLoop_Exercises
{
    class OldBooks
    {
        static void Main(string[] args)
        {
            string bookName = Console.ReadLine();
            string currentBook = "";
            int numBooks = int.Parse(Console.ReadLine());
            int count = 0;
            bool found = false;
            bool notFound = true;

            while (count < numBooks)
            {
                currentBook = Console.ReadLine();
                

                if (bookName == currentBook)
                {
                    found = true;
                    notFound = false;
                    break;
                }

                count++;

            }

            if (found)
            {
                Console.WriteLine($"You checked {count} books and found it.");
            }
            else if (notFound)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {count} books.");
            }
        }
    }
}
