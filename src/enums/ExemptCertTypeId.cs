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
    /// Exempt Cert type
    /// </summary>
    public enum ExemptCertTypeId
    {
        /// <summary>
        /// Blanked certificate
        /// </summary>
        Blanket = 0,

        /// <summary>
        /// Single use
        /// </summary>
        SingleUse = 1,

    }
}
