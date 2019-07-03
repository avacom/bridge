using Bridge.Interfaces;
using System;

namespace Bridge.Transformers
{
    public class SimpleTransformer: IDataTransformer
    {

        public SimpleTransformer()
        {
            Console.WriteLine($"[{GetType().Name}] Created");
        }

        public void Dispose()
        {
            ;
        }

        public object Transform(object data)
        {
            Console.WriteLine($"[{GetType().Name}] Transforming the data");
            var str = data.ToString();
            str = str.Replace("World", "Lord");
            return str;
        }
    }
}
