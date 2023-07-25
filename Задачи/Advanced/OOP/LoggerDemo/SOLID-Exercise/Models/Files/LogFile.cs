using System.IO;
using System.Linq;
using System.Globalization;

using SOLID_Exercise.Models.Contracts;
using SOLID_Exercise.Models.IOManagement;

namespace SOLID_Exercise.Models.Files
{
    public class LogFile : IFile
    {
        private readonly IIOManager iOManager;

        public LogFile(string folderName, string fileName)
        {
            this.iOManager = new IOManager(folderName, fileName);
        }

        public string Path => this.iOManager.CurrentFilePath;

        public long Size => this.GetFileSize();

        public string Write(IError error, ILayout layout)
        {
            var format = layout.Format;
            var dateTime = error.DateTime;
            var message = error.Message;
            var level = error.Level;

            var formattedMessage = string.Format(format, dateTime.ToString("M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                                         message,
                                                         level.ToString());

            return formattedMessage;
        }
        private long GetFileSize()
        {
            var text = File.ReadAllText(this.Path);

            var size = text.Where(char.IsLetter)
                           .Sum(ch => ch);

            return size;
        }
    }
}
