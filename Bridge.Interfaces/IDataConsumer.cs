using System;

namespace Bridge.Interfaces
{
    public interface IDataConsumer: IDisposable
    {
        event EventHandler<object> DataReceived;
        void SetResult(object result);
    }
}
