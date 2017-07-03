using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Avalara.AvaTax.RestClient
{
    public partial class RESTClientJSON : IDisposable
    {
        public static ClientConfiguration DefaultConfiguration { get; set; }
        public Dictionary<string, string> _headers;

        public RESTClientJSON()
        {
            // Initiate the default configuration
            DefaultConfiguration = new ClientConfiguration() { ContentType = "application/json", Accept = "application/json", RequireSession = false, OutBoundSerializerAdapter = new JSONSerializerAdapter(), InBoundSerializerAdapter = new JSONSerializerAdapter() };
        }
        public RESTClientJSON(Dictionary<string, string> headers)
            : this()
        {
            _headers = headers;
        }

        // Create a request object according to the configuration
        public HttpWebRequest CreateRequest(string url,
            ClientConfiguration clientConfig)
        {
            var request = (clientConfig.RequireSession) ? CookiedHttpWebRequestFactory.Create(url) :
                (HttpWebRequest)WebRequest.Create(url);
            if (_headers != null)
            {
                foreach (var header in _headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
            return request;
        }

        // Post data to the service
        public static void PostData<T>(HttpWebRequest request,
            ClientConfiguration clientConfig, T data)
        {
            var xmlRequestString = clientConfig.OutBoundSerializerAdapter.Serialize(data);
            var bytes = Encoding.UTF8.GetBytes(xmlRequestString);

            using (var postStream = request.GetRequestStream())
            {
                postStream.Write(bytes, 0, bytes.Length);
            }
        }

        // Receive data from the service
        public static T ReceiveData<T>(HttpWebRequest request,
            ClientConfiguration clientConfig)
        {
            string xmlResponseString;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var stream = response.GetResponseStream();
                if (stream == null) { return default(T); }
                using (var streamReader = new   StreamReader(stream))
                {
                    xmlResponseString = streamReader.ReadToEnd();
                }
            }
            try
            {
                return clientConfig.InBoundSerializerAdapter.Deserialize<T>(xmlResponseString);
            }
            catch (InvalidOperationException ex)
            {
                //if something weired happened while deserilization, response returned by service can be 
                var e = new NotSupportedException(xmlResponseString, ex);
                throw e;
            }
            catch (Exception e)
            {
                var ex = new NotSupportedException(xmlResponseString, e);
                throw ex;
            }

        }

        public void Dispose()
        {

        }
    }
}
