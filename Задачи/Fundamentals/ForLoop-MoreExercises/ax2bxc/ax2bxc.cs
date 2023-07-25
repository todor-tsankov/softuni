using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ax2bxc
{
    class ax2bxc
    {
        static void Main(string[] args)
        {
            string equation = Console.ReadLine();
            string a = string.Empty;
            string b = string.Empty;
            string c = string.Empty;
            int counterX = 0;

            for (int i = 0; i < equation.Length; i++)
            {
                char current = equation [i];

                switch (current)
                {
                    case '-':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case '0':
                    case '.':
                        if (counterX == 0)
                        {
                            a += current;
                        }
                        else if (counterX == 1)
                        {
                            b += current;
                        }
                        else
                        {
                            c += current;
                        }
                        break;
                    case 'x':
                        if (counterX == 0 && a == string.Empty)
                        {
                            a = "1";
                        }
                        else if (counterX == 1 && b == string.Empty)
                        {
                            b = "1";
                        }
                        else if (counterX == 0 && a == "-")
                        {
                            a = "-1";
                        }
                        else if (counterX == 1 && b == "-")
                        {
                            b = "-1";
                        }
                        counterX++;
                        break;
                }

            }

            double aNum = double.Parse(a);
            double bNum = double.Parse(b);
            double cNum = double.Parse(c);

            double D = Math.Pow(bNum, 2) - 4 * aNum * cNum;
            double x1 = 0;
            double x2 = 0;

            if (D < 0)
            {
                Console.WriteLine("The equation has NO roots");
            }
            else if (D == 0)
            {
                x1 = -bNum / (2 * aNum);
                Console.WriteLine("The equation has 1 root, x = " + x1);
            }
            else
            {
                x1 = (-bNum + Math.Sqrt(D)) / (2 * aNum);
                x2 = (-bNum - Math.Sqrt(D)) / (2 * aNum);

                Console.WriteLine("The equation has two roots, x1 = " + x1 + ", x2 = " + x2);

            }
        }
    }
}
