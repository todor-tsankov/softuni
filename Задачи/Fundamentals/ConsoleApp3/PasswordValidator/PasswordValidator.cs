using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidator
{
    class PasswordValidator
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (passwordLengthChecker(password) && passwordOnlyLettersDigits(password) && passwordTwoDigits(password))
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!passwordLengthChecker(password))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if(!passwordOnlyLettersDigits(password))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!passwordTwoDigits(password))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }

        static bool passwordLengthChecker(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool passwordOnlyLettersDigits(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                int n = password[i];

                if ((n <= 47) || (n >= 58 && n <= 64) || (n >= 91 && n <= 96) || (n >= 123))
                {
                    return false;
                }
            }

            return true;
        }

        static bool passwordTwoDigits(string password)
        {
            int digitsCounter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                {
                    digitsCounter++;
                }
            }

            if (digitsCounter >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
