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
        private string _credentials;
        private string _clientHeader;
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

        /// <summary>
        /// Encapsulates a method that has one parameter and returns a value of the type
        /// specified by the TResult parameter.To browse the .NET Framework source code for
        /// this type, see the Reference Source.
        /// </summary>
        /// <remarks>.Net 20 does not define a Func delegate.</remarks>
        public delegate TResult Func<in T, out TResult>(T arg);
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
            : this(appName, appVersion, machineName, GetEnvironmentEnpoint(environment))
        { }

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


        private static Uri GetEnvironmentEnpoint(AvaTaxEnvironment environment)
        {
            // Setup the URI
            switch (environment)
            {
                case AvaTaxEnvironment.Sandbox: return new Uri(Constants.AVATAX_SANDBOX_URL);
                case AvaTaxEnvironment.Production: return new Uri(Constants.AVATAX_PRODUCTION_URL);
                default: throw new Exception("Unrecognized Environment");
            }
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
            return await ExecuteRestCallAsync(verb, relativePath, content, BodyAsObjectAsync<T>)
                .ConfigureAwait(false);
        }

#endif
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
            return ExecuteRestCall<T>(verb, relativePath, content, BodyAsObject<T>);
        }


#if PORTABLE
        public async Task<FileResult> RestCallFileAsync(string verb, AvaTaxPath relativePath, object payload = null)
        {
            return await ExecuteRestCallAsync<FileResult>(verb, relativePath, payload, BodyAsFileAsync)
                .ConfigureAwait(false);
        }

#endif

        /// <summary>
        /// Non-async method for downloading a file
        /// </summary>
        /// <param name="verb"></param>
        /// <param name="relativePath"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public FileResult RestCallFile(string verb, AvaTaxPath relativePath, object payload = null)
        {
            return ExecuteRestCall(verb, relativePath, payload, BodyAsFile);
        }

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

        private async Task<T> ExecuteRestCallAsync<T>(
            string verb, AvaTaxPath relativePath, object content,
            Func<HttpResponseMessage, Task<T>> responseHandler)
        {
            CallDuration cd = new CallDuration();
            // Setup the request
            using (var request = new HttpRequestMessage())
            {
                request.Method = new HttpMethod(verb);
                request.RequestUri = new Uri(_envUri, relativePath.ToString());

                // Add credentials and client header
                if (_credentials != null)
                {
                    request.Headers.Add("Authorization", _credentials);
                }
                if (_clientHeader != null)
                {
                    request.Headers.Add("X-Avalara-Client", _clientHeader);
                }

                // Add payload
                if (content != null)
                {
                    var json = JsonConvert.SerializeObject(content, SerializerSettings);

                    // Property Encoding.UTF8 returns a UTF8Encoding object with Byte Order Mark (BOM) enabled. 
                    // In the documentation Microsoft recognize it is not needed or recommended. The BOM is unexpected
                    // by AvaTax APIs
                    // https://msdn.microsoft.com/en-us/library/system.text.utf8encoding.getpreamble(v=vs.110).aspx#Remarks
                    request.Content = new StringContent(json, new UTF8Encoding(false, true), "application/json");
                }

                // Send
                cd.FinishSetup();

                using (var response = await _client.SendAsync(request)
                    .ConfigureAwait(false))
                {
                    Extensions.FinishReceive(cd, response);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await responseHandler(response)
                            .ConfigureAwait(false);

                        cd.FinishParse();
                        this.LastCallTime = cd;
                        return result;
                    }


                    var s = await response.Content.ReadAsStringAsync()
                        .ConfigureAwait(false);
                    var err = JsonConvert.DeserializeObject<ErrorResult>(s);
                    cd.FinishParse();
                    this.LastCallTime = cd;
                    throw new AvaTaxError(err);
                }
            }
        }
