using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatrePromotion
{
    class TheatrePromotion
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            string output = string.Empty;
            int age = int.Parse(Console.ReadLine());

            if (age >= 0 && age <= 18)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        output = "12$";
                        break;
                    case "Weekend":
                        output = "15$";
                        break;
                    case "Holiday":
                        output = "5$";
                        break;
                }
            }
            else if (age > 18 && age <= 64)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        output = "18$";
                        break;
                    case "Weekend":
                        output = "20$";
                        break;
                    case "Holiday":
                        output = "12$";
                        break;
                }
            }
            else if (age > 64 && age <= 122)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        output = "12$";
                        break;
                    case "Weekend":
                        output = "15$";
                        break;
                    case "Holiday":
                        output = "10$";
                        break;
                }
            }
            else
            {
                output = "Error!";
            }

            Console.WriteLine(output);
        }
    }
}
