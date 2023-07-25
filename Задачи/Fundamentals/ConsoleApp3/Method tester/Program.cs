using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_tester
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] manArray = { "1", "2", "3", "4", "5" };
            string[] command = { "exchange", "2" };

            int length = manArray.Length;
            int index = int.Parse(command[1]);

            if (index >= 0 && index < length)
            {
                for (int i = 0; i <= index; i++)
                {
                    string old = manArray[i + index];
                    manArray[i + index] = manArray[i];
                    manArray[length - i - 1] = old;

                }
            }
        }
    }
}
