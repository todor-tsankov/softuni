using System;
using System.Globalization;

using SOLID_Exercise.Models.Contracts;
using SOLID_Exercise.Models.Enumerations;

namespace SOLID_Exercise.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public long MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            var format = this.Layout.Format;
            var dateTime = error.DateTime;
            var message = error.Message;
            var level = error.Level;

            var formattedMessage = string.Format(format, dateTime.ToString("M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture), 
                                                         message, 
                                                         level.ToString());

            Console.WriteLine(formattedMessage);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {nameof(ConsoleAppender)}, Layout type: {this.Layout.GetType().Name}" +
                   $", Report level: {this.Level.ToString().ToUpper()}, Messages appended: {this.MessagesAppended}";
        }
    }
}
