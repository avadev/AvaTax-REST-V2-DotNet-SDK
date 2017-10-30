using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
#if PORTABLE
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
#endif
using System.Text;


namespace Avalara.AvaTax.RestClient
{
    internal static class Extensions
    {
#if PORTABLE
        /// <summary>
        /// Call this when the API call has returned all its results
        /// </summary>
        internal static void FinishReceive(CallDuration callDuration, HttpResponseMessage response)
        {
            TimeSpan serverDuration = TimeSpan.Zero;
            IEnumerable<string> headers;
            if (response.Headers.TryGetValues("serverduration", out headers) && headers != null)
            {
                string rawServerDuration = headers.FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(rawServerDuration))
                {

                    TimeSpan.TryParse(rawServerDuration, out serverDuration);
                }
            }
            callDuration.FinishReceive(serverDuration);
        }
#endif
        internal static void FinishReceive(CallDuration callDuration, HttpWebResponse response)
        {
            TimeSpan serverDuration = TimeSpan.Zero;

#if PORTABLE && !NET45
            string rawServerDuration = response.Headers["serverduration"];
            if (!IsNullOrWhiteSpace(rawServerDuration))
            {
                TimeSpan.TryParse(rawServerDuration, out serverDuration);
            }
#else


            string[] headers = response.Headers.GetValues("serverduration");
            if (headers != null && headers.Length > 0)
            {
                string rawServerDuration = headers[0];
                if (!IsNullOrWhiteSpace(rawServerDuration))
                {
                    TimeSpan.TryParse(rawServerDuration, out serverDuration);
                }
            }
#endif
            callDuration.FinishReceive(serverDuration);
        }


        private static bool IsNullOrWhiteSpace(String value)
        {
            if (value == null) return true;

            for (int i = 0; i < value.Length; i++)
            {
                if (!Char.IsWhiteSpace(value[i])) return false;
            }

            return true;
        }

        internal static byte[] ReadToEnd(Stream body)
        {
            const int BUFFER_SIZE = 1024;
            var chunks = new List<byte>();
            var totalBytes = 0;
            var bytesRead = 0;

            do
            {
                var buffer = new byte[BUFFER_SIZE];
                bytesRead = body.Read(buffer, 0, BUFFER_SIZE);
                if (bytesRead == BUFFER_SIZE)
                {
                    chunks.AddRange(buffer);
                }
                else
                {
                    for (int i = 0; i < bytesRead; i++)
                    {
                        chunks.Add(buffer[i]);
                    }
                }
                totalBytes += bytesRead;
            } while (bytesRead > 0);
            var data = chunks.ToArray();
            return data;
        }


        internal static bool IsSuccessStatusCode(HttpWebResponse response)
        {
            // This matches the implementation used by HttpResponseMessage
            // https://stackoverflow.com/a/32570068/4275730
            return ((int)response.StatusCode >= 200) && ((int)response.StatusCode <= 299);
        }
    }
}
