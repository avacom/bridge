using Bridge.Interfaces;
using System;

namespace Bridge.Processor
{
    public class PassiveJobProcessor: JobProcessorBase, IPassiveJobProcessor
    {
        public PassiveJobProcessor(string id, IServiceProvider provider) : base(id, provider)
        {
        }

        public object ProcessData(object data)
        {
            object res = null;
            Console.WriteLine($"[{Id}] data received: {data.ToString()}. Passing to the transformer");
            var transformed = Transformer?.Transform(data);
            Console.WriteLine($"[{Id}] transformed data: {transformed.ToString()}. Passing to the producer");
            res = Producer?.Send(transformed);
            return res;
        }
    }
}
