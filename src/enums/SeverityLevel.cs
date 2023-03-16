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
    /// Severity of message
    /// </summary>
    public enum SeverityLevel
    {
        /// <summary>
        /// Operation succeeded
        /// </summary>
        Success = 0,

        /// <summary>
        /// Warnings occured, operation succeeded
        /// </summary>
        Warning = 1,

        /// <summary>
        /// Errors occured, operation failed
        /// </summary>
        Error = 2,

        /// <summary>
        /// Unexpected exceptions occurred, operation failed
        /// </summary>
        Exception = 3,

    }
}
