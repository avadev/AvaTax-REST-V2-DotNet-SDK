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
    /// Liability Type
    /// </summary>
    public enum LiabilityType
    {
        /// <summary>
        /// Seller
        /// </summary>
        Seller = 0,

        /// <summary>
        /// BuyersAgent
        /// </summary>
        BuyersAgent = 1,

        /// <summary>
        /// Buyer
        /// </summary>
        Buyer = 2,

        /// <summary>
        /// ThirdParty
        /// </summary>
        ThirdParty = 3,

    }
}
