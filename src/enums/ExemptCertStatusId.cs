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
 * Swagger name: AvaTaxClient 
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// 
    /// </summary>
    public enum ExemptCertStatusId
    {
        /// <summary>
        /// 
        /// </summary>
        Inactive = 0,

        /// <summary>
        /// 
        /// </summary>
        Active = 1,

        /// <summary>
        /// 
        /// </summary>
        Expired = 2,

        /// <summary>
        /// 
        /// </summary>
        Revoked = 3,

    }
}
