using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Bridge.Interfaces
{
    /// <summary>
    /// Collection of job processors
    /// </summary>
    public interface IProcessorCollection
    {
        /// <summary>
        /// Get job processors
        /// </summary>
        List<IJobProcessor> Processors { get; }

        /// <summary>
        /// Get the job processor by ID
        /// </summary>
        /// <param name="id">Processor identifier</param>
        /// <param name="newInstance">true - create a new instance; otherwise - false</param>
        /// <returns>Job processor</returns>
        IJobProcessor GetProcessor(string id, bool newInstance = false);
    }
}
