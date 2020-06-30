using System;
using System.Collections.Generic;
using System.Text;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Constants for AvaTax standard values
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// The standard client header for AvaTax API calls
        /// </summary>
        public static readonly string AVALARA_CLIENT_HEADER = "X-Avalara-Client";

        /// <summary>
        /// Mime type for JSON
        /// </summary>
        public static readonly string JSON_MIME_TYPE = "application/json";        

        /// <summary>
        /// Official URL of AvaTax (Sandbox)
        /// </summary>
        public static readonly string AVATAX_SANDBOX_URL = "https://sandbox-rest.avatax.com";

        /// <summary>
        /// Official URL of AvaTax (Production)
        /// </summary>
        public static readonly string AVATAX_PRODUCTION_URL = "https://rest.avatax.com";
    }
}
