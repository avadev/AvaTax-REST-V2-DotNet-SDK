using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// What object experienced the error?
    /// </summary>
    public enum ErrorTargetCode
    {
        /// <summary>
        /// Error target is unknown
        /// </summary>
        Unknown,

        /// <summary>
        /// There was an error in the request URL, querystring, or body
        /// </summary>
        HttpRequest,

        /// <summary>
        /// There was an error in the HTTP Request headers
        /// </summary>
        HttpRequestHeaders,

        /// <summary>
        /// Some data provided by the user was incorrect
        /// </summary>
        IncorrectData,

        /// <summary>
        /// There was an error in the AvaTax API Server
        /// </summary>
        AvaTaxApiServer,

        /// <summary>
        /// There was an error in the Avalara Identity Server
        /// </summary>
        AvalaraIdentityServer,

        /// <summary>
        /// The customer's account setup does not permit certain actions
        /// </summary>
        CustomerAccountSetup,

    }
}
