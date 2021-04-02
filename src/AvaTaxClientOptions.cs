using System;
#if PORTABLE
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
#endif

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Configuration options for the <see cref="AvaTaxClient"/>
    /// </summary>
    public class AvaTaxClientOptions
    {
        /// <summary>
        /// The request timeout.
        /// </summary>
        public TimeSpan? Timeout { get; set; }
    }
}
