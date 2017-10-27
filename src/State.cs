using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalara.AvaTax.RestClient
{

#if PORTABLE && !NET45

    internal class State<TSender, TData>
    {
        public State(TSender sender, TData data, IAsyncResult asynchronousResult)
        {
            Sender = sender;
            Data = data;
            AsynchronousResult = asynchronousResult;
        }

        public TSender Sender { get; private set; }

        public TData Data { get; private set; }

        public IAsyncResult AsynchronousResult { get; private set; }
    }
#endif
}
