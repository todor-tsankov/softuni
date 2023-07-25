using System;

using SnakeGame.IO.Contracts;

namespace SnakeGame.IO
{
    public class ConsoleSetter : ISetter
    {
        public void SetCursorPosition(int col, int row)
        {
            Console.SetCursorPosition(col, row);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void SetCursor(bool visible)
        {
            Console.CursorVisible = visible;
        }
    }
}
