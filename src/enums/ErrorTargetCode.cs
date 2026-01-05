using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2023 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Jonathan Wenger <jonathan.wenger@avalara.com>
 * @author Sachin Baijal <sachin.baijal@avalara.com>
 * Swagger name: AvaTaxClient 
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
        Unknown = 0,

        /// <summary>
        /// There was an error in the request URL, querystring, or body
        /// </summary>
        HttpRequest = 1,

        /// <summary>
        /// There was an error in the HTTP Request headers
        /// </summary>
        HttpRequestHeaders = 2,

        /// <summary>
        /// Some data provided by the user was incorrect
        /// </summary>
        IncorrectData = 3,

        /// <summary>
        /// There was an error in the AvaTax API Server
        /// </summary>
        AvaTaxApiServer = 10,

        /// <summary>
        /// There was an error in the Avalara Identity Server
        /// </summary>
        AvalaraIdentityServer = 11,

        /// <summary>
        /// The customer's account setup does not permit certain actions
        /// </summary>
        CustomerAccountSetup = 12,

    }
}
