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
    /// 
    /// </summary>
    public enum FilingRequestStatus
    {
        /// <summary>
        /// 
        /// </summary>
        New = 1,

        /// <summary>
        /// 
        /// </summary>
        Validated = 2,

        /// <summary>
        /// 
        /// </summary>
        Pending = 3,

        /// <summary>
        /// 
        /// </summary>
        Active = 4,

        /// <summary>
        /// 
        /// </summary>
        PendingStop = 5,

        /// <summary>
        /// 
        /// </summary>
        Inactive = 6,

        /// <summary>
        /// 
        /// </summary>
        ChangeRequest = 7,

        /// <summary>
        /// 
        /// </summary>
        RequestApproved = 8,

        /// <summary>
        /// 
        /// </summary>
        RequestDenied = 9,

    }
}
