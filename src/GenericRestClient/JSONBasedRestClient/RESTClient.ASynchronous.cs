using System;
 using System.Runtime.Remoting.Messaging;

namespace Avalara.AvaTax.RestClient
{
    public partial class RESTClientJSON
    {
        private delegate TR GetDelegate<TR>(string url,
            ClientConfiguration configuration);
        private delegate void GetNonQueryDelegate(string url,
            ClientConfiguration configuration);
        private delegate TR PostDelegate<TR, TI>(string url, TI data,
            ClientConfiguration configuration);
        private delegate void PostNonQueryDelegate<TI>(string url, TI data,
            ClientConfiguration configuration);

        // *************** Asynchronous Get ***************************
        public void RestGetAsync<TR>(string url, RestCallBack<TR> callback,
            ClientConfiguration configuration)
        {
            var get = new GetDelegate<TR>(RestGet<TR>);
            get.BeginInvoke(url, configuration,
            ar =>
            {
                var result = (AsyncResult)ar;
                var del = (GetDelegate<TR>)result.AsyncDelegate;
                var value = default(TR);
                Exception e = null;

                try { value = del.EndInvoke(result); }
                catch (Exception ex) { e = ex; }

                if (callback != null) { callback(e, value); }

            }, null);
        }

        // Overload method
        public void RestGetAsync<TR>(string url, RestCallBack<TR> callback)
        {
            RestGetAsync<TR>(url, callback, DefaultConfiguration);
        }

        // *********** Asynchronous Get, no response expected *************
        public void RestGetNonQueryAsync(string url,
            RestCallBackNonQuery callback, ClientConfiguration configuration)
        {
            var get = new GetNonQueryDelegate(RestGetNonQuery);
            get.BeginInvoke(url, configuration,
            ar =>
            {
                var result = (AsyncResult)ar;
                var del = (GetNonQueryDelegate)result.AsyncDelegate;
                Exception e = null;

                try { del.EndInvoke(result); }
                catch (Exception ex) { e = ex; }

                if (callback != null) { callback(e); }

            }, null);

        }

        // Overload method
        public void RestGetNonQueryAsync(string url,
            RestCallBackNonQuery callback)
        {
            RestGetNonQueryAsync(url, callback, DefaultConfiguration);
        }

        // *************** Asynchronous Post *********************
        public void RestPostAsync<TR, TI>(string url, TI data,
            RestCallBack<TR> callback, ClientConfiguration configuration)
        {
            var post = new PostDelegate<TR, TI>(RestPost<TR, TI>);
            post.BeginInvoke(url, data, configuration,
            ar =>
            {
                var result = (AsyncResult)ar;
                var del = (PostDelegate<TR, TI>)result.AsyncDelegate;
                var value = default(TR);
                Exception e = null;

                try { value = del.EndInvoke(result); }
                catch (Exception ex) { e = ex; }

                if (callback != null) { callback(e, value); }

            }, null);
        }

        // Overload method
        public void RestPostAsync<TR, TI>(string url, TI data,
            RestCallBack<TR> callback)
        {
            RestPostAsync<TR, TI>(url, data, callback, DefaultConfiguration);
        }


        // ********* Asynchronous Post, not response expected *********
        public void RestPostNonQueryAsync<TI>(string url, TI data,
            RestCallBackNonQuery callback, ClientConfiguration configuration)
        {
            var post = new PostNonQueryDelegate<TI>(RestPostNonQuery);
            post.BeginInvoke(url, data, configuration,
            ar =>
            {
                var result = (AsyncResult)ar;
                var del = (PostNonQueryDelegate<TI>)result.AsyncDelegate;
                Exception e = null;

                try { del.EndInvoke(result); }
                catch (Exception ex) { e = ex; }

                if (callback != null) { callback(e); }

            }, null);
        }

        // Overload method
        public void RestPostNonQueryAsync<TI>(string url, TI data,
            RestCallBackNonQuery callback)
        {
            RestPostNonQueryAsync(url, data, callback, DefaultConfiguration);
        }
    }
}
