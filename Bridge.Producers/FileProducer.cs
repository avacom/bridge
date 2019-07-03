using Bridge.Interfaces;
using System;
using System.IO;

namespace Bridge.Producers
{
    public class FileProducer : IDataProducer
    {
        readonly string _fileName;

        public FileProducer(string fileName)
        {
            _fileName = fileName;
            Console.WriteLine($"[{GetType().Name}] Created. File Name = {_fileName}");
        }
        public void Dispose()
        {
            ;
        }

        public object Send(object data)
        {
            Console.WriteLine($"[{GetType().Name}] Sending the data to file: {data.ToString()}");
            File.AppendAllText(_fileName, data.ToString() + Environment.NewLine);
            return true;
        }
    }
}
