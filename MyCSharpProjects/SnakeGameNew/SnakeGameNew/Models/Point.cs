using SnakeGame.Common;
using SnakeGame.Models.Contracts;

namespace SnakeGame.Models
{
    public class Point : IPoint
    {
        private int row;
        private int col;

        public Point(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get
            {
                return this.row;
            }
            set
            {
                CommonValidator.ValidateRange(value, 0, Constants.MaxRowIndex, nameof(this.Row));

                this.row = value;
            }
        }

        public int Col 
        {
            get
            {
                return this.col;
            }
            set
            {
                CommonValidator.ValidateRange(value, 0, Constants.MaxColIndex, nameof(this.Col));

                this.col = value;
            }
        }
    }
}
