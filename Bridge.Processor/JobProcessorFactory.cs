using Bridge.Configuration;
using Bridge.Interfaces;
using System;

namespace Bridge.Processor
{
    public static class JobProcessorFactory
    {
        public static IJobProcessor CreateProcessor(ProcessorConfig config, IServiceProvider provider)
        {
            IJobProcessor res = null;
            if (config.DataConsumer == null)
            {
                res = new PassiveJobProcessor(config.Id, provider);
                ((PassiveJobProcessor)res).Initialize(config);
            }
            else
            {
                res = new ActiveJobProcessor(config.Id, provider);
                ((ActiveJobProcessor)res).Initialize(config);
            }
            return res;
        }
    }
}
