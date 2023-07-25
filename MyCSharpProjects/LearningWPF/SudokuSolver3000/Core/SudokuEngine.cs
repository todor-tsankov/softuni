using System;

using SudokuSolver.Common;
using SudokuSolver.Core.Contracts;

namespace SudokuSolver.Core
{
    public class SudokuEngine : IEngine
    {
        private readonly Validator validator;
        private int[,] solvedMatrix;
        private bool hasBeenSolved;

        public SudokuEngine()
        {
            this.validator = new Validator();
        }

        public int[,] Matrix
        {
            get
            {
                return this.solvedMatrix;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException();
                }

                this.solvedMatrix = value;
            }
        }

        public void Solve(int[,] matrix, int row, int col)
        {
            if (row == Constants.MaxRow && col == Constants.MaxCol + 1)
            {
                this.solvedMatrix = matrix;
                this.hasBeenSolved = true;

                return;
            }

            if (this.hasBeenSolved)
            {
                return;
            }

            if (col == Constants.MaxCol + 1)
            {
                row++;

                col = Constants.MinCol;
            }

            if (matrix[row, col] != 0)
            {
                this.Solve(matrix, row, col + 1);

                return;
            }

            for (int i = Constants.MinAllowedDigit; i <= Constants.MaxAllowedDigit; i++)
            {
                if (this.validator.ValidateNumber(i, matrix, row, col) && !this.hasBeenSolved)
                {
                    var copyMatrix = this.CopyMatrix(matrix);
                    copyMatrix[row, col] = i;

                    this.Solve(copyMatrix, row, col + 1);
                }
            }
        }

        public int[,] CopyMatrix(int[,] matrix)
        {
            var newMatrix = new int[Constants.RowsCount, Constants.ColsCount];

            for (int row = Constants.MinRow; row <= Constants.MaxRow; row++)
            {
                for (int col = Constants.MinCol; col <= Constants.MaxCol; col++)
                {
                    newMatrix[row, col] = matrix[row, col];
                }
            }

            return newMatrix;
        }
    }
}
