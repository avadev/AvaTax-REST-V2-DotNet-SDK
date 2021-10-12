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
    public enum FirmClientLinkageStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Requested = 1,

        /// <summary>
        /// 
        /// </summary>
        Approved = 2,

        /// <summary>
        /// 
        /// </summary>
        Rejected = 3,

        /// <summary>
        /// 
        /// </summary>
        Revoked = 4,

    }
}
