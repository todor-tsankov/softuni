namespace SudokuSolver.Core.Contracts
{
    public interface IEngine
    {
        int[,] Matrix { get; }

        void Solve(int[,] matrix, int initialRow, int InitialCol);
    }
}
