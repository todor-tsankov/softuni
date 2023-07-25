using System;

namespace SudokuSolver
{
    public class Sudoku
    {
        private const byte BOARD_SIZE = 9;
        private const string DEFAULT_SEPARATOR = " ";

        private byte[,] solvedBoard;

        public Sudoku()
        {
            this.solvedBoard = new byte[BOARD_SIZE, BOARD_SIZE];
        }

        public byte[,] ReadBoard()
        {
            var currentBoard = new byte[BOARD_SIZE, BOARD_SIZE];

            for (int row = 0; row < BOARD_SIZE; row++)
            {
                var currentRow = Console.ReadLine()
                                        .Split(DEFAULT_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < BOARD_SIZE; col++)
                {
                    currentBoard[row, col] = byte.Parse(currentRow[col]);
                }
            }

            return currentBoard;
        }
        public void Solve(byte[,] board, byte currentRow = 0, byte currentCol = 0)
        {
            if (currentCol == BOARD_SIZE)
            {
                currentRow++;
                currentCol = 0;
            }

            if (currentRow == BOARD_SIZE)
            {
                this.solvedBoard = board;

                return;
            }

            var currentNumber = board[currentRow, currentCol];

            if (currentNumber == 0)
            {
                for (byte n = 1; n <= 9; n++)
                {
                    if (Check(n, board, currentRow, currentCol))
                    {
                        var newBoard = CopyBoard(board);
                        newBoard[currentRow, currentCol] = n;

                        this.Solve(newBoard, currentRow, (byte)(currentCol + 1));
                    }
                }
            }
            else
            {
                this.Solve(board, currentRow, (byte)(currentCol + 1));
            }
        }
        public void PrintBoard()
        {
            Console.WriteLine();

            for (int row = 0; row < BOARD_SIZE; row++)
            {
                for (int col = 0; col < BOARD_SIZE; col++)
                {
                    var currentNumber = this.solvedBoard[row, col];

                    Console.Write(currentNumber + DEFAULT_SEPARATOR);
                }

                Console.WriteLine();
            }
        }

        private bool Check(byte number, byte[,] board, byte currentRow, byte currentCol)
        {
            return CheckRow(number, board, currentRow) 
                && CheckCol(number, board, currentCol) 
                && CheckSquare(number, board, currentRow, currentCol);
        }
        private bool CheckRow(byte number, byte[,] board, byte currentRow)
        {
            for (byte col = 0; col < BOARD_SIZE; col++)
            {
                var currentNumber = board[currentRow, col];

                if (currentNumber == number)
                {
                    return false;
                }
            }

            return true;
        }
        private bool CheckCol(byte number, byte[,] board, byte currentCol)
        {
            for (byte row = 0; row < BOARD_SIZE; row++)
            {
                var currentNumber = board[row, currentCol];

                if (currentNumber == number)
                {
                    return false;
                }
            }

            return true;
        }
        private bool CheckSquare(byte number, byte[,] board, byte currentRow, byte currentCol)
        {
            var startRow = this.GetIndex(currentRow);
            var startCol = this.GetIndex(currentCol);

            for (byte row = startRow; row < startRow + 3; row++)
            {
                for (byte col = startCol; col < startCol + 3; col++)
                {
                    var currentNumber = board[row, col];

                    if (currentNumber == number)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private byte GetIndex(byte index)
        {
            byte startIndex;

            if (index <= 2)
            {
                startIndex = 0;
            }
            else if (index <= 5)
            {
                startIndex = 3;
            }
            else
            {
                startIndex = 6;
            }

            return startIndex;
        }

        private byte[,] CopyBoard(byte[,] boardToCopy)
        {
            var copy = new byte[BOARD_SIZE, BOARD_SIZE];

            for (int row = 0; row < BOARD_SIZE; row++)
            {
                for (int col = 0; col < BOARD_SIZE; col++)
                {
                    copy[row, col] = boardToCopy[row, col];
                }
            }

            return copy;
        }
    }
}
