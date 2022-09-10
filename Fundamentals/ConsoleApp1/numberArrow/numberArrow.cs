using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1

{
    class Program
    {
        static void Main()
        {
            double number = 2;           
            for ( ; number < 101;  )
            { if ( number > 0 )
                {
                    Console.WriteLine ( number ) ;
                    number++;
                    number = number * ( -1 );
                }
            else if ( number < 0 )
                {
                    Console.WriteLine ( number );
                    number--;
                    number = number * ( -1 );
                }
                
            }
        }
    }
}
