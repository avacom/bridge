using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Interfaces
{
    /// <summary>
    /// Manager of the job which consists of getting, transforming, and sending the data
    /// </summary>
    public interface IJobProcessor : IDisposable
    {
        /// <summary>
        /// Job processor identifier
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Get the data transformer
        /// </summary>
        IDataTransformer Transformer { get; }

        /// <summary>
        /// Get the data producer
        /// </summary>
        IDataProducer Producer { get; }
    }
}
