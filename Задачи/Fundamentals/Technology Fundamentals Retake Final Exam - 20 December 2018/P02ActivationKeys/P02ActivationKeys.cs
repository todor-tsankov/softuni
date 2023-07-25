using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02ActivationKeys
{
    class P02ActivationKeys
    {
        static void Main(string[] args)
        {
            Regex validInputPattern = new Regex(@"[A-Za-z0-9]+");

            string[] inputs = Console.ReadLine()
                                     .Split('&', StringSplitOptions.RemoveEmptyEntries);

            List<string> outputs = new List<string>();

            foreach (var stringItem in inputs)
            {
                Match validStringMatch = validInputPattern.Match(stringItem);

                if (validStringMatch.Success)
                {
                    string match = validStringMatch.Value;
                    int length = match.Length;

                    List<char> newString = match.ToCharArray()
                                                    .ToList();

                    bool isValid = false;

                    if (length == 16)
                    {
                        newString.Insert(4, '-');
                        newString.Insert(9, '-');
                        newString.Insert(14, '-');

                        isValid = true;
                    }
                    else if (length == 25)
                    {
                        newString.Insert(5, '-');
                        newString.Insert(11, '-');
                        newString.Insert(17, '-');
                        newString.Insert(23, '-');

                        isValid = true;
                    }

                    if (isValid)
                    {
                        Subtact9(newString);

                        outputs.Add(new string(newString.ToArray()).ToUpper());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", outputs));
        }

        static void Subtact9(List<char> charList)
        {
            for (int i = 0; i < charList.Count; i++)
            {
                if (char.IsDigit(charList[i]))
                {
                    charList[i] = (9 - int.Parse(charList[i].ToString())).ToString()[0];
                }
            }
        }
    }
}
