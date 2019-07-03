using System.Collections.Generic;

namespace Bridge.Configuration
{
    public class ProcessorMemberConfig
    {
        public string Assembly { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
}
