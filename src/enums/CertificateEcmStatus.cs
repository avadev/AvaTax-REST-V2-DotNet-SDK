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
    /// 
    /// </summary>
    public enum CertificateEcmStatus
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

        /// <summary>
        /// 
        /// </summary>
        Expired = 1,

        /// <summary>
        /// 
        /// </summary>
        Invalid = 2,

        /// <summary>
        /// 
        /// </summary>
        Valid = 3,

        /// <summary>
        /// 
        /// </summary>
        PendingFuture = 4,

    }
}
