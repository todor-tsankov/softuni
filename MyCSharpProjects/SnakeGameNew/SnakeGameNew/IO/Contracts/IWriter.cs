namespace SnakeGame.IO.Contracts
{
    public interface IWriter
    {
        void Write(char ch);
        void WriteLine(char ch);

        void Write(string input);
        void WriteLine(string input);

        void WriteLine();
    }
}
