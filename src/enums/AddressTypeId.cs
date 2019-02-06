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
    /// Indicates whether this address refers to a person or an business
    /// </summary>
    public enum AddressTypeId
    {
        /// <summary>
        /// A business location, for example a store, warehouse, or office.
        /// </summary>
        Location = 1,

        /// <summary>
        /// A person's address who performs sales tasks for the company remotely from an office.
        /// </summary>
        Salesperson = 2,

        /// <summary>
        /// This location is a marketplace vendor that handles transactions on behalf of the company.
        ///  When you select `Marketplace` as the address type for a location, you must then choose either
        ///  `SellerRemitsTax` or `MarketplaceRemitsTax` to indicate which business entity is responsible
        ///  for collecting and remitting tax for this location.
        /// </summary>
        Marketplace = 3,

    }
}
