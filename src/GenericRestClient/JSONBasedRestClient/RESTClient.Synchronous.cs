using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Avalara.AvaTax.RestClient
{
    public partial class RESTClientJSON
    {
        public TR RestGet<TR>(string url, ClientConfiguration configuration)
        {
            var clientConfig = configuration ?? DefaultConfiguration;
            var request = CreateRequest(url, clientConfig);
            request.Accept = clientConfig.Accept;
            request.Method = "GET";

            return ReceiveData<TR>(request, clientConfig);
        }

        // Overload method
        public TR RestGet<TR>(string url)
        {
            return RestGet<TR>(url, DefaultConfiguration);
        }


        // ******** Synchronous GET, no response expected *******
        public void RestGetNonQuery(string url,
            ClientConfiguration configuration)
        {
            var clientConfig = configuration ?? DefaultConfiguration;
            var request = CreateRequest(url, clientConfig);
            request.Method = "GET";

            request.GetResponse().Close();
        }

        // Overload method
        public void RestGetNonQuery(string url)
        {
            RestGetNonQuery(url, DefaultConfiguration);
        }

        // ***************** Synchronous POST ********************
        public TR RestPost<TR,  TI> (string url,
            TI data, ClientConfiguration configuration)
        {
            var clientConfig = configuration ?? DefaultConfiguration;
            var request = CreateRequest(url, clientConfig);
            request.ContentType = clientConfig.ContentType;
            request.Accept = clientConfig.Accept;
            request.Method = "POST";
            request.PreAuthenticate = true;
            request.Timeout = int.MaxValue;

            PostData(request, clientConfig, data);
            return ReceiveData<TR>(request, clientConfig);
        }

        // Overload method
        public TR RestPost<TR, TI>(string url, TI data)
        {
            return RestPost<TR, TI>(url, data, DefaultConfiguration);
        }

        // ****** Synchronous GET, no respons expected ******
        public void RestPostNonQuery<TI>(string url,
            TI data, ClientConfiguration configuration)
        {
            var clientConfig = configuration ?? DefaultConfiguration;
            var request = CreateRequest(url, clientConfig);
            request.ContentType = clientConfig.ContentType;
            request.Accept = clientConfig.Accept;
            request.Method = "POST";

            PostData(request, clientConfig, data);
            request.GetResponse().Close();
        }

        // Overload method
        public void RestPostNonQuery<TI>(string url, TI data)
        {
            RestPostNonQuery(url, data, DefaultConfiguration);
        }
    }
}
