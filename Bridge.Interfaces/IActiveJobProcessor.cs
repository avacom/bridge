using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Interfaces
{
    public interface IActiveJobProcessor : IJobProcessor
    {
        /// <summary>
        /// Get the data consumer
        /// </summary>
        IDataConsumer Consumer { get; }
    }
}
