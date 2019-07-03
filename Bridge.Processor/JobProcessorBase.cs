using Bridge.Configuration;
using Bridge.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Bridge.Processor
{
    public abstract class JobProcessorBase: IJobProcessor
    {
        public IDataTransformer Transformer { get; private set; }
        public IDataProducer Producer { get; private set; }

        public string Id { get; set; }

        private readonly IServiceProvider _provider;

        public JobProcessorBase(string id, IServiceProvider provider)
        {
            Id = id;
            _provider = provider;
        }

        public virtual void Initialize(ProcessorConfig config)
        {
            Transformer = LoadProcessorElement<IDataTransformer>(config.DataTransformer);
            Producer = LoadProcessorElement<IDataProducer>(config.DataProducer);
        }

        public T LoadProcessorElement<T>(ProcessorMemberConfig element)
        {
            T res = default(T);

            if (element != null)
            {
                var type = Assembly.LoadFile($"{AppDomain.CurrentDomain.BaseDirectory}\\{element.Assembly}").GetType(element.Type);

                if (type != null)
                {
                    var param = element.Parameters?.Select(p => p.Value).ToList();

                    var elem = param != null ? 
                        (T)ActivatorUtilities.CreateInstance(_provider, type, param.ToArray()) :
                        (T)ActivatorUtilities.CreateInstance(_provider, type);

                    if (elem != null)
                    {
                        res = elem;
                    }
                }
            }
            return res;
        }

        public void Dispose()
        {
            Producer?.Dispose();
            Transformer?.Dispose();
        }
    }
}
