using Bridge.Configuration;
using Bridge.Interfaces;
using System;

namespace Bridge.Processor
{
    public class ActiveJobProcessor: JobProcessorBase, IActiveJobProcessor
    {
        public IDataConsumer Consumer { get; private set; }

        public ActiveJobProcessor(string id, IServiceProvider provider) : base(id, provider)
        {
        }

        public override void Initialize(ProcessorConfig config)
        {
            base.Initialize(config);
            Consumer = LoadProcessorElement<IDataConsumer>(config.DataConsumer);
            Consumer.DataReceived += Consumer_DataReceived;
        }

        private void Consumer_DataReceived(object sender, object e)
        {
            var consumer = (IDataConsumer)sender;
            Console.WriteLine($"[{Id}] data received: {e.ToString()}. Passing to the transformer");
            var transformed = Transformer?.Transform(e);
            Console.WriteLine($"[{Id}] transformed data: {transformed.ToString()}. Passing to the producer");
            var res = Producer?.Send(transformed);
            consumer.SetResult(res);
        }
    }
}
