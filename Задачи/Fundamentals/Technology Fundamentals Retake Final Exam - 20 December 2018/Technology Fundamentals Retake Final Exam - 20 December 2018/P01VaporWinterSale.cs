using System;
using System.Collections.Generic;
using System.Linq;

namespace Technology_Fundamentals_Retake_Final_Exam___20_December_2018
{
    class P01VaporWinterSale
    {
        static void Main()
        {
            Dictionary<string, Game> games = new Dictionary<string, Game>();

            string[] input = Console.ReadLine().Split(", ");

            for (int i = 0; i < input.Length; i++)
            {
                string currentGame = input[i];

                if (currentGame.Contains('-'))
                {
                    string[] cmdArgs = currentGame.Split("-");

                    string name = cmdArgs[0];
                    double price = double.Parse(cmdArgs[1]);

                    games.Add(name, new Game(price));
                }

            }

            for (int i = 0; i < input.Length; i++)
            {
                string currentGame = input[i];

                if (currentGame.Contains(':'))
                {
                    string[] cmdArgs = currentGame.Split(":");

                    string name = cmdArgs[0];
                    string dlc = cmdArgs[1];

                    if (games.ContainsKey(name))
                    {
                        games[name].Dlc = dlc;
                        games[name].Price *= 1.2;
                    }
                }
            }

            Dictionary<string, Game> gamesWithoutDlc = new Dictionary<string, Game>();
            Dictionary<string, Game> gamesDlc = new Dictionary<string, Game>();

            foreach (var game in games)
            {
                string name = game.Key;
                string dlc = game.Value.Dlc;

                double price = game.Value.Price;

                if (dlc == null)
                {
                    gamesWithoutDlc.Add(name, new Game(price * 0.8));
                }
                else
                {
                    gamesDlc.Add(name, new Game(price * 0.5, dlc));
                }
            }

            var sortedWithoutDlc = gamesWithoutDlc.OrderByDescending(i => i.Value.Price);
            var sortedDlc = gamesDlc.OrderBy(i => i.Value.Price);

            foreach (KeyValuePair<string, Game> item in sortedDlc)
            {
                Console.WriteLine($"{item.Key} - {item.Value.Dlc} - {item.Value.Price:f2}");
            }

            foreach (KeyValuePair<string, Game> item in sortedWithoutDlc)
            {
                Console.WriteLine($"{item.Key} - {item.Value.Price:f2}");
            }
        }
    }

    class Game
    {
        public Game(double price, string dlc = null)
        {
            Price = price;
            Dlc = dlc;
        }
        public double Price { get; set; }
        public string Dlc { get; set; }
    }
}
