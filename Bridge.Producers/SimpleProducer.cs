using Bridge.Interfaces;
using System;

namespace Bridge.Producers
{
    public class SimpleProducer : IDataProducer
    {
        public SimpleProducer()
        {
            Console.WriteLine($"[{GetType().Name}] Created");
        }
        public void Dispose()
        {
            ;
        }

        public object Send(object data)
        {
            Console.WriteLine($"[{GetType().Name}] Sending the data to console: {data.ToString()}");
            return true;
        }
    }
}
