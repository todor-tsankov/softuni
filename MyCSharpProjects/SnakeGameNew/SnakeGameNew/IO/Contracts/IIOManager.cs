using SnakeGame.Models.Contracts;

namespace SnakeGame.IO.Contracts
{
    public interface IIOManager
    {
        IReader Reader { get; }
        IWriter Writer { get; }
        ISetter Setter { get; }

        int StartScreen();

        void PrintField(char[,] field);

        void PrintPoint(IPoint point, char ch);

        void PrintStats(int points);

        void EndScreen(string[] oldHighscoreArgs, int currentPoints);

        void SetUpField(char[,] field, IPoint snakeInitialPoint, IPoint initialScorePoint, int points);
    }
}
