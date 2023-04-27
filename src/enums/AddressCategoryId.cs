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
    /// The type of address represented by this object
    /// </summary>
    public enum AddressCategoryId
    {
        /// <summary>
        /// Address refers to a storefront location
        /// </summary>
        Storefront = 1,

        /// <summary>
        /// Address refers to a main office of this company
        /// </summary>
        MainOffice = 2,

        /// <summary>
        /// Address refers to a warehouse or other non-public location
        /// </summary>
        Warehouse = 3,

        /// <summary>
        /// Address refers to a location for a single salesperson
        /// </summary>
        Salesperson = 4,

        /// <summary>
        /// Address is a type not reflected in the other lists
        /// </summary>
        Other = 5,

        /// <summary>
        /// The marketplace vendor does not collect and remit tax for transactions tied to this
        ///  location. Use this option if you are using a marketplace vendor to handle your transactions
        ///  and your company is responsible for collecting and remitting all taxes for transactions tied
        ///  to this location.
        /// </summary>
        SellerRemitsTax = 6,

        /// <summary>
        /// The marketplace vendor collects and remits tax on your behalf for all transactions tied
        ///  to this location. Use this option if your marketplace vendor already pays sales and use
        ///  taxes on your behalf. When this option is selected, all transactions tied to this location
        ///  will be treated as already filed, and will be listed on each sales tax return as amounts
        ///  already paid.
        /// </summary>
        MarketplaceRemitsTax = 7,

        /// <summary>
        /// Address refers to the mailing address of your company which is not a physical location.
        /// </summary>
        NonPhysical = 8,

        /// <summary>
        /// Address refers to the vendor's location, used for ACU transaction
        /// </summary>
        Vendor = 9,

    }
}
