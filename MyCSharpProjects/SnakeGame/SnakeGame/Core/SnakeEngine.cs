using System;
using System.Linq;
using System.Timers;
using System.Threading;
using System.Collections.Generic;

using SnakeGame.Common;
using SnakeGame.Models;
using SnakeGame.Core.Contracts;
using SnakeGame.Models.Contracts;

namespace SnakeGame.Core
{
    public class SnakeEngine : ISnakeEngine
    {

        private IPoint point;
        private int points = 0;

        private readonly char[,] field;
        private readonly IList<ISnakeSegment> snake;

        private readonly RandomPointGenerator randomPointGenerator;
        private ConsoleKey currentDirection = ConsoleKey.RightArrow;

        private readonly SnakePrinter snakePrinter;
        private readonly string[] highscoreInfo;

        public SnakeEngine(char[,] initialField, IList<ISnakeSegment> initialSnake, Random random, string[] highscoreInfo)
        {
            this.field = initialField;
            this.snake = initialSnake;

            this.randomPointGenerator = new RandomPointGenerator(this.snake, random);

            this.point = this.randomPointGenerator.ProduceRandomPoint();
            this.snakePrinter = new SnakePrinter();

            this.highscoreInfo = highscoreInfo;
        }

        public void Run()
        {
            var difficulty = this.snakePrinter.PrintInitialInfoScreen();

            SetUpField();

            while (true)
            {
                Console.SetCursorPosition(Constants.MAX_COL_INDEX + 5, Constants.MAX_ROW_INDEX + 3);

                var lastTime = DateTime.Now.AddMilliseconds(Constants.MILLISECONDS_WAIT / difficulty);

                while (!Console.KeyAvailable && lastTime > DateTime.Now)
                {
                    Thread.Sleep(1);
                }

                var key = this.currentDirection;

                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey()
                                 .Key;
                }

                if ((key == ConsoleKey.UpArrow && this.currentDirection == ConsoleKey.DownArrow)
                 || (key == ConsoleKey.DownArrow && this.currentDirection == ConsoleKey.UpArrow)
                 || (key == ConsoleKey.LeftArrow && this.currentDirection == ConsoleKey.RightArrow)
                 || (key == ConsoleKey.RightArrow && this.currentDirection == ConsoleKey.LeftArrow))
                {
                    key = this.currentDirection;
                }

                var firstSegment = this.snake.Last();

                var firstRow = firstSegment.Row;
                var firstCol = firstSegment.Col;


                var sucess = MoveCoordinates(key, ref firstRow, ref firstCol);

                if (!sucess || this.snake.Any(s => s.Row == firstRow && s.Col == firstCol && s != firstSegment))
                {
                    break;
                }

                var newSegment = new SnakeSegment(firstRow, firstCol);

                this.snakePrinter.PrintSegment(newSegment);
                this.snake.Add(newSegment);

                this.currentDirection = key;

                if (!(firstRow == this.point.Row && firstCol == this.point.Col))
                {
                    this.snakePrinter.EraseSegment(this.snake[0]);
                    this.snake.RemoveAt(0);
                }
                else
                {
                    this.point = this.randomPointGenerator.ProduceRandomPoint();

                    this.snakePrinter.PrintPoint(this.point);
                    this.points += difficulty;
                }

                this.snakePrinter.PrintStats(this.points);
            }

            var highscore = int.Parse(this.highscoreInfo[2]);

            var newHighscore = false;

            if (this.points > highscore)
            {
                newHighscore = true;
            }

            this.snakePrinter.PrintEndResult(this.highscoreInfo, newHighscore, this.points);
        }


        private void SetUpField()
        {
            Console.CursorVisible = false;

            this.snakePrinter.PrintInititalField(this.field);
            this.snakePrinter.PrintSegment(this.snake[0]);

            this.snakePrinter.PrintPoint(this.point);
            this.snakePrinter.PrintStats(this.points);
        }

       

        private bool MoveCoordinates(ConsoleKey key, ref int firstRow, ref int firstCol)
        {
            if (key == ConsoleKey.UpArrow)
            {
                if (firstRow - 1 >= Constants.MIN_ROW_INDEX)
                {
                    firstRow--;
                }
                else
                {
                    firstRow = Constants.MAX_ROW_INDEX;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (firstRow + 1 <= Constants.MAX_ROW_INDEX)
                {
                    firstRow++;
                }
                else
                {
                    firstRow = Constants.MIN_ROW_INDEX;
                }
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                if (firstCol - 1 >= Constants.MIN_COL_INDEX)
                {
                    firstCol--;
                }
                else
                {
                    firstCol = Constants.MAX_COL_INDEX;
                }
            }
            else if (key == ConsoleKey.RightArrow)
            {
                if (firstCol + 1 <= Constants.MAX_COL_INDEX)
                {
                    firstCol++;
                }
                else
                {
                    firstCol = Constants.MIN_COL_INDEX;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
