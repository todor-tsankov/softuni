namespace SnakeGame.Models.Contracts
{
    public interface ISnakeSegment
    {
        int Row { get; set; }
        int Col { get; set; }
    }
}
