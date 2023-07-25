using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        { 
            int age;           
            age = Convert.ToInt32 ( Console.ReadLine ( ) );
            Console.WriteLine("Your age will be: {0}" , age + 10 );
        }
    }
}
