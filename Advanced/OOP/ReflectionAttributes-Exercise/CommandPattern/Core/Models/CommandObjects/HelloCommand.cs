
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models.CommandObjects
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
