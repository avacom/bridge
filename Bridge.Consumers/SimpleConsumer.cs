using Bridge.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bridge.Consumers
{
    public class SimpleConsumer : IDataConsumer
    {
        public event EventHandler<object> DataReceived;

        readonly int _delay;

        public SimpleConsumer(string delay = "1")
        {
            _delay = Convert.ToInt32(delay);
            Console.WriteLine($"[{GetType().Name}] of the type {this.GetType()} created. Delay = {_delay} sec");
            Task.Run(() => Start());
        }

        void Start()
        {
            while(true)
            {
                Console.WriteLine($"[{{GetType().Name}}] Data received");
                DataReceived?.Invoke(this, "Hello World!");
                Thread.Sleep(_delay * 1000);
            }
        }

        public void Dispose()
        {
            Console.WriteLine($"[{{GetType().Name}}] of the type {this.GetType()} disposed");
        }

        public void SetResult(object result)
        {
            ;
        }
    }
}
