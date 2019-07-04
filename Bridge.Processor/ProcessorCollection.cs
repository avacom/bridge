using Bridge.Configuration;
using Bridge.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge.Processor
{
    public class ProcessorCollection: IProcessorCollection
    {
        public List<IJobProcessor> Processors { get; private set; }

        private readonly IServiceProvider _provider;
        private List<ProcessorConfig> _processorConfigs;

        public ProcessorCollection(IServiceProvider provider)
        {
            _provider = provider;
            Processors = new List<IJobProcessor>();
        }

        public void Initialize(IConfiguration config)
        {
            _processorConfigs = config.GetSection("Processors").Get<List<ProcessorConfig>>();

            foreach (var p in _processorConfigs)
            {
                var processor = JobProcessorFactory.CreateProcessor(p, _provider);
                Processors.Add(processor);
            }
        }

        public IJobProcessor GetProcessor(string id, bool newInstance = false)
        {
            IJobProcessor res = null;

            if (newInstance)
            {
                var p = _processorConfigs?.Where(i => i.Id == id).FirstOrDefault();

                if (p != null)
                {
                    var processor = JobProcessorFactory.CreateProcessor(p, _provider);
                    res = processor;
                }
            }
            else
            {
                res = Processors?.Where(p => p.Id == id).FirstOrDefault();
            }

            return res;
        }

        public void Dispose()
        {
            if (Processors != null)
            {
                foreach(var p in Processors)
                {
                    p.Dispose();
                }
            }

            Processors.Clear();
            Processors = null;
        }
    }
}
