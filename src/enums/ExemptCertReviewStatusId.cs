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
    /// Exempt certificate review status
    /// </summary>
    public enum ExemptCertReviewStatusId
    {
        /// <summary>
        /// Review pending
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Certificate was accepted
        /// </summary>
        Accepted = 1,

        /// <summary>
        /// Certificate was rejected
        /// </summary>
        Rejected = 2,

    }
}
