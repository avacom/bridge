using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Interfaces
{
    public interface IDataProducer: IDisposable
    {
        object Send(object data);
    }
}
