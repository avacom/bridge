using System.Collections.Generic;

namespace Bridge.Configuration
{
    public class ProcessorConfig
    {
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public ProcessorMemberConfig DataConsumer { get; set; }
        public ProcessorMemberConfig DataTransformer { get; set; }
        public ProcessorMemberConfig DataProducer { get; set; }
    }
}
