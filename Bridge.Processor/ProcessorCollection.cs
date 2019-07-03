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
        private List<ProcessorConfig> _processors;

        public ProcessorCollection(IServiceProvider provider)
        {
            _provider = provider;
            Processors = new List<IJobProcessor>();
        }

        public void Initialize(IConfiguration config)
        {
            _processors = config.GetSection("Processors").Get<List<ProcessorConfig>>();

            foreach (var p in _processors)
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
                var p = _processors?.Where(i => i.Id == id).FirstOrDefault();

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
    }
}
