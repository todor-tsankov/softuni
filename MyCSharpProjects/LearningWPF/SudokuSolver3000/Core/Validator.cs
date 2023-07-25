using SudokuSolver.Common;

namespace SudokuSolver.Core
{
    public class Validator
    {
        public bool ValidateMatrix(int[,] matrix)
        {
            if (matrix == null)
            {
                return false;
            }

            for (int row = 0; row <= Constants.MaxRow; row++)
            {
                for (int col = 0; col < Constants.MaxCol; col++)
                {
                    var number = matrix[row, col];

                    if (number == 0)
                    {
                        continue;
                    }

                    var success = this.ValidateNumber(number, matrix, row, col);

                    if (!success)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool ValidateNumber(int number, int[,] matrix, int row, int col)
        {
            return this.ValidateHorizontal(number, matrix, row, col)
                && this.ValidateVertical(number, matrix, row, col)
                && this.ValidateSquare(number, matrix, row, col);
        }

        private bool ValidateHorizontal(int number, int[,] matrix, int row, int col)
        {
            for (int i = Constants.MinCol; i <= Constants.MaxCol; i++)
            {
                if (i != col && matrix[row, i] == number)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateVertical(int number, int[,] matrix, int row, int col)
        {
            for (int i = Constants.MinRow; i <= Constants.MaxRow; i++)
            {
                if (i != row && matrix[i, col] == number)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateSquare(int number, int[,] matrix, int row, int col)
        {
            var startRow = this.FindStartIndex(row);
            var startCol = this.FindStartIndex(col);

            for (int cRow = startRow; cRow < startRow + 3; cRow++)
            {
                for (int cCol = startCol; cCol < startCol + 3; cCol++)
                {
                    if ((cRow != row || cCol != col) && matrix[cRow, cCol] == number)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private int FindStartIndex(int num)
        {
            if (num <= 2)
            {
                num = 0;
            }
            else if (num <= 5)
            {
                num = 3;
            }
            else if (num <= 8)
            {
                num = 6;
            }

            return num;
        }
    }
}
