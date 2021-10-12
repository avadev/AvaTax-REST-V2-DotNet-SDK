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
    public enum DocumentStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Temporary = 0,

        /// <summary>
        /// 
        /// </summary>
        Saved = 1,

        /// <summary>
        /// 
        /// </summary>
        Posted = 2,

        /// <summary>
        /// 
        /// </summary>
        Committed = 3,

        /// <summary>
        /// 
        /// </summary>
        Cancelled = 4,

        /// <summary>
        /// 
        /// </summary>
        Adjusted = 5,

        /// <summary>
        /// 
        /// </summary>
        Queued = 6,

        /// <summary>
        /// 
        /// </summary>
        PendingApproval = 7,

        /// <summary>
        /// 
        /// </summary>
        Any = -1,

    }
}
