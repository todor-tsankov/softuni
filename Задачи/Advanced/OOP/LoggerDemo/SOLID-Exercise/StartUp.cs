using System;
using System.Linq;
using System.Collections.Generic;

using SOLID_Exercise.Core;
using SOLID_Exercise.Models;
using SOLID_Exercise.Factories;
using SOLID_Exercise.Models.Contracts;

namespace SOLID_Exercise
{
    public class StartUp
    {
        public static void Main()
        {
            var appenders = new List<IAppender>();
            var appenderFactory = new AppenderFactory();

            var appendersCount = int.Parse(Console.ReadLine());

            ReadInputAppenders(appenders, appenderFactory, appendersCount);

            var logger = new Logger(appenders);
            var engine = new Engine(logger);

            engine.Run();
        }

        private static void ReadInputAppenders(List<IAppender> appenders, AppenderFactory appenderFactory, int appendersCount)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                var appenderInfo = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .ToArray();

                var appenderType = appenderInfo[0];
                var layoutType = appenderInfo[1];
                var level = "INFO";

                if (appenderInfo.Length == 3)
                {
                    level = appenderInfo[2];
                }

                try
                {
                    IAppender appender = appenderFactory.ProduceAppender(appenderType, layoutType, level);

                    appenders.Add(appender);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
