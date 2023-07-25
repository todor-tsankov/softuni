using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOperations_justforfun
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10] { 4, 1, 9, 8, 0, 2, 6, 3, 5, 7 };
        //  array = OrderAscending(array);
        //  array = OrderDescending(array);
        //  array = Reverse(array);

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        static int[] OrderAscending(int[] array)
        {
            bool finish = false;

            while (!finish)
            {
                finish = true;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    int firstNumber = array[i];

                    for (int j = i + 1; j < array.Length; j++)
                    {
                        int secondNumber = array[j];

                        if (secondNumber < firstNumber)
                        {
                            array[i] = secondNumber;
                            array[j] = firstNumber;
                            finish = false;
                            break;
                        }
                    }
                }
            }

            return array;
        }

        static int[] OrderDescending(int[] array)
        {
            bool finish = false;

            while (!finish)
            {
                finish = true;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    int firstNumber = array[i];

                    for (int j = i + 1; j < array.Length; j++)
                    {
                        int secondNumber = array[j];

                        if (secondNumber > firstNumber)
                        {
                            array[i] = secondNumber;
                            array[j] = firstNumber;
                            finish = false;
                            break;
                        }
                    }
                }
            }

            return array;
        }

        static int[] Reverse(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                int current = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = current;
            }

            return array;
        }
    }
}
    
