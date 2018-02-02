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
    /// Exempt certificate review status
    /// </summary>
    public enum ExemptCertReviewStatusId
    {
        /// <summary>
        /// Review pending
        /// </summary>
        Pending,

        /// <summary>
        /// Certificate was accepted
        /// </summary>
        Accepted,

        /// <summary>
        /// Certificate was rejected
        /// </summary>
        Rejected,

    }
}
