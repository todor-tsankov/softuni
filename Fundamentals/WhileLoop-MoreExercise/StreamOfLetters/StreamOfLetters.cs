using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamOfLetters
{
    class StreamOfLetters
    {
        static void Main()
        {
            string currentLetter = string.Empty;
            string firstWord = string.Empty;
            string secondWord = string.Empty;
            int counterC = 1;
            int counterN = 1;
            int counterO = 1;
            int counterC2 = 0;
            int counterN2 = 0;
            int counterO2 = 0;
            bool firstWordTest = false;


            while (currentLetter != "End")
            {
                currentLetter = Console.ReadLine();

                if (currentLetter == "End")  // OK
                {
                    break;
                }


                if (currentLetter == "A" || currentLetter == "a" || currentLetter == "B" || currentLetter == "b" || currentLetter == "C" || currentLetter == "c" || currentLetter == "D" || currentLetter == "d" || currentLetter == "E" || currentLetter == "e" || currentLetter == "F" || currentLetter == "f" || currentLetter == "G" || currentLetter == "g" || currentLetter == "H" || currentLetter == "h" || currentLetter == "I" || currentLetter == "i" || currentLetter == "J" || currentLetter == "j" || currentLetter == "K" || currentLetter == "k" || currentLetter == "L" || currentLetter == "l" || currentLetter == "M" || currentLetter == "m" || currentLetter == "N" || currentLetter == "n" || currentLetter == "O" || currentLetter == "o" || currentLetter == "P" || currentLetter == "p" || currentLetter == "Q" || currentLetter == "q" || currentLetter == "R" || currentLetter == "r" || currentLetter == "S" || currentLetter == "s" || currentLetter == "T" || currentLetter == "t" || currentLetter == "U" || currentLetter == "u" || currentLetter == "V" || currentLetter == "v" || currentLetter == "W" || currentLetter == "w" || currentLetter == "X" || currentLetter == "x" || currentLetter == "Y" || currentLetter == "y" || currentLetter == "Z" || currentLetter == "z")
                {

                }
                else
                {
                    continue;
                }

                
                if (currentLetter == "C" || currentLetter == "c")
                {
                    if (counterC == 1 || counterC2 == 1)
                    {
                        counterC++;
                        continue;
                    }

                }
                if (currentLetter == "O" || currentLetter == "o")
                {
                    if (counterO == 1 || counterO2 == 1)
                    {
                        counterO++;
                        continue;
                    }
                }
                if (currentLetter == "N" || currentLetter == "n")
                {
                    if (counterN == 1 || counterN2 == 1)
                    {
                        counterN++;
                        continue;
                    }

                }
                if (counterC + counterN + counterO == 6)
                {
                    counterC2 = 1;
                    counterN2 = 1;
                    counterO2 = 1;
                    firstWordTest = true;
                }

                if (counterC + counterN + counterO < 6)     // OK
                {
                    firstWord += currentLetter;

                }

                else if (counterC + counterN + counterO > 6 && counterC + counterN + counterO < 9)
                {
                    secondWord += currentLetter;

                }

                if (firstWordTest)
                {
                    Console.Write($"{firstWord} ");
                }
                if (counterC2 + counterN2 + counterO2 == 6)
                {
                    Console.Write($"{secondWord} ");
                }


            }



            
        }
    }
}

