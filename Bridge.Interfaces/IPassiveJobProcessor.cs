using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Interfaces
{
    public interface IPassiveJobProcessor: IJobProcessor
    {
        object ProcessData(object data);
    }
}
