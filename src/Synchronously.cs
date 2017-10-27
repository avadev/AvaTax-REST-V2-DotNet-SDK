using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Avalara.AvaTax.RestClient
{
#if PORTABLE && !NET45
    /// <summary>
    /// A wrapper which blocks while a Asynchronous Programming Model (APM) operation executes.
    /// </summary>
    /// <typeparam name="TSender">The type of object performing the Asynchronous operation.</typeparam>
    /// <typeparam name="TData">They type of data to being sent to the Callback</typeparam>
    internal class Synchronously<TSender, TData>
    {
        private readonly Func<AsyncCallback, object, IAsyncResult> _begin;
        private readonly Action<State<TSender, TData>> _callback;

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="begin">A delegate when invoked returns a IAsyncResult</param>
        /// <param name="callback">A delegate invoked when the continuation is ready </param>
        public Synchronously(Func<AsyncCallback, object, IAsyncResult> begin, Action<State<TSender, TData>> callback)
        {
            _begin = begin;
            _callback = callback;
        }

        /// <summary>
        /// Executes the Asynchronous Programming Model (APM) operation blocking till completion.
        /// </summary>
        /// <param name="sender">The object containing the Begin and End methods</param>
        /// <param name="data">Data to be sent to the callback.</param>
        public void Execute(TSender sender, TData data)
        {
            Exception ex = null;

            using (ManualResetEvent manualEvent = new ManualResetEvent(false))
            {
                IAsyncResult asyncResult = _begin.Invoke(asynchronousResult =>
                {
                    try
                    {
                        _callback.Invoke(new State<TSender, TData>(sender, data, asynchronousResult));
                    }
                    catch (Exception inner)
                    {
                        ex = inner;
                    }
                    finally
                    {
                        manualEvent.Set();
                    }
                }, data);
                manualEvent.WaitOne();
            }

            if (ex != null)
            {
                throw ex;
            }
        }
    }
    /// <summary>
    /// A wrapper which blocks while a Asynchronous Programming Model (APM) operation executes.
    /// </summary>
    /// <typeparam name="TSender">The type of object performing the Asynchronous operation.</typeparam>
    /// <typeparam name="TData">They type of data to being sent to the Callback</typeparam>
    /// <typeparam name="TResult">They result of the Asynchronous operation</typeparam>
    internal class Synchronously<TSender, TData, TResult>
    {
        private readonly Func<AsyncCallback, object, IAsyncResult> _begin;
        private readonly Func<State<TSender, TData>, TResult> _callback;

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="begin">A delegate when invoked returns a IAsyncResult</param>
        /// <param name="callback">A delegate invoked when the continuation is ready </param>
        public Synchronously(
            Func<AsyncCallback, object, IAsyncResult> begin,
            Func<State<TSender, TData>, TResult> callback)
        {
            _begin = begin;
            _callback = callback;
        }

        /// <summary>
        /// Executes the Asynchronous Programming Model (APM) operation blocking till completion.
        /// </summary>
        /// <param name="sender">The object containing the Begin and End methods</param>
        /// <param name="data">Data to be sent to the callback.</param>
        public TResult Execute(TSender sender, TData data)
        {
            Exception ex = null;
            TResult result = default(TResult);
            using (ManualResetEvent manualEvent = new ManualResetEvent(false))
            {
                IAsyncResult asyncResult = _begin.Invoke(asynchronousResult =>
                {
                    try
                    {
                        result = _callback.Invoke(new State<TSender, TData>(sender, data, asynchronousResult));
                    }
                    catch (Exception inner)
                    {
                        ex = inner;
                    }
                    finally
                    {
                        manualEvent.Set();
                    }
                }, null);
                manualEvent.WaitOne();
            }

            if (ex != null)
            {
                throw ex;
            }
            return result;
        }
    }

#endif
}
