using System.IO;

namespace CALibrary.Handlers
{    
    public class FileSystemHandler: IFileSystemHandler
    {
        public bool FileExists(string fileName)
        {
            return File.Exists(fileName);
        }
    }
}
