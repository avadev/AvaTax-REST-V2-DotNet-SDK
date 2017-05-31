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
        private readonly JsonSerializer _serializer;
        private string _credentials;
        private string _clientHeader;
        private Uri _envUri;
        private ILog _logger;
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

        /// <summary>
        /// Encapsulates a method that has two parameters and returns a value of the type
        /// specified by the TResult parameter.
        /// </summary>
        /// <remarks>.Net 20 does not define a Func delegate.</remarks>
        public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
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
            WithLogging(new NullLogger());

            _envUri = customEnvironment;
            
            var settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Converters.Add(new StringEnumConverter());
            _serializer = JsonSerializer.Create(settings);
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

        public AvaTaxClient WithLogging(ILog logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger", "Parameter 'logger' is null");
            }
            _logger = new DelegatingLogger(logger);
            return this;
        }
        
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

#if PORTABLE

        private async Task<T> ExecuteRestCallAsync<T>(
            string verb, AvaTaxPath relativePath, object content,
            Func<HttpResponseMessage, Task<T>> responseHandler)
        {
            CallDuration duration = new CallDuration();
            LogEntry entry = new LogEntry();
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod(verb);
                    entry.Request.Method = verb;
                    request.RequestUri = new Uri(_envUri, relativePath.ToString());
                    entry.Request.RequestUri = request.RequestUri;

                    // Add credentials and client header
                    if (_credentials != null)
                    {
                        request.Headers.Add("Authorization", _credentials);
                        entry.Request.Headers.Add("Authorization", new string('*', _credentials.Length));
                    }
                    if (_clientHeader != null)
                    {
                        request.Headers.Add(Constants.AVALARA_CLIENT_HEADER, _clientHeader);
                        entry.Request.Headers.Add(Constants.AVALARA_CLIENT_HEADER, _clientHeader);
                    }
                    if (content != null)
                    {
                        StringBuilder sb = new StringBuilder();
                        using (var textWriter = new StringWriter(sb))
                        using (var jsonWriter = new JsonTextWriter(textWriter))
                        {
                            _serializer.Serialize(jsonWriter, content);
                        }
                        // Property Encoding.UTF8 returns a UTF8Encoding object with Byte Order Mark (BOM) enabled. 
                        // In the documentation Microsoft recognize it is not needed or recommended. The BOM is unexpected
                        // by AvaTax APIs
                        // https://msdn.microsoft.com/en-us/library/system.text.utf8encoding.getpreamble(v=vs.110).aspx#Remarks
                        request.Content = new StringContent(sb.ToString(), new UTF8Encoding(false, true), "application/json");
                        entry.Request.Body = sb.ToString();
                    }

                    // Send
                    duration.FinishSetup();

                    using (var response = await _client.SendAsync(request)
                        .ConfigureAwait(false))
                    {
                        Extensions.FinishReceive(duration, response);

                        if (_logger.IsEnabled)
                        {
                            foreach (var header in response.Headers)
                            {
                                entry.Response.Headers.Add(header.Key, string.Join(", ", header.Value));
                            }
                            foreach (var header in response.Content.Headers)
                            {
                                entry.Response.Headers.Add(header.Key, string.Join(", ", header.Value));
                            }
                            entry.Response.StatusCode = (int)response.StatusCode;
                            entry.Response.Body = await response.Content.ReadAsStringAsync()
                                .ConfigureAwait(false);

                        }

                        if (response.IsSuccessStatusCode)
                        {
                            var result = await responseHandler(response)
                                .ConfigureAwait(false);

                            duration.FinishParse();
                            this.LastCallTime = duration;
                            return result;
                        }
                        var error = await BodyAsObjectAsync<ErrorResult>(response)
                            .ConfigureAwait(false);
                        duration.FinishParse();
                        this.LastCallTime = duration;
                        throw new AvaTaxError(error);
                    }
                }
            }
            catch (Exception ex)
            {
                entry.Exception = ex;
                throw;
            }
            finally
            {
                if (_logger.IsEnabled)
                {
                    entry.CallDuration = duration;
                    _logger.Write(entry);
                }
            }
        }
