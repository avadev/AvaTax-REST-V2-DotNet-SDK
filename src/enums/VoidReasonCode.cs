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
    public enum VoidReasonCode
    {
        /// <summary>
        /// 
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// 
        /// </summary>
        PostFailed = 1,

        /// <summary>
        /// 
        /// </summary>
        DocDeleted = 2,

        /// <summary>
        /// 
        /// </summary>
        DocVoided = 3,

        /// <summary>
        /// 
        /// </summary>
        AdjustmentCancelled = 4,

    }
}
