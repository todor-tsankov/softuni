using System;
using System.Linq;

using SOLID_Exercise.Factories;
using SOLID_Exercise.Core.Contracts;
using SOLID_Exercise.Models.Contracts;

namespace SOLID_Exercise.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger)
            : this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var inputArgs = command.Split("|", StringSplitOptions.RemoveEmptyEntries)
                                       .ToArray();

                var level = inputArgs[0];
                var dateTime = inputArgs[1];
                var message = inputArgs[2];

                try
                {
                    var error = this.errorFactory.ProduceError(dateTime, message, level);

                    this.logger.Log(error);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(this.logger); 
        }
    }
}
