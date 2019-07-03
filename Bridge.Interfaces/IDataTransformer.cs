using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Interfaces
{
    public interface IDataTransformer: IDisposable
    {
        object Transform(object data);
    }
}
