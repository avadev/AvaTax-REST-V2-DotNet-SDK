using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 * @author Greg Hester
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
        Storefront,

        /// <summary>
        /// Address refers to a main office of this company
        /// </summary>
        MainOffice,

        /// <summary>
        /// Address refers to a warehouse or other non-public location
        /// </summary>
        Warehouse,

        /// <summary>
        /// Address refers to a location for a single salesperson
        /// </summary>
        Salesperson,

        /// <summary>
        /// Address is a type not reflected in the other lists
        /// </summary>
        Other,

    }
}
