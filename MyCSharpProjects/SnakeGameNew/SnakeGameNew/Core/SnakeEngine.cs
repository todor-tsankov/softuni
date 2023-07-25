using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

using SnakeGame.IO;
using SnakeGame.Models;
using SnakeGame.Common;
using SnakeGame.IO.Contracts;
using SnakeGame.Core.Contracts;
using SnakeGame.Models.Contracts;

namespace SnakeGame.Core
{
    public class SnakeEngine : ISnakeEngine
    {
        private IPoint point;
        private IPoint bonusPoint;

        private ConsoleKey currentDirection;

        private bool bonusFirstCondition;
        private bool bonusSecondCondition;

        private int points;
        private int collectedPointsCount;

        private readonly char[,] field;
        private readonly string[] highscoreInfo;

        private readonly IList<IPoint> snake;
        private readonly IIOManager iOManager;
        private readonly IKeyInterpreter keyInterpreter;
        private readonly IRandomPointGenerator randomPointGenerator;


        private SnakeEngine()
        {
            this.collectedPointsCount = 1;
            this.bonusPoint = new Point(0, 0);
            this.currentDirection = ConsoleKey.RightArrow;

            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();
            var setter = new ConsoleSetter();

            this.iOManager = new IOManager(reader, writer, setter);
        }

        public SnakeEngine(IList<IPoint> snake, Random random, char[,] field, string[] highscoreInfo)
            : this()
        {
            CommonValidator.ValidateForNull(snake, nameof(snake));
            CommonValidator.ValidateForNull(field, nameof(field));
            CommonValidator.ValidateForNull(random, nameof(random));
            CommonValidator.ValidateForNull(highscoreInfo, nameof(highscoreInfo));

            this.snake = snake;
            this.field = field;
            this.highscoreInfo = highscoreInfo;

            this.keyInterpreter = new KeyInterpreter(this.snake);
            this.randomPointGenerator = new RandomPointGenerator(this.snake, random);

            this.point = this.randomPointGenerator.ProduceRandomPoint();
        }

        public void Run()
        {
            var difficulty = this.iOManager.StartScreen();
            this.iOManager.SetUpField(this.field, this.snake[0], this.point, this.points);

            var finalTime = DateTime.Now.AddMilliseconds(Constants.MillisecondsBonusWaitTime / difficulty);

            while (true)
            {
                finalTime = HandleBonus(finalTime, difficulty);

                this.iOManager.Setter.SetCursorPosition(Constants.MaxColIndex + 5, Constants.MaxRowIndex + 3);

                var keyTime = DateTime.Now.AddMilliseconds(Constants.MillisecondsWaitTime / difficulty);

                while (!Console.KeyAvailable && keyTime > DateTime.Now)
                {
                    Thread.Sleep(1);
                }

                var key = this.currentDirection;

                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey()
                                 .Key;
                }

                var firstSegment = this.snake.Last();

                var row = firstSegment.Row;
                var col = firstSegment.Col;

                var newFirstSegment = new Point(row, col);

                var gameOver = this.keyInterpreter.Execute(key, ref this.currentDirection, newFirstSegment);

                if (gameOver)
                {
                    break;
                }

                PrintMove(difficulty, newFirstSegment);
            }

            this.iOManager.EndScreen(this.highscoreInfo, this.points);
        }

        private DateTime HandleBonus(DateTime finalTime, int difficulty)
        {
            if (!this.bonusFirstCondition && !this.bonusSecondCondition && this.collectedPointsCount % 5 == 0)
            {
                this.bonusPoint = randomPointGenerator.ProduceRandomPoint();
                this.iOManager.PrintPoint(this.bonusPoint, Constants.BonusChar);

                finalTime = DateTime.Now.AddMilliseconds(Constants.MillisecondsBonusWaitTime / difficulty);

                this.bonusSecondCondition = true;
                this.bonusFirstCondition = true;
            }

            if (this.bonusFirstCondition && DateTime.Now > finalTime)
            {
                if (this.bonusPoint.Row != 0)
                {
                    this.iOManager.PrintPoint(this.bonusPoint, Constants.FieldInsideChar);
                }

                this.bonusPoint = new Point(0, 0);

                this.bonusFirstCondition = false;
            }

            return finalTime;
        }

        private void PrintMove(int difficulty, Point newFirstSegment)
        {
            this.iOManager.PrintPoint(newFirstSegment, Constants.SnakeChar);
            this.snake.Add(newFirstSegment);

            if (!(newFirstSegment.Row == this.point.Row && newFirstSegment.Col == this.point.Col))
            {
                this.iOManager.PrintPoint(this.snake[0], Constants.FieldInsideChar);
                this.snake.RemoveAt(0);

                if (newFirstSegment.Row == this.bonusPoint.Row && newFirstSegment.Col == this.bonusPoint.Col)
                {
                    this.points += difficulty * 10 + difficulty - 1;
                    this.bonusPoint = new Point(0, 0);
                }
            }
            else
            {
                this.point = this.randomPointGenerator.ProduceRandomPoint();
                this.iOManager.PrintPoint(this.point, Constants.PointChar);

                this.points += difficulty;
                this.bonusSecondCondition = false;
                this.collectedPointsCount++;
            }

            this.iOManager.PrintStats(this.points);
        }
    }
}
