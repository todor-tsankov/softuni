using SOLID_Exercise.Models.Contracts;
using SOLID_Exercise.Models.Enumerations;

namespace SOLID_Exercise.Models.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, Level level, IFile file)
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
        }
        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public IFile File { get; private set; }

        public long MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            var formattedMessage = this.File.Write(error, this.Layout);

            System.IO.File.AppendAllText(this.File.Path, formattedMessage);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {nameof(FileAppender)}, Layout type: {this.Layout.GetType().Name}," +
                   $" Report level: {this.Level.ToString().ToUpper()}, Messages appended: {this.MessagesAppended}, File size {this.File.Size}";
        }
    }
}
