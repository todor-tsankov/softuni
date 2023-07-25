namespace SnakeGame.IO.Contracts
{
    public interface ISetter
    {
        void Clear();
        void SetCursor(bool visible);
        void SetCursorPosition(int col, int row);
    }
}
