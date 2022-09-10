using System;

namespace Vasko
{
    class P03
    {
        static void Main(string[] args)
        {
            // input strings
            string arr1 = "we";
            string arr2 = "we are the champions!";

            // create new variables to store the long and the shorter strings
            string longArr;
            string shortArr;

            // check which string is longer/shorter and assign it to the new variables
            if (arr1.Length > arr2.Length)
            {
                longArr = arr1;
                shortArr = arr2;
            }
            else
            {
                longArr = arr2;
                shortArr = arr1;
            }

            // counter will serve to iterate through the short string
            int index = 0;

            // this is where we will store the final result
            string newArr = "";

            // iterate through the long string
            for (int i = 0; i < longArr.Length; i++)
            {
                // if the counter reaches arrays length we set it to 0 (otherwise it will go outside the string)
                if (index == shortArr.Length)
                {
                    index = 0;
                }

                // add the char of the short array at "index" to the final result
                newArr += shortArr[index];
                index++;
            }

            // print the result
            Console.WriteLine(newArr);
        }
    }
}
