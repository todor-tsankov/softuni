namespace SOLID_Exercise.Models.Contracts
{
    public interface IFile
    {
        string Path { get; }

        long Size { get; }

        string Write(IError error, ILayout layout);
    }
}
