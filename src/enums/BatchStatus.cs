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
    public enum BatchStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Waiting = 0,

        /// <summary>
        /// 
        /// </summary>
        SystemErrors = 1,

        /// <summary>
        /// 
        /// </summary>
        Cancelled = 2,

        /// <summary>
        /// 
        /// </summary>
        Completed = 3,

        /// <summary>
        /// 
        /// </summary>
        Creating = 4,

        /// <summary>
        /// 
        /// </summary>
        Deleted = 5,

        /// <summary>
        /// 
        /// </summary>
        Errors = 6,

        /// <summary>
        /// 
        /// </summary>
        Paused = 7,

        /// <summary>
        /// 
        /// </summary>
        Processing = 8,

    }
}
