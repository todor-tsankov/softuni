namespace SudokuSolver
{
    public class Engine
    {
        public void Run()
        {
            var sudoku = new Sudoku();
            var board = sudoku.ReadBoard();

            sudoku.Solve(board);
            sudoku.PrintBoard();
        }
    }
}
