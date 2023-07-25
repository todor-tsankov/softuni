using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secondChapter
{
    class variables
    {
        static void Main(string[] args)
        {
            byte centuries = 20;
            ushort years = 2000;
            uint days = 730480;
            ulong hours = 17531520;

            Console.WriteLine(centuries + " centuries are " + years + " years , or " + days + " days, or " + hours + " hours " );

            ulong MaxIntValue = UInt64.MaxValue;
            Console.WriteLine(MaxIntValue);



        }
    }
}
