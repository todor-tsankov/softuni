using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var arr = args.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();

            var commandName = arr.First();

            var commandArgs = arr.Skip(1)
                                 .ToArray();

            var commandType = Assembly.GetCallingAssembly()
                                      .GetTypes()
                                      .FirstOrDefault(t => t.Name.StartsWith(commandName));

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid Command Type!");
            }

            var commandInstance = (ICommand)Activator.CreateInstance(commandType);

            var result =  commandInstance.Execute(commandArgs);

            return result;
        }
    }
}
