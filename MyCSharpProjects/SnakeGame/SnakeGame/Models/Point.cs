using SnakeGame.Models.Contracts;

namespace SnakeGame.Models
{
    public class Point : IPoint
    {
        public Point(int row , int col)
        {
            this.Row = row;
            this.Col = col;
        }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
