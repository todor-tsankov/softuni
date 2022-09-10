using System;
using System.Linq;
using System.Reflection;

using SOLID_Exercise.Models.Files;
using SOLID_Exercise.Models.Appenders;
using SOLID_Exercise.Models.Contracts;
using SOLID_Exercise.Models.Enumerations;

namespace SOLID_Exercise.Factories
{
    public class AppenderFactory
    {
        private readonly LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender ProduceAppender(string appenderType, string layoutType, string levelStr)
        {
            var hasParsed = Enum.TryParse<Level>(levelStr, true, out Level level);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid level!");
            }

            var layout = this.layoutFactory.ProduceLayout(layoutType);

            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile("\\data\\", "logs.txt");

                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new ArgumentException("Invalid level type!");
            }

            return appender;
        }
    }
}
