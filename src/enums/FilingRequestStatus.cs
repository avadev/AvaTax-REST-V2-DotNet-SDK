using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// FilingRequestStatus
    /// </summary>
    public enum FilingRequestStatus
    {
        /// <summary>
        /// 
        /// </summary>
        New,

        /// <summary>
        /// 
        /// </summary>
        Validated,

        /// <summary>
        /// 
        /// </summary>
        Pending,

        /// <summary>
        /// 
        /// </summary>
        Active,

        /// <summary>
        /// 
        /// </summary>
        PendingStop,

        /// <summary>
        /// 
        /// </summary>
        Inactive,

        /// <summary>
        /// 
        /// </summary>
        ChangeRequest,

        /// <summary>
        /// 
        /// </summary>
        RequestApproved,

        /// <summary>
        /// 
        /// </summary>
        RequestDenied,

    }
}
