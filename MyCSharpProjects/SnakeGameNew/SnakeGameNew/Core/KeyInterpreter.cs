using System;
using System.Linq;
using System.Collections.Generic;

using SnakeGame.Common;
using SnakeGame.Models.Contracts;

namespace SnakeGame.Core.Contracts
{
    public class KeyInterpreter : IKeyInterpreter
    {
        readonly IList<IPoint> snake;

        public KeyInterpreter(IList<IPoint> snake)
        {
            this.snake = snake;
        }

        public bool Execute(ConsoleKey key, ref ConsoleKey currentDirection,  IPoint firstSegment)
        {
            CommonValidator.ValidateForNull(firstSegment, nameof(firstSegment));

            if ((key == ConsoleKey.UpArrow && currentDirection == ConsoleKey.DownArrow)
                 || (key == ConsoleKey.DownArrow && currentDirection == ConsoleKey.UpArrow)
                 || (key == ConsoleKey.LeftArrow && currentDirection == ConsoleKey.RightArrow)
                 || (key == ConsoleKey.RightArrow && currentDirection == ConsoleKey.LeftArrow))
            {
                key = currentDirection;
            }

            var sucess = MoveCoordinates(key, firstSegment);

            if (!sucess || this.snake.Any(s => s.Row == firstSegment.Row && s.Col == firstSegment.Col && s != firstSegment))
            {
                return true;
            }

            currentDirection = key;

            return false;
        }

        private bool MoveCoordinates(ConsoleKey key, IPoint firstSegment)
        {
            if (key == ConsoleKey.UpArrow)
            {
                if (firstSegment.Row - 1 >= Constants.MinRowIndex)
                {
                    firstSegment.Row--;
                }
                else
                {
                    firstSegment.Row = Constants.MaxRowIndex;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (firstSegment.Row + 1 <= Constants.MaxRowIndex)
                {
                    firstSegment.Row++;
                }
                else
                {
                    firstSegment.Row = Constants.MinRowIndex;
                }
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                if (firstSegment.Col - 1 >= Constants.MinColIndex)
                {
                    firstSegment.Col--;
                }
                else
                {
                    firstSegment.Col = Constants.MaxColIndex;
                }
            }
            else if (key == ConsoleKey.RightArrow)
            {
                if (firstSegment.Col + 1 <= Constants.MaxColIndex)
                {
                    firstSegment.Col++;
                }
                else
                {
                    firstSegment.Col = Constants.MinColIndex;
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
