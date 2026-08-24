using Avalara.AvaTax.RestClient;
using NUnit.Framework;
using System;

namespace Avalara.AvaTax.RestClient.Test.net20
{
    /// <summary>
    /// Logs failing API calls to the test output.
    ///
    /// AvaTaxError does not override Exception.Message, so NUnit reports an
    /// uncaught one as "Exception of type 'AvaTaxError' was thrown" with nothing
    /// about what the API actually said. Hooking the client's CallCompleted event
    /// puts the verb, URL, status, correlation ID and response body in the log for
    /// every failed call, without changing the SDK or the tests' own logic.
    /// </summary>
    internal static class ApiCallLog
    {
        /// <summary>
        /// Longest request or response body to log, in characters.
        /// </summary>
        private const int BodyLimit = 2000;

        /// <summary>
        /// Log every call this client makes that comes back 400 or worse.
        /// </summary>
        /// <param name="client">Client to watch. Ignored when null.</param>
        public static void Attach(AvaTaxClient client)
        {
            if (client == null)
            {
                return;
            }

            client.CallCompleted += (sender, e) =>
            {
                var args = e as AvaTaxCallEventArgs;
                if (args == null || (int)args.Code < 400)
                {
                    return;
                }

                try
                {
                    TestContext.Progress.WriteLine($"API {args.HttpVerb} {args.RequestUri} -> "
                        + $"{(int)args.Code} ({args.Code}); X-Correlation-Id: {args.XCorrelationId}");
                    TestContext.Progress.WriteLine("  request:  " + Trim(args.RequestBody));
                    TestContext.Progress.WriteLine("  response: " + Trim(args.ResponseString));
                }
                catch (Exception)
                {
                    // Logging must never be the reason a test fails.
                }
            };
        }

        /// <summary>
        /// Describe an AvaTaxError for use as an assertion message.
        /// </summary>
        /// <param name="error">Error to describe.</param>
        public static string Describe(AvaTaxError error)
        {
            if (error == null)
            {
                return "no error";
            }

            return $"HTTP {(int)error.statusCode} ({error.statusCode}); "
                + $"X-Correlation-Id: {error.XCorrelationId}; "
                + (error.error == null ? "no error body" : error.error.ToString());
        }

        private static string Trim(string body)
        {
            if (String.IsNullOrEmpty(body))
            {
                return "(empty)";
            }

            return body.Length <= BodyLimit ? body : body.Substring(0, BodyLimit) + "... (truncated)";
        }
    }
}
