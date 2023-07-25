using System;
using System.Text.RegularExpressions;

namespace P02
{
    class P02
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string validPasswordPattern = @"^(.+)>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<\1$";

                Match validPassword = Regex.Match(input, validPasswordPattern);

                if (validPassword.Success)
                {
                    string encryptedPassword = validPassword.Groups[2].Value +
                                               validPassword.Groups[3].Value +
                                               validPassword.Groups[4].Value +
                                               validPassword.Groups[5].Value;

                    Console.WriteLine($"Password: {encryptedPassword}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
