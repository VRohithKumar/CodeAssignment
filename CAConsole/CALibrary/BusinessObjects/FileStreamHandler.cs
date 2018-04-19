using CALibrary.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALibrary.BusinessObjects
{
   public class FileStreamHandler
    {
        public IStreamHandler _streamReader;
        public IStreamHandler StreamReaderHandler
        {
            get
            {
                if (_streamReader == null)
                {
                    _streamReader = new StreamHandler();
                }
                return _streamReader;
            }
            set
            {
                _streamReader = value;
            }
        }
    }
}
