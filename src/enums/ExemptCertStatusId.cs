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
    /// Status for this exempt certificate
    /// </summary>
    public enum ExemptCertStatusId
    {
        /// <summary>
        /// Inactive certificate
        /// </summary>
        Inactive = 0,

        /// <summary>
        /// Active certificate
        /// </summary>
        Active = 1,

        /// <summary>
        /// Expired certificate
        /// </summary>
        Expired = 2,

        /// <summary>
        /// Revoked certificate
        /// </summary>
        Revoked = 3,

    }
}
