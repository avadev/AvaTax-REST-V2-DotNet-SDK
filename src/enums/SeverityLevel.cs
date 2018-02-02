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
    /// Severity of message
    /// </summary>
    public enum SeverityLevel
    {
        /// <summary>
        /// Operation succeeded
        /// </summary>
        Success,

        /// <summary>
        /// Warnings occured, operation succeeded
        /// </summary>
        Warning,

        /// <summary>
        /// Errors occured, operation failed
        /// </summary>
        Error,

        /// <summary>
        /// Unexpected exceptions occurred, operation failed
        /// </summary>
        Exception,

    }
}
