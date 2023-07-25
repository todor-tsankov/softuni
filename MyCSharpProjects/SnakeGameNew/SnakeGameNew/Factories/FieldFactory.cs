using SnakeGame.Common;
using SnakeGame.Factories.Contracts;

namespace SnakeGame.Factories
{
    public class FieldFactory : IFieldFactory
    {
        public char[,] ProduceField()
        {
            var field = new char[Constants.PlayableRowsCount + 2, Constants.PlayableColsCount + 2];

            for (int row = 0; row < Constants.PlayableRowsCount + 2; row++)
            {
                var firstLast = Constants.FieldSidesChar;
                var middle = Constants.FieldInsideChar;

                if (row == 0 || row == Constants.PlayableRowsCount + 1)
                {
                    firstLast = Constants.FieldEdgesChar;
                    middle = Constants.FieldFloorsChar;
                }

                for (int col = 0; col < Constants.PlayableColsCount + 2; col++)
                {
                    if (col == 0 || col == Constants.PlayableColsCount + 1)
                    {
                        field[row, col] = firstLast;
                    }
                    else
                    {
                        field[row, col] = middle;
                    }
                }
            }

            return field;
        }
    }
}
