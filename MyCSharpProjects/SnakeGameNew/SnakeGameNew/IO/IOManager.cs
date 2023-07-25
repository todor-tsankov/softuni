using System;
using System.IO;
using System.Text;
using System.Globalization;

using SnakeGame.Common;
using SnakeGame.IO.Contracts;
using SnakeGame.Models.Contracts;

namespace SnakeGame.IO
{
    public class IOManager : IIOManager
    {
        private IReader reader;
        private IWriter writer;
        private ISetter setter;

        public IOManager(IReader reader, IWriter writer, ISetter setter)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.Setter = setter;
        }

        public IReader Reader
        {
            get
            {
                return this.reader;
            }
            private set
            {
                CommonValidator.ValidateForNull(value, nameof(IReader));

                this.reader = value;
            }
        }

        public IWriter Writer
        {
            get
            {
                return this.writer;
            }
            private set
            {
                CommonValidator.ValidateForNull(value, nameof(IWriter));

                this.writer = value;
            }
        }

        public ISetter Setter
        {
            get
            {
                return this.setter;
            }
            private set
            {
                CommonValidator.ValidateForNull(value, nameof(ISetter));

                this.setter = value;
            }
        }

        public int StartScreen()
        {
            this.writer.WriteLine();
            this.writer.WriteLine();
            this.writer.WriteLine(Messages.GameDescription);
            this.writer.WriteLine();
            this.writer.WriteLine(Messages.PoweredBy);
            this.writer.WriteLine();
            this.writer.WriteLine();
            this.writer.WriteLine(Messages.Controls);
            this.writer.WriteLine();
            this.writer.Write(Messages.ChooseDifficulty);

            var difficulty = 1;

            while (true)
            {
                try
                {
                    
                    difficulty = int.Parse(this.reader.ReadLine(), CultureInfo.InvariantCulture);

                    if (difficulty <= 0 || difficulty > 10)
                    {
                        throw new FormatException();
                    }

                    break;
                }
                catch (FormatException)
                {
                    this.writer.WriteLine();
                    this.writer.Write($"  {ExceptionMessages.InvalidDifficulty}, please try again: ");
                }
            }

            this.setter.SetCursor(false);

            this.writer.WriteLine();
            this.writer.WriteLine();
            this.writer.WriteLine(Messages.PressAnyKeyToStart);

            this.reader.ReadKey();
            this.setter.Clear();

            return difficulty;
        }

        public void SetUpField(char[,] field, IPoint snakeInitialPoint, IPoint initialScorePoint, int points)
        {
            this.setter.SetCursor(false);

            PrintField(field);
            PrintPoint(snakeInitialPoint, Constants.SnakeChar);
            PrintPoint(initialScorePoint, Constants.PointChar);

            PrintStats(points);
        }

        public void PrintField(char[,] field)
        {
            CommonValidator.ValidateForNull(field, nameof(field));

            for (int row = 0; row < Constants.PlayableRowsCount + 2; row++)
            {
                for (int col = 0; col < Constants.PlayableColsCount + 2; col++)
                {
                    this.writer.Write(field[row, col]);
                }

                this.writer.WriteLine();
            }
        }

        public void PrintPoint(IPoint point, char ch)
        {
            CommonValidator.ValidateForNull(point, nameof(point));

            this.setter.SetCursorPosition(point.Col, point.Row);
            this.writer.Write(ch);
        }

        public void PrintStats(int points)
        {
            this.setter.SetCursorPosition(Constants.MinColIndex, Constants.PlayableRowsCount + 3);
            this.writer.WriteLine($"Current points: {points}");
        }

        public void EndScreen(string[] oldHighscoreArgs, int currentPoints)
        {
            CommonValidator.ValidateForNull(oldHighscoreArgs, nameof(oldHighscoreArgs));

            this.setter.SetCursorPosition(0, Constants.MaxRowIndex + 5);

            var oldHighscorePoints = int.Parse(oldHighscoreArgs[2], CultureInfo.InvariantCulture);
            var sb = new StringBuilder();

            if (currentPoints > oldHighscorePoints)
            {
                this.setter.SetCursor(true);
                this.writer.Write(Messages.NewHighscore);

                var name = this.reader.ReadLine();
                var dateStr = DateTime.Now.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);

                var str = $"{name} {dateStr} {currentPoints}";

                File.WriteAllText(Constants.HighscoreFilePath, str);
            }
            else
            {
                this.writer.WriteLine(Messages.GameOver);
                this.writer.WriteLine();
                this.writer.WriteLine($"   HighScore ->  Name: {oldHighscoreArgs[0]}, Date: {oldHighscoreArgs[1]}, Points {oldHighscoreArgs[2]}");
                this.writer.WriteLine();
                this.writer.WriteLine();
                this.writer.WriteLine(Messages.PressEscapeToExit);

                this.setter.SetCursor(false);

                while (true)
                {
                    var key = this.reader.ReadKey().Key;

                    if (key == ConsoleKey.Escape)
                    {
                        break;
                    }
                }
            }
        }
    }
}