#endif

        private T ExecuteRestCall<T>(
            string verb, AvaTaxPath relativePath, object content,
            Func<HttpWebResponse, T> responseHandler)
        {
            CallDuration cd = new CallDuration();

            var request = (HttpWebRequest)WebRequest.Create(new Uri(_envUri, relativePath.ToString()));

            // Construct the basic auth, if required
            if (!String.IsNullOrEmpty(_credentials))
            {
                request.Headers[HttpRequestHeader.Authorization] = _credentials;
            }
            if (!String.IsNullOrEmpty(_clientHeader))
            {
                request.Headers[Constants.AVALARA_CLIENT_HEADER] = _clientHeader;
            }
            request.Method = verb;

            if (content != null)
            {
                request.ContentType = "application/json; charset=utf-8";
#if NET20 || NET45
                request.ServicePoint.Expect100Continue = false;
#endif

                using (var stream =
#if PORTABLE && !NET45
                // The PCL profile does not provide a GetRequestStream and because it is bad 
                // practice to block when using the Event-based Asynchronous (EAP) Pattern with
                // .Wait(), .Result, or .GetAwaiter().GetResult() due to deadlock issues in 
                // UI and ASP.Net contexts it is necessary to rely on the Asynchronous 
                // Programming Model (APM) Pattern to ensure deadlocks are not encountered. 
                // 
                // Explains why blocking using .Result is undesirable. (https://msdn.microsoft.com/en-us/magazine/mt238404)
                // Provides a set of Best Practices for async/await. (https://msdn.microsoft.com/magazine/jj991977)
                // Explains what SynchronizationContexts are. (https://msdn.microsoft.com/en-us/magazine/gg598924.aspx)
                new Synchronously<HttpWebRequest, object, Stream>(request.BeginGetRequestStream, RequestStreamCallback)
                    .Execute(request, null)
#else
                request.GetRequestStream()
#endif
                )
                // Property Encoding.UTF8 returns a UTF8Encoding object with Byte Order Mark (BOM) enabled. 
                // In the documentation Microsoft recognize it is not needed or recommended. The BOM is unexpected
                // by AvaTax APIs
                // https://msdn.microsoft.com/en-us/library/system.text.utf8encoding.getpreamble(v=vs.110).aspx#Remarks
                using (var writer = new StreamWriter(stream, new UTF8Encoding(false, true)))
                {
                    JsonSerializer serializer = JsonSerializer.Create(SerializerSettings);
                    serializer.Serialize(writer, content);
                    writer.Flush();
                    stream.Flush();
                }
            }

            cd.FinishSetup();

            try
            {
                using (var response =
#if PORTABLE && !NET45
                    // The PCL profile does not provide a GetRequestStream and because it is bad 
                    // practice to block when using the Event-based Asynchronous (EAP) Pattern with
                    // .Wait(), .Result, or .GetAwaiter().GetResult() due to deadlock issues in 
                    // UI and ASP.Net contexts it is necessary to rely on the Asynchronous 
                    // Programming Model (APM) Pattern to ensure deadlocks are not encountered. 
                    // 
                    // Explains why blocking using .Result is undesirable. (https://msdn.microsoft.com/en-us/magazine/mt238404)
                    // Provides a set of Best Practices for async/await. (https://msdn.microsoft.com/magazine/jj991977)
                    // Explains what SynchronizationContexts are. (https://msdn.microsoft.com/en-us/magazine/gg598924.aspx)
                    new Synchronously<HttpWebRequest, object, HttpWebResponse>(
                            request.BeginGetResponse, ResponseCallback)
                        .Execute(request, null)
#else
                    (HttpWebResponse)request.GetResponse()
#endif
                    )
                {
                    Extensions.FinishReceive(cd, response);

                    if (Extensions.IsSuccessStatusCode(response))
                    {
                        var result = responseHandler(response);

                        cd.FinishParse();
                        this.LastCallTime = cd;
                        return result;
                    }

                    using (var stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        var err = serializer.Deserialize<ErrorResult>(jsonReader);
                        cd.FinishParse();
                        this.LastCallTime = cd;
                        throw new AvaTaxError(err);
                    }
                }
            }
            catch (WebException webex)
            {
                HttpWebResponse response = webex.Response as HttpWebResponse;
                if (response != null)
                {
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var errString = reader.ReadToEnd();
                        var err = JsonConvert.DeserializeObject<ErrorResult>(errString);
                        cd.FinishParse();
                        this.LastCallTime = cd;
                        throw new AvaTaxError(err);
                    }
                }

                cd.FinishParse();
                this.LastCallTime = cd;

                // If we can't parse it as an AvaTax error, just throw
                // use throw instead of throw ex. This ensures the call stack is not reset in the exception.
                throw;
            }
        }


#if PORTABLE && !NET45

        /// <summary>
        /// The callback method executed when getting the request stream.
        /// </summary>
        /// <param name="state"></param>
        private Stream RequestStreamCallback(State<HttpWebRequest, object> state)
        {
            return state.Sender.EndGetRequestStream(state.AsynchronousResult);
        }

        /// <summary>
        /// The callback method executed when getting the response
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private HttpWebResponse ResponseCallback(State<HttpWebRequest, object> state)
        {
            return (HttpWebResponse)state.Sender.EndGetResponse(state.AsynchronousResult);
        }
#endif

#if PORTABLE
        private static async Task<T> BodyAsObjectAsync<T>(HttpResponseMessage response)
        {
            using (var body = await response.Content.ReadAsStreamAsync()
                .ConfigureAwait(false))
            using (var reader = new System.IO.StreamReader(body))
            using (var jsonReader = new JsonTextReader(reader))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<T>(jsonReader);
            }
        }
#endif

        private static T BodyAsObject<T>(HttpWebResponse response)
        {
            using (var body = response.GetResponseStream())
            using (var reader = new System.IO.StreamReader(body))
            using (var jsonReader = new JsonTextReader(reader))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<T>(jsonReader);
            }
        }

#if PORTABLE
        private static async Task<FileResult> BodyAsFileAsync(HttpResponseMessage response)
        {
            return new FileResult()
            {
                ContentType = response.Content.Headers.GetValues("Content-Type").FirstOrDefault(),
                Filename = GetDispositionFilename(response.Content.Headers.GetValues("Content-Disposition").FirstOrDefault()),
                Data = await response.Content.ReadAsByteArrayAsync()
                    .ConfigureAwait(false)
            };
        }
#endif
        private static FileResult BodyAsFile(HttpWebResponse response)
        {
            using (var body = response.GetResponseStream())
            {
                byte[] data = Extensions.ReadToEnd(body);
                return new FileResult()
                {
                    ContentType = response.Headers["Content-Type"].ToString(),
                    Filename = GetDispositionFilename(response.Headers["Content-Disposition"].ToString()),
                    Data = data
                };

            }
        }
#if PORTABLE

        private static async Task<string> BodyAsStringAsync(HttpResponseMessage response)
        {
            return await response.Content.ReadAsStringAsync();
        }
#endif

        private static string BodyAsString(HttpWebResponse response)
        {
            using (var body = response.GetResponseStream())
            using (var reader = new StreamReader(body))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Shortcut to parse a content disposition to determine attachment filename
        /// </summary>
        /// <param name="contentDisposition"></param>
        /// <returns></returns>
        private static string GetDispositionFilename(string contentDisposition)
        {
            const string filename = "filename=";
            int index = contentDisposition.LastIndexOf(filename, StringComparison.OrdinalIgnoreCase);
            if (index > -1)
            {
                return contentDisposition.Substring(index + filename.Length);
            }
            return contentDisposition;
        }

        #endregion
    }
}
