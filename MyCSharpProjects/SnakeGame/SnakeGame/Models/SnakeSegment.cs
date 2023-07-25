using SnakeGame.Models.Contracts;

namespace SnakeGame.Models
{
    public class SnakeSegment : ISnakeSegment
    {
        public SnakeSegment(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}
