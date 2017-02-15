using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// TransactionAddressType
    /// </summary>
    public enum TransactionAddressType
    {
        /// <summary>
        /// This is the location from which the product was shipped
        /// </summary>
        ShipFrom,

        /// <summary>
        /// This is the location to which the product was shipped
        /// </summary>
        ShipTo,

        /// <summary>
        /// Location where the order was accepted; typically the call center, business office where purchase orders are accepted, server locations where orders are processed and accepted
        /// </summary>
        PointOfOrderAcceptance,

        /// <summary>
        /// Location from which the order was placed; typically the customer's home or business location
        /// </summary>
        PointOfOrderOrigin,

        /// <summary>
        /// Only used if all addresses for this transaction were identical; e.g. if this was a point-of-sale physical transaction
        /// </summary>
        SingleLocation,

    }
}
