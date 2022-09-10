using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesObjects_Exercise
{
    class AdvertismentMessage
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Random rnd = new Random();

            string[] phrases = new string[] { "Excellent product.",
                                              "Such a great product.",
                                              "I always use that product.",
                                              "Best product of its category.",
                                              "Exceptional product.",
                                              "I can’t live without this product."};

            string[] events = new string[] { "Now I feel good.", 
                                             "I have succeeded with this product.", 
                                             "Makes miracles. I am happy of the results!", 
                                             "I cannot believe but now I feel awesome.", 
                                             "Try it yourself, I am very satisfied.", 
                                             "I feel great!"};

            string[] authors = new string[] { "Diana", 
                                              "Petya", 
                                              "Stella", 
                                              "Elena", 
                                              "Katya", 
                                              "Iva", 
                                              "Annie", 
                                              "Eva" };

            string[] cities = new string[] { "Burgas", 
                                             "Sofia",
                                             "Plovdiv", 
                                              "Varna", 
                                              "Ruse" };

            for (int i = 0; i < n; i++)
            {
                Console.Write(phrases[rnd.Next(0,6)] + " ");
                Console.Write(events[rnd.Next(0,6)] + " ");
                Console.Write(authors[rnd.Next(0,8)] + " - ");
                Console.Write(cities[rnd.Next(0,5)]);
                Console.WriteLine();
            }
        }
    }
}
