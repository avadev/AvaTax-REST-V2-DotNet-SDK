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
