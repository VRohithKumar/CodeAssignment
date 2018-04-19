using System;

namespace CALibrary.Handlers
{
    public interface IStreamHandler : IDisposable
    {
        string ReadLine();
        void InitializeReader(string path);       
    }
}
