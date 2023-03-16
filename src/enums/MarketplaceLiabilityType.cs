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
    /// This field will identify who is remitting the tax - Marketplace or Seller.
    /// </summary>
    public enum MarketplaceLiabilityType
    {
        /// <summary>
        /// MarketPlace
        /// </summary>
        Marketplace = 1,

        /// <summary>
        /// Seller
        /// </summary>
        Seller = 2,

    }
}
