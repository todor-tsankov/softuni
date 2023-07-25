using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedConditionalStatements_Lab
{
    class PersonalTitles
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            char sex = char.Parse(Console.ReadLine());

            if (age >= 16)
            {
                switch (sex)
                {
                    case 'm':
                        Console.WriteLine("Mr.");
                        break;
                    case 'f':
                        Console.WriteLine("Ms.");
                        break;
                }
            }
            else
            {
                switch (sex)
                {
                   case 'm':
                        Console.WriteLine("Master");
                break;
                    case 'f':
                        Console.WriteLine("Miss");
                break;
                }
            }
        }
    }
}
