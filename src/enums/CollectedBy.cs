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
    /// Identifies the party that collects tax from the consumer, as distinct from
    ///  LiabilityType (who remits it) and ChargedTo (who pays it). Introduced for
    ///  AVT-99436 — OTA Marketplace Liability Decision.
    /// </summary>
    public enum CollectedBy
    {
        /// <summary>
        /// Seller
        /// </summary>
        Seller = 0,

        /// <summary>
        /// Marketplace
        /// </summary>
        Marketplace = 1,

        /// <summary>
        /// Buyer
        /// </summary>
        Buyer = 2,

        /// <summary>
        /// OTA
        /// </summary>
        OTA = 3,

    }
}