#endif

        private T ExecuteRestCall<T>(
            string verb, AvaTaxPath relativePath, object content,
            Func<HttpWebResponse, Stream, T> responseHandler)
        {
            CallDuration duration = new CallDuration();
            LogEntry entry = new LogEntry();
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(new Uri(_envUri, relativePath.ToString()));

                entry.Request.RequestUri = request.RequestUri;
                entry.Request.Method = verb;

                // Construct the basic auth, if required
                if (!String.IsNullOrEmpty(_credentials))
                {
                    request.Headers[HttpRequestHeader.Authorization] = _credentials;
                    entry.Request.Headers.Add("Authorization", new string('*', _credentials.Length));
                }
                if (!String.IsNullOrEmpty(_clientHeader))
                {
                    request.Headers[Constants.AVALARA_CLIENT_HEADER] = _clientHeader;
                    entry.Request.Headers.Add(Constants.AVALARA_CLIENT_HEADER, _clientHeader);
                }
                request.Method = verb;

#if NET20 || NET45
                request.ServicePoint.Expect100Continue = false;
#endif
                if (content != null)
                {
                    if (_logger.IsEnabled)
                    {
                        StringBuilder sb = new StringBuilder();
                        using (var textWriter = new StringWriter(sb))
                        using (var jsonWriter = new JsonTextWriter(textWriter))
                        {
                            _serializer.Serialize(jsonWriter, content);
                        }
                        entry.Request.Body = sb.ToString();
                    }
                    request.ContentType = "application/json; charset=utf-8";

                    using (var stream =
#if PORTABLE && !NET45
                        // The PCL profile does not provide a GetRequestStream and because it is bad 
                        // practice to block when using the Event-based Asynchronous (EAP) Pattern with
                        // .Wait(), .Result, or .GetAwaiter().GetResult() due to deadlock issues in 
                        // UI and ASP.Net contexts it is necessary to rely on the Asynchronous 
                        // Programming Model (APM) Pattern to ensure deadlocks are not encountered. 
                        // 
                        // Explains why blocking is undesirable with async/await. (https://msdn.microsoft.com/en-us/magazine/mt238404)
                        // Provides a set of best practices for async/await. (https://msdn.microsoft.com/magazine/jj991977)
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
                        _serializer.Serialize(writer, content);
                    }
                }

                duration.FinishSetup();

                using (var response =
#if PORTABLE && !NET45
                    // The PCL profile does not provide a GetRequestStream and because it is bad 
                    // practice to block when using the Event-based Asynchronous (EAP) Pattern with
                    // .Wait(), .Result, or .GetAwaiter().GetResult() due to deadlock issues in 
                    // UI and ASP.Net contexts it is necessary to rely on the Asynchronous 
                    // Programming Model (APM) Pattern to ensure deadlocks are not encountered. 
                    // 
                    // Explains why blocking is undesirable with async/await. (https://msdn.microsoft.com/en-us/magazine/mt238404)
                    // Provides a set of best practices for async/await. (https://msdn.microsoft.com/magazine/jj991977)
                    // Explains what SynchronizationContexts are. (https://msdn.microsoft.com/en-us/magazine/gg598924.aspx)
                    new Synchronously<HttpWebRequest, object, HttpWebResponse>(
                            request.BeginGetResponse, ResponseCallback)
                        .Execute(request, null)
#else
                    (HttpWebResponse)request.GetResponse()
#endif
                    )
                {
                    Extensions.FinishReceive(duration, response);
                    byte[] body = null;
                    using (Stream stream = response.GetResponseStream())
                    {
                        body = Extensions.ReadToEnd(stream);
                    }

                    if (_logger.IsEnabled)
                    {
                        foreach (string header in response.Headers.AllKeys)
                        {
                            string value = response.Headers[header];
                            entry.Response.Headers.Add(header, value);
                        }
                        entry.Response.StatusCode = (int)response.StatusCode;
                        using (var stream = new MemoryStream(body, 0, body.Length, false))
                        {
                            entry.Response.Body = BodyAsString(response, stream);
                        }
                    }

                    if (Extensions.IsSuccessStatusCode(response))
                    {
                        T result;
                        using (var stream = new MemoryStream(body, 0, body.Length, false))
                        {
                            result = responseHandler(response, stream);
                        }
                        duration.FinishParse();
                        this.LastCallTime = duration;
                        return result;
                    }
                    ErrorResult error;
                    using (var stream = new MemoryStream(body, 0, body.Length, false))
                    {
                        error = BodyAsObject<ErrorResult>(response, stream);
                    }

                    duration.FinishParse();
                    this.LastCallTime = duration;
                    throw new AvaTaxError(error);

                }
            }
            catch (WebException webex)
            {
                HttpWebResponse response = webex.Response as HttpWebResponse;
                if (response != null)
                {
                    ErrorResult error = null;
                    using (Stream stream = response.GetResponseStream())
                    {
                        error = BodyAsObject<ErrorResult>(response, stream);
                    }

                    duration.FinishParse();
                    this.LastCallTime = duration;
                    var exception = new AvaTaxError(error, webex);
                    entry.Exception = exception;
                    throw exception;
                }

                duration.FinishParse();
                this.LastCallTime = duration;

                entry.Exception = webex;
                // If we can't parse it as an AvaTax error, just throw
                // use throw instead of throw ex. This ensures the call stack is not reset in the exception.
                throw;
            }
            catch (Exception ex)
            {
                entry.Exception = ex;
                throw;
            }
            finally
            {
                if (_logger.IsEnabled)
                {
                    entry.CallDuration = duration;
                    _logger.Write(entry);
                }
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
        private static T BodyAsObject<T>(HttpWebResponse response, Stream body)
        {

            using (var reader = new StreamReader(body, new UTF8Encoding(false, true)))
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
        private static FileResult BodyAsFile(HttpWebResponse response, Stream body)
        {

            return new FileResult()
            {
                ContentType = response.Headers["Content-Type"].ToString(),
                Filename = GetDispositionFilename(response.Headers["Content-Disposition"].ToString()),
                Data = Extensions.ReadToEnd(body)
            };
        }

#if PORTABLE
        private static async Task<string> BodyAsStringAsync(HttpResponseMessage response)
        {
            return await response.Content.ReadAsStringAsync();
        }
#endif
        private static string BodyAsString(HttpWebResponse response, Stream body)
        {
            using (var reader = new StreamReader(body, new UTF8Encoding(false, true)))
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
