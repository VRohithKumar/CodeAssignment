using CALibrary.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALibrary.BusinessObjects
{
   public class FileHandler
    {
        private IFileSystemHandler _fileSystem;
        public IFileSystemHandler FileSystemHandler
        {
            get
            {
                if (_fileSystem == null)
                {
                    _fileSystem = new FileSystemHandler();
                }
                return _fileSystem;
            }
            set
            {
                _fileSystem = value;
            }
        }
    }
}
