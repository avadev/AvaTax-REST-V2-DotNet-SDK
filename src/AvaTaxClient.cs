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
    public partial class AvaTaxClient
    {
        private Dictionary<string, string> _clientHeaders = new Dictionary<string, string>();
        private Uri _envUri;
#if PORTABLE
        private static HttpClient _client = new HttpClient();
#endif

        /// <summary>
        /// Tracks the amount of time spent on the most recent API call
        /// </summary>
        public CallDuration LastCallTime { get; set; }

        /// <summary>
        /// Returns the version of the SDK that was compiled
        /// </summary>
#if NET45
        public static string SDK_TYPE { get { return "NET45"; } }
#endif
#if NETSTANDARD1_6
        public static string SDK_TYPE { get { return "NETSTANDARD1_6"; } }
#endif
#if NET20
        public static string SDK_TYPE { get { return "NET20"; } }
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
        }
#endregion

#region Security
        /// <summary>
        /// Sets the default security header string
        /// </summary>
        /// <param name="headerString"></param>
        public AvaTaxClient WithSecurity(string headerString)
        {
            return WithCustomHeader("Authorization", headerString);
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

        #region Custom headers
        /// <summary>
        /// Add custom header to this client.
        /// </summary>
        /// <param name="name">Name of header.</param>
        /// <param name="value">Value of header.</param>
        /// <returns></returns>
        public AvaTaxClient WithCustomHeader(string name, string value)
        {
            if (_clientHeaders.ContainsKey(name))
            {
                _clientHeaders[name] = value;
            }
            else
            {
                _clientHeaders.Add(name, value);
            }
            return this;
        }
        #endregion

        #region Client Identification
        /// <summary>
        /// Configure client identification
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="appVersion"></param>
        /// <param name="machineName"></param>
        /// <returns></returns>
        public AvaTaxClient WithClientIdentifier(string appName, string appVersion, string machineName)
        {
            _clientHeaders.Add(Constants.AVALARA_CLIENT_HEADER, String.Format("{0}; {1}; {2}; {3}; {4}", appName, appVersion, "CSharpRestClient", API_VERSION, machineName));
            return this;
        }
#endregion

#region REST Call Interface
#if PORTABLE
        /// <summary>
        /// Implementation of asynchronous client APIs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="verb"></param>
        /// <param name="relativePath"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<T> RestCallAsync<T>(string verb, AvaTaxPath relativePath, object content = null)
        {
            CallDuration cd = new CallDuration();
            var s = await RestCallStringAsync(verb, relativePath, content, cd).ConfigureAwait(false);
            var o = JsonConvert.DeserializeObject<T>(s);
            cd.FinishParse();
            this.LastCallTime = cd;
            return o;
        }


        /// <summary>
        /// Direct implementation of client APIs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="verb"></param>
        /// <param name="relativePath"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public T RestCall<T>(string verb, AvaTaxPath relativePath, object content = null)
        {
            try {
                return RestCallAsync<T>(verb, relativePath, content).Result;

            // Unroll single-exception aggregates for ease of use
            } catch (AggregateException ex) {
                if (ex.InnerExceptions.Count == 1) {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }

        /// <summary>
        /// Non-async method for downloading a file
        /// </summary>
        /// <param name="verb"></param>
        /// <param name="relativePath"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public FileResult RestCallFile(string verb, AvaTaxPath relativePath, object payload = null)
        {
            try
            {
                return RestCallFileAsync(verb, relativePath, payload).Result;

                // Unroll single-exception aggregates for ease of use
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count == 1)
                {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }
#endif
#endregion

#region Implementation
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
        /// Implementation of raw file-returning async API 
        /// </summary>
        /// <param name="verb"></param>
        /// <param name="relativePath"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private async Task<FileResult> RestCallFileAsync(string verb, AvaTaxPath relativePath, object content = null)
        {
            CallDuration cd = new CallDuration();

            // Convert the JSON payload, if any
            string jsonPayload = null;
            if (content != null) {
                jsonPayload = JsonConvert.SerializeObject(content, SerializerSettings);
            }

            // Call REST
            using (var result = await InternalRestCallAsync(cd, verb, relativePath, jsonPayload).ConfigureAwait(false)) {

                // Read the result
                if (result.IsSuccessStatusCode) {
                    var fr = new FileResult()
                    {
                        ContentType = result.Content.Headers.GetValues("Content-Type").FirstOrDefault(),
                        Filename = GetDispositionFilename(result.Content.Headers.GetValues("Content-Disposition").FirstOrDefault()),
                        Data = await result.Content.ReadAsByteArrayAsync().ConfigureAwait(false)
                    };

                    // Capture timings
                    cd.FinishParse();
                    this.LastCallTime = cd;

                    // Capture information about this API call and make it available for logging
                    var eventargs = new AvaTaxCallEventArgs() { HttpVerb = verb.ToUpper(), Code = result.StatusCode, RequestUri = new Uri(_envUri, relativePath.ToString()), RequestBody = jsonPayload, ResponseBody = fr.Data, Duration = cd };
                    OnCallCompleted(eventargs);
                    return fr;

                // Handle exceptions and convert them to AvaTax results
                } else {
                    var errorResponseString = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var err = JsonConvert.DeserializeObject<ErrorResult>(errorResponseString);
                    cd.FinishParse();
                    this.LastCallTime = cd;

                    // Capture information about this API call error and make it available for logging
                    var eventargs = new AvaTaxCallEventArgs() { HttpVerb = verb.ToUpper(), Code = result.StatusCode, RequestUri = new Uri(_envUri, relativePath.ToString()), RequestBody = jsonPayload, ResponseString = errorResponseString, Duration = cd };
                    OnCallCompleted(eventargs);
                    throw new AvaTaxError(err, result.StatusCode);
                }
            }
        }

        /// <summary>
        /// Implementation of raw request API
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="verb"></param>
        /// <param name="relativePath"></param>
        /// <param name="jsonPayload"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> InternalRestCallAsync(CallDuration cd, string verb, AvaTaxPath relativePath, string jsonPayload)
        {
            // Setup the request
            using (var request = new HttpRequestMessage()) {
                request.Method = new HttpMethod(verb);
                request.RequestUri = new Uri(_envUri, relativePath.ToString());

                // Add headers
                foreach (var key in _clientHeaders.Keys)
                {
                    request.Headers.Add(key, _clientHeaders[key]);
                }

                // Add payload
                if (jsonPayload != null) {
                    request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                }

                // Send
                cd.FinishSetup();
                return await _client.SendAsync(request).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Implementation of raw string-returning async API 
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="verb"></param>
        /// <param name="relativePath"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private async Task<string> RestCallStringAsync(string verb, AvaTaxPath relativePath, object content = null, CallDuration cd = null)
        {
            if (cd == null) cd = new CallDuration();

            // Convert the JSON payload, if any
            string jsonPayload = null;
            if (content != null) {
                jsonPayload = JsonConvert.SerializeObject(content, SerializerSettings);
            }

            // Call REST
            using (var result = await InternalRestCallAsync(cd, verb, relativePath, jsonPayload).ConfigureAwait(false)) {

                // Read the result
                var responseString = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

                // Determine server duration
                var sd = DetectDuration(result, "serverduration");
                var dd = DetectDuration(result, "dataduration");
                var td = DetectDuration(result, "serviceduration");
                cd.FinishReceive(sd, dd, td);

                // Capture information about this API call and make it available for logging
                var eventargs = new AvaTaxCallEventArgs() { HttpVerb = verb.ToUpper(), Code = result.StatusCode, RequestUri = new Uri(_envUri, relativePath.ToString()), RequestBody = jsonPayload, ResponseString = responseString, Duration = cd };
                OnCallCompleted(eventargs);

                // Deserialize the result
                if (result.IsSuccessStatusCode) {
                    return responseString;
                } else {
                    var err = JsonConvert.DeserializeObject<ErrorResult>(responseString);
                    cd.FinishParse();
                    this.LastCallTime = cd;
                    throw new AvaTaxError(err, result.StatusCode);
                }
            }
        }
        private TimeSpan? DetectDuration(HttpResponseMessage result, string name)
        {
            IEnumerable<string> values = null;
            if (result.Headers.TryGetValues(name, out values)) {
                var firstHeader = values.FirstOrDefault();
                if (firstHeader != null) {
                    TimeSpan duration = default(TimeSpan);
                    if (TimeSpan.TryParse(firstHeader, out duration)) {
                        return duration;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Implementation of raw string-returning API
        /// </summary>
        /// <param name="verb"></param>
        /// <param name="relativePath"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private string RestCallString(string verb, AvaTaxPath relativePath, object content = null)
        {
            try
            {
                return RestCallStringAsync(verb, relativePath, content).Result;
                // Unroll single-exception aggregates for ease of use
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count == 1)
                {
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
        /// <param name="relativePath"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private T RestCall<T>(string verb, AvaTaxPath relativePath, object content = null)
        {
            var s = RestCallString(verb, relativePath, content);
            return JsonConvert.DeserializeObject<T>(s);
        }

        /// <summary>
        /// Direct implementation of client APIs to string values
        /// </summary>
        /// <param name="verb"></param>
        /// <param name="relativePath"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private FileResult RestCallFile(string verb, AvaTaxPath relativePath, object content = null)
        {
            string path = CombinePath(_envUri.ToString(), relativePath.ToString());
            string jsonPayload = null;

            // Use HttpWebRequest so we can get a decent response
            var wr = (HttpWebRequest)WebRequest.Create(path);
            wr.Proxy = null;

            // Add headers
            foreach (var key in _clientHeaders.Keys)
            {
                wr.Headers.Add(key, _clientHeaders[key]);
            }

            // Convert the name-value pairs into a byte array
            wr.Method = verb;
            if (content != null) {
                wr.ContentType = Constants.JSON_MIME_TYPE;
                wr.ServicePoint.Expect100Continue = false;

                // Encode the payload
                jsonPayload = JsonConvert.SerializeObject(content, SerializerSettings);
                var encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(jsonPayload);
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
                        var fr = new FileResult()
                        {
                            ContentType = response.Headers["Content-Type"].ToString(),
                            Filename = GetDispositionFilename(response.Headers["Content-Disposition"].ToString()),
                            Data = chunks.ToArray()
                        };

                        // Track the API call
                        var eventargs = new AvaTaxCallEventArgs() { Code = ((HttpWebResponse)response).StatusCode, Duration = null, HttpVerb = wr.Method, RequestBody = jsonPayload, ResponseBody = fr.Data, RequestUri = new Uri(path) };
                        OnCallCompleted(eventargs);
                        return fr;
                    }
                }

                // Catch a web exception
            } catch (WebException webex) {
                HttpWebResponse httpWebResponse = webex.Response as HttpWebResponse;
                if (httpWebResponse != null) {
                    using (Stream stream = httpWebResponse.GetResponseStream()) {
                        using (StreamReader reader = new StreamReader(stream)) {
                            var errString = reader.ReadToEnd();

                            // Track the API call
                            var eventargs = new AvaTaxCallEventArgs() { Code = ((HttpWebResponse)httpWebResponse).StatusCode, Duration = null, HttpVerb = wr.Method, RequestBody = jsonPayload, ResponseString = errString, RequestUri = new Uri(path) };
                            OnCallCompleted(eventargs);

                            // Pass on the error
                            var err = JsonConvert.DeserializeObject<ErrorResult>(errString);
                            throw new AvaTaxError(err, httpWebResponse.StatusCode);
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
        /// <param name="relativePath"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private string RestCallString(string verb, AvaTaxPath relativePath, object content = null)
        {
            string path = CombinePath(_envUri.ToString(), relativePath.ToString());
            string jsonPayload = null;

            // Use HttpWebRequest so we can get a decent response
            var wr = (HttpWebRequest)WebRequest.Create(path);
            wr.Proxy = null;

            // Add headers
            foreach (var key in _clientHeaders.Keys)
            {
                wr.Headers.Add(key, _clientHeaders[key]);
            }

            // Convert the name-value pairs into a byte array
            wr.Method = verb;
            if (content != null) {
                wr.ContentType = Constants.JSON_MIME_TYPE;
                wr.ServicePoint.Expect100Continue = false;

                // Encode the payload
                jsonPayload = JsonConvert.SerializeObject(content, SerializerSettings);
                var encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(jsonPayload);
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
                            var responseString = reader.ReadToEnd();

                            // Track the API call
                            var eventargs = new AvaTaxCallEventArgs() { Code = ((HttpWebResponse)response).StatusCode, Duration = null, HttpVerb = wr.Method, RequestBody = jsonPayload, ResponseString = responseString, RequestUri = new Uri(path) };
                            OnCallCompleted(eventargs);

                            // Here's the results
                            return responseString;
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

                            // Track the API call
                            var eventargs = new AvaTaxCallEventArgs() { Code = ((HttpWebResponse)httpWebResponse).StatusCode, Duration = null, HttpVerb = wr.Method, RequestBody = jsonPayload, ResponseString = errString, RequestUri = new Uri(path) };
                            OnCallCompleted(eventargs);

                            // Here's the results
                            var err = JsonConvert.DeserializeObject<ErrorResult>(errString);
                            throw new AvaTaxError(err, httpWebResponse.StatusCode);
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

        #region Logging
        /// <summary>
        /// Hook this event to capture information about API calls
        /// </summary>
        public event EventHandler CallCompleted;

        /// <summary>
        /// Call this function to trigger notification
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCallCompleted(EventArgs e)
        {
            CallCompleted?.Invoke(this, e);
        }

        /// <summary>
        /// Enable logging to a file
        /// </summary>
        /// <param name="logFileName"></param>
        public void LogToFile(string logFileName)
        {
            _logFileName = logFileName;
            CallCompleted += LogFile_CallCompleted;
        }

        private string _logFileName = null;
        private void LogFile_CallCompleted(object sender, EventArgs e)
        {
            var evt = e as AvaTaxCallEventArgs;

            // Write to disk
            var g = Guid.NewGuid().ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append($"=== REQUEST {g}: {evt.HttpVerb} {evt.RequestUri.ToString()} Timestamp: {DateTime.UtcNow} ===\r\n{evt.RequestBody}\r\n");
            if (evt.ResponseString != null) {
                sb.Append($"=== RESPONSE {g}: {evt.Code} Type: JSON ===\r\n{evt.ResponseString}\r\n=== END {g} ===\r\n");
            } else {
                sb.Append($"=== RESPONSE {g}: {evt.Code} Type: FILE ===\r\n{evt.ResponseBody?.Length} bytes\r\n=== END {g} ===\r\n");
            }
            File.AppendAllText(_logFileName, sb.ToString(), Encoding.UTF8);
        }
        #endregion
    }
}
