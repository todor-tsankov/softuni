using System;
using System.Threading;
using System.IO;

namespace SimpleGame
{
    class Program
    {
        private static PlayerArea playerArea = new PlayerArea();

        private static int totalPoints = 0;
        private static int lineIndex = -1;
        public static int playerIndex = 0;

        private static int index;
        private static char ch;
        private static bool gameFinsished = false;
        private static int speedCounter = 500;
        private static int scoreBonusPoints = 1;

        private static string dataFile = "data.txt";
        private static string content = "0";

        private static string highscoreName = "HighscoreName.txt";
        private static string contentHighscoreName = "";

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            content = File.ReadAllText(dataFile);
            int highScore = int.Parse(content);

            Console.WriteLine();
            Console.WriteLine(" LETTER FISHING");
            Console.WriteLine();
            Console.WriteLine(" Controls: Move Left: (leftArrow)  Move Right: (rightArrow) ");
            Console.WriteLine();
            Console.WriteLine(" More letters == more points, Z > A");
            Console.WriteLine();
            Console.WriteLine(" Press any key to start!");
            Console.ReadKey();
            Console.Clear();

            while (!gameFinsished)
            {
                DateTime timoutValue = DateTime.Now.AddMilliseconds(speedCounter);
                ConsoleKey currentKey = ConsoleKey.DownArrow;

                HighScoreHandler(highScore);

                PrintScreen(highScore);

                if (gameFinsished)
                {
                    break;
                }

                while (DateTime.Now < timoutValue)
                {
                    if (Console.KeyAvailable)
                    {
                        currentKey = Console.ReadKey().Key;
                    }
                }


                PlayerController(currentKey);

                Console.Clear();
            }
        }

        private static void HighScoreHandler(int highScore)
        {
            content = File.ReadAllText(dataFile);
            highScore = int.Parse(content);

            contentHighscoreName = File.ReadAllText(highscoreName);

            if (highScore < totalPoints)
            {
                File.WriteAllText(dataFile, totalPoints.ToString());
                File.WriteAllText(highscoreName, "New Highscore!");
            }
        }

        private static void PrintScreen(int highscore)
        {

            Console.WriteLine($"  Current points: {totalPoints}  // Highscore: {contentHighscoreName} {content} points");
            PrintUpperPart(highscore);

            Console.WriteLine(playerArea.PlayerAndArea);
        }

        private static void PrintUpperPart(int highscore)
        {
            if (lineIndex == 9)
            {
                if (index == playerIndex)
                {
                    totalPoints += ch + scoreBonusPoints;
                    lineIndex = 0;

                    scoreBonusPoints *= 2;
                    speedCounter -= 50;
                }
                else
                {
                    string gameOver = " GAME OVER!!!!";

                    Console.WriteLine();
                    Console.WriteLine(gameOver);
                    Console.WriteLine();

                    if (totalPoints > highscore)
                    {
                        Console.WriteLine(" Congratulations new highscore!");
                        Console.Write(" Please enter your Name:  ");
                        string newName = Console.ReadLine();

                        File.WriteAllText(highscoreName, newName);
                    }
                    else
                    {
                        Console.WriteLine(" Good Try :)");
                        Console.WriteLine();
                        Console.WriteLine(" Press any key to exit");
                        Console.ReadKey();
                    }

                    gameFinsished = true;
                    return;
                }

            }
            else
            {
                lineIndex++;
            }

            if (lineIndex == 0)
            {
                ch = CharGenerator();
                index = IndexGenerator();
            }

            for (int i = 0; i < 10; i++)
            {
                string outputLine = string.Empty;

                if (i == lineIndex)
                {
                    outputLine = new string(' ', index) + ch;
                }
                else
                {
                    outputLine = Environment.NewLine;
                }

                Random leftOrRight = new Random();

                int randomLeftRight = leftOrRight.Next(0, 2);

                outputLine = RandomMovementLeftOrRight(outputLine, randomLeftRight);

                Console.WriteLine(outputLine);
            }

        }

        private static string RandomMovementLeftOrRight(string outputLine, int randomLeftRight)
        {
            if (lineIndex < 9)
            {
                if (randomLeftRight == 1)
                {
                    outputLine = " " + outputLine;
                }
                else if (randomLeftRight == 2)
                {
                    outputLine = outputLine.Substring(1, outputLine.Length - 1);
                }
            }

            return outputLine;
        }

        private static void PlayerController(ConsoleKey currentKey)
        {
            if (currentKey == ConsoleKey.LeftArrow)
            {
                playerArea.MoveLeft();
                playerIndex--;
            }
            else if (currentKey == ConsoleKey.RightArrow)
            {
                playerArea.MoveRight();
                playerIndex++;
            }
        }

        private static char CharGenerator()
        {
            Random charGenerator = new Random();

            char randomChar = (char)charGenerator.Next(65, 90);

            return randomChar;
        }

        private static int IndexGenerator()
        {
            Random indexGenerator = new Random();

            int randomIndex = indexGenerator.Next(0, 10);

            return randomIndex;
        }
    }
}
