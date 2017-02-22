using System;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// ErrorTargetCode
    /// </summary>
    public enum ErrorTargetCode
    {
        /// <summary>
        /// 
        /// </summary>
        Unknown,

        /// <summary>
        /// 
        /// </summary>
        HttpRequest,

        /// <summary>
        /// 
        /// </summary>
        HttpRequestHeaders,

        /// <summary>
        /// 
        /// </summary>
        IncorrectData,

        /// <summary>
        /// 
        /// </summary>
        AvaTaxApiServer,

        /// <summary>
        /// 
        /// </summary>
        AvalaraIdentityServer,

        /// <summary>
        /// 
        /// </summary>
        CustomerAccountSetup,

    }
}