using System;
using System.Collections.Generic;
#if PORTABLE
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
#endif
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// The main client class for working with AvaTax
    /// </summary>
    /// <remarks>
    /// This file contains all the basic behavior.  Individual APIs are in the other partial class.
    /// </remarks>
    public partial class AvaTaxClient : IDisposable
    {
        private string _credentials;
        private string _clientHeader;
        private Uri _envUri;
#if PORTABLE
        private HttpClient _client;
#endif

        #region Constructor
        /// <summary>
        /// Generate a client that connects to one of the standard AvaTax servers
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="appVersion"></param>
        /// <param name="machineName"></param>
        /// <param name="environment"></param>
        public AvaTaxClient(string appName, string appVersion, string machineName, AvaTaxEnvironment environment)
        {
            // Redo the client identifier
            WithClientIdentifier(appName, appVersion, machineName);

            // Setup the URI
            switch (environment) {
                case AvaTaxEnvironment.Sandbox: _envUri = new Uri(Constants.AVATAX_SANDBOX_URL); break;
                case AvaTaxEnvironment.Production: _envUri = new Uri(Constants.AVATAX_PRODUCTION_URL); break;
                default: throw new Exception("Unrecognized Environment");
            }

            // Redo the HTTP client
            SetupClient();
        }

        /// <summary>
        /// Generate a client that connects to a custom server
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="appVersion"></param>
        /// <param name="machineName"></param>
        /// <param name="customEnvironment"></param>
        public AvaTaxClient(string appName, string appVersion, string machineName, Uri customEnvironment)
        {
            // Redo the client identifier
            WithClientIdentifier(appName, appVersion, machineName);
            _envUri = customEnvironment;

            // Redo the HTTP client
            SetupClient();
        }

        /// <summary>
        /// Dispose HTTP client
        /// </summary>
        public void Dispose()
        {
#if PORTABLE
            if (_client != null) {
                _client.Dispose();
            }
#endif
        }
#endregion

#region Security
        /// <summary>
        /// Sets the default security header string
        /// </summary>
        /// <param name="headerString"></param>
        public AvaTaxClient WithSecurity(string headerString)
        {
            _credentials = headerString;

            // Redo the HTTP client
            SetupClient();
            return this;
        }

        /// <summary>
        /// Set security using username/password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public AvaTaxClient WithSecurity(string username, string password)
        {
            var combined = String.Format("{0}:{1}", username, password);
            var bytes = Encoding.UTF8.GetBytes(combined);
            var base64 = System.Convert.ToBase64String(bytes);
            return WithSecurity("Basic " + base64);
        }

        /// <summary>
        /// Set security using AccountId / License Key
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="licenseKey"></param>
        public AvaTaxClient WithSecurity(int accountId, string licenseKey)
        {
            var combined = String.Format("{0}:{1}", accountId, licenseKey);
            var bytes = Encoding.UTF8.GetBytes(combined);
            var base64 = System.Convert.ToBase64String(bytes);
            return WithSecurity("Basic " + base64);
        }

        /// <summary>
        /// Set security using a bearer token
        /// </summary>
        /// <param name="bearerToken"></param>
        /// <returns></returns>
        public AvaTaxClient WithBearerToken(string bearerToken)
        {
            WithSecurity("Bearer " + bearerToken);
            return this;
        }
#endregion

#region Client Identification

#endregion

#region Implementation
        /// <summary>
        /// Configure client identification
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="appVersion"></param>
        /// <param name="machineName"></param>
        /// <returns></returns>
        public AvaTaxClient WithClientIdentifier(string appName, string appVersion, string machineName)
        {
            _clientHeader = String.Format("{0}; {1}; {2}; {3}; {4}", appName, appVersion, "CSharpRestClient", API_VERSION, machineName);

            // Redo the HTTP client
            SetupClient();
            return this;
        }

        /// <summary>
        /// Setup a new HTTP client object and dispose the old one
        /// </summary>
        private void SetupClient()
        {
#if PORTABLE
            // Delete old client
            if (_client != null) {
                _client.Dispose();
            }

            // Construct new client
            _client = new HttpClient();
            _client.BaseAddress = _envUri;

            // Add credentials
            if (_credentials != null) {
                _client.DefaultRequestHeaders.Add("Authorization", _credentials);
            }
            if (_clientHeader != null) {
                _client.DefaultRequestHeaders.Add("X-Avalara-Client", _clientHeader);
            }
#else
#endif
        }

        private JsonSerializerSettings _serializer_settings = null;
        private JsonSerializerSettings SerializerSettings
        {
            get
            {
                if (_serializer_settings == null) {
                    lock (this) {
                        _serializer_settings = new JsonSerializerSettings();
                        _serializer_settings.NullValueHandling = NullValueHandling.Ignore;
                        _serializer_settings.Converters.Add(new StringEnumConverter());
                    }
                }
                return _serializer_settings;
            }
        }


#if PORTABLE
        /// <summary>
        /// Implementation of asynchronous client APIs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="verb"></param>
        /// <param name="uri"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        private async Task<T> RestCallAsync<T>(string verb, AvaTaxPath uri, object payload = null)
        {
            var s = await RestCallStringAsync(verb, uri, payload);
            return JsonConvert.DeserializeObject<T>(s);
        }

        /// <summary>
        /// Implementation of raw file-returning async API 
        /// </summary>
        /// <param name="verb"></param>
        /// <param name="uri"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        private async Task<FileResult> RestCallFileAsync(string verb, AvaTaxPath uri, object payload = null)
        {
            // Make the request
            HttpResponseMessage result = null;
            string json = null;
            if (verb == "get") {
                result = await _client.GetAsync(uri.ToString());
            } else if (verb == "post") {
                json = JsonConvert.SerializeObject(payload, SerializerSettings);
                result = await _client.PostAsync(uri.ToString(), new StringContent(json, Encoding.UTF8, "application/json"));
            } else if (verb == "put") {
                json = JsonConvert.SerializeObject(payload, SerializerSettings);
                result = await _client.PutAsync(uri.ToString(), new StringContent(json, Encoding.UTF8, "application/json"));
            } else if (verb == "delete") {
                result = await _client.DeleteAsync(uri.ToString());
            }

            // Read the result
            if (result.IsSuccessStatusCode) {
                return new FileResult()
                {
                    ContentType = result.Content.Headers.GetValues("Content-Type").FirstOrDefault(),
                    Filename = GetDispositionFilename(result.Content.Headers.GetValues("Content-Disposition").FirstOrDefault()),
                    Data = await result.Content.ReadAsByteArrayAsync()
                };
            } else {
                var s = await result.Content.ReadAsStringAsync();
                var err = JsonConvert.DeserializeObject<ErrorResult>(s);
                throw new AvaTaxError(err);
            }
        }

        /// <summary>
        /// Non-async method for downloading a file
        /// </summary>
        /// <param name="verb"></param>
        /// <param name="uri"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        private FileResult RestCallFile(string verb, AvaTaxPath uri, object payload = null)
        {
            return RestCallFileAsync(verb, uri, payload).Result;
        }

        /// <summary>
        /// Implementation of raw string-returning async API 
        /// </summary>
        /// <param name="verb"></param>
        /// <param name="uri"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        private async Task<string> RestCallStringAsync(string verb, AvaTaxPath uri, object payload = null)
        {
            // Make the request
            HttpResponseMessage result = null;
            string json = null;
            if (verb == "get") {
                result = await _client.GetAsync(uri.ToString());
            } else if (verb == "post") {
                json = JsonConvert.SerializeObject(payload, SerializerSettings);
                result = await _client.PostAsync(uri.ToString(), new StringContent(json, Encoding.UTF8, "application/json"));
            } else if (verb == "put") {
                json = JsonConvert.SerializeObject(payload, SerializerSettings);
                result = await _client.PutAsync(uri.ToString(), new StringContent(json, Encoding.UTF8, "application/json"));
            } else if (verb == "delete") {
                result = await _client.DeleteAsync(uri.ToString());
            }

            // Read the result
            var s = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode) {
                return s;
            } else {
                var err = JsonConvert.DeserializeObject<ErrorResult>(s);
                throw new AvaTaxError(err);
            }
        }

        /// <summary>
        /// Implementation of raw string-returning API
        /// </summary>
        /// <param name="verb"></param>
        /// <param name="uri"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        private string RestCallString(string verb, AvaTaxPath uri, object payload = null)
        {
            return RestCallStringAsync(verb, uri, payload).Result;
        }

        /// <summary>
        /// Direct implementation of client APIs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="verb"></param>
        /// <param name="uri"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        private T RestCall<T>(string verb, AvaTaxPath uri, object payload = null)
        {
            try {
                return RestCallAsync<T>(verb, uri, payload).Result;

            // Unroll single-exception aggregates for ease of use
            } catch (AggregateException ex) {
                if (ex.InnerExceptions.Count == 1) {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }
#else
        /// <summary>
        /// Direct implementation of client APIs to object values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="verb"></param>
        /// <param name="uri"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        private T RestCall<T>(string verb, AvaTaxPath uri, object payload = null)
        {
            var s = RestCallString(verb, uri, payload);
            return JsonConvert.DeserializeObject<T>(s);
        }

        /// <summary>
        /// Direct implementation of client APIs to string values
        /// </summary>
        /// <param name="verb"></param>
        /// <param name="uri"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        private FileResult RestCallFile(string verb, AvaTaxPath uri, object payload = null)
        {
            string path = CombinePath(_envUri.ToString(), uri.ToString());

            // Use HttpWebRequest so we can get a decent response
            var wr = (HttpWebRequest)WebRequest.Create(path);
            wr.Proxy = null;

            // Construct the basic auth, if required
            if (!String.IsNullOrEmpty(_credentials)) {
                wr.Headers[HttpRequestHeader.Authorization] = _credentials;
            }
            if (!String.IsNullOrEmpty(_clientHeader)) {
                wr.Headers[Constants.AVALARA_CLIENT_HEADER] = _clientHeader;
            }

            // Convert the name-value pairs into a byte array
            wr.Method = verb.ToUpper();
            if (payload != null) {
                wr.ContentType = Constants.JSON_MIME_TYPE;
                wr.ServicePoint.Expect100Continue = false;

                // Encode the payload
                var json = JsonConvert.SerializeObject(payload, SerializerSettings);
                var encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(json);
                wr.ContentLength = data.Length;

                // Call the server
                using (var s = wr.GetRequestStream()) {
                    s.Write(data, 0, data.Length);
                    s.Close();
                }
            }

            // Transmit, and get back the response, save it to a temp file
            try {
                using (var response = wr.GetResponse()) {
                    using (var inStream = response.GetResponseStream()) {
                        const int BUFFER_SIZE = 1024;
                        var chunks = new List<byte>();
                        var totalBytes = 0; 
                        var bytesRead = 0;

                        do
                        {
                            var buffer = new byte[BUFFER_SIZE];
                            bytesRead = inStream.Read(buffer, 0, BUFFER_SIZE);
                            if (bytesRead == BUFFER_SIZE) {
                                chunks.AddRange(buffer);
                            } else {
                                for (int i = 0; i < bytesRead; i++) {
                                    chunks.Add(buffer[i]);
                                }
                            }
                            totalBytes += bytesRead;
                        } while (bytesRead > 0);
        
                        if(totalBytes <= 0) {
                            throw new IOException("Response contained no data");
                        }

                        // Here's your file result
                        return new FileResult()
                        {
                            ContentType = response.Headers["Content-Type"].ToString(),
                            Filename = GetDispositionFilename(response.Headers["Content-Disposition"].ToString()),
                            Data = chunks.ToArray()
                        };
                    }
                }

                // Catch a web exception
            } catch (WebException webex) {
                HttpWebResponse httpWebResponse = webex.Response as HttpWebResponse;
                if (httpWebResponse != null) {
                    using (Stream stream = httpWebResponse.GetResponseStream()) {
                        using (StreamReader reader = new StreamReader(stream)) {
                            var errString = reader.ReadToEnd();
                            var err = JsonConvert.DeserializeObject<ErrorResult>(errString);
                            throw new AvaTaxError(err);
                        }
                    }
                }

                // If we can't parse it as an AvaTax error, just throw
                throw webex;
            }
        }

        /// <summary>
        /// Direct implementation of client APIs to string values
        /// </summary>
        /// <param name="verb"></param>
        /// <param name="uri"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        private string RestCallString(string verb, AvaTaxPath uri, object payload = null)
        {
            string path = CombinePath(_envUri.ToString(), uri.ToString());

            // Use HttpWebRequest so we can get a decent response
            var wr = (HttpWebRequest)WebRequest.Create(path);
            wr.Proxy = null;

            // Construct the basic auth, if required
            if (!String.IsNullOrEmpty(_credentials)) {
                wr.Headers[HttpRequestHeader.Authorization] = _credentials;
            }
            if (!String.IsNullOrEmpty(_clientHeader)) {
                wr.Headers[Constants.AVALARA_CLIENT_HEADER] = _clientHeader;
            }

            // Convert the name-value pairs into a byte array
            wr.Method = verb.ToUpper();
            if (payload != null) {
                wr.ContentType = Constants.JSON_MIME_TYPE;
                wr.ServicePoint.Expect100Continue = false;

                // Encode the payload
                var json = JsonConvert.SerializeObject(payload, SerializerSettings);
                var encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(json);
                wr.ContentLength = data.Length;

                // Call the server
                using (var s = wr.GetRequestStream()) {
                    s.Write(data, 0, data.Length);
                    s.Close();
                }
            }

            // Transmit, and get back the response, save it to a temp file
            try {
                using (var response = wr.GetResponse()) {
                    using (var inStream = response.GetResponseStream()) {
                        using (var reader = new StreamReader(inStream)) {
                            return reader.ReadToEnd();
                        }
                    }

                }

            // Catch a web exception
            } catch (WebException webex) {
                HttpWebResponse httpWebResponse = webex.Response as HttpWebResponse;
                if (httpWebResponse != null) {
                    using (Stream stream = httpWebResponse.GetResponseStream()) {
                        using (StreamReader reader = new StreamReader(stream)) {
                            var errString = reader.ReadToEnd();
                            var err = JsonConvert.DeserializeObject<ErrorResult>(errString);
                            throw new AvaTaxError(err);
                        }
                    }
                }

                // If we can't parse it as an AvaTax error, just throw
                throw webex;
            }
        }

        private string CombinePath(string url1, string url2)
        {
            var endslash = url1.EndsWith("/");
            var startslash = url2.StartsWith("/");
            if (endslash && startslash) {
                return url1 + url2.Substring(1);
            } else if (!endslash && !startslash) {
                return url1 + "/" + url2;
            } else {
                return url1 + url2;
            }
        }
#endif

        /// <summary>
        /// Shortcut to parse a content disposition to determine attachment filename
        /// </summary>
        /// <param name="contentDisposition"></param>
        /// <returns></returns>
        private string GetDispositionFilename(string contentDisposition)
        {
            const string filename = "filename=";
            int index = contentDisposition.LastIndexOf(filename, StringComparison.OrdinalIgnoreCase);
            if (index > -1) {
                return contentDisposition.Substring(index + filename.Length);
            }
            return contentDisposition;
        }

#endregion
    }
}
