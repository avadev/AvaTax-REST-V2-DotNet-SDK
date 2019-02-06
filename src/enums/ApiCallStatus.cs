using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2019 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Genevieve Conty
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Indicates what level of auditing information is available for a transaction
    /// </summary>
    public enum ApiCallStatus
    {
        /// <summary>
        /// If the original api call is availabe on S3
        /// </summary>
        OriginalApiCallAvailable = 0,

        /// <summary>
        /// if the original api call is not available, reconstructed api call should always be available
        /// </summary>
        ReconstructedApiCallAvailable = 1,

        /// <summary>
        /// Any other api call status
        /// </summary>
        Any = -1,

    }
}
