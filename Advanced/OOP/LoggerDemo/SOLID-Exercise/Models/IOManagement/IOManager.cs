using System.IO;

using SOLID_Exercise.Models.Contracts;

namespace SOLID_Exercise.Models.IOManagement
{
    public class IOManager : IIOManager
    {
        private readonly string currentPath;

        private readonly string folderName;
        private readonly string fileName;

        private IOManager()
        {
            this.currentPath = GetCurrentDirectory();
        }

        public IOManager(string folderName, string fileName)
            : this()
        {

            this.folderName = folderName;
            this.fileName = fileName;

            EnsureDirectoryAndFileExist();
        }

        public string CurrentDirectoryPath => this.currentPath + this.folderName;

        public string CurrentFilePath => this.CurrentDirectoryPath + this.fileName;

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, string.Empty);
        }

        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
