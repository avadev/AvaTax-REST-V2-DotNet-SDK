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
    /// A list of possible AvaFile Form Types.
    /// </summary>
    public enum FormTypeId
    {
        /// <summary>
        /// Denotes the form type is Sales and Use Tax
        /// </summary>
        SalesAndUse,

        /// <summary>
        /// Denotes the form type is Sales Tax only
        /// </summary>
        Sales,

        /// <summary>
        /// Denotes the form type is Sellers Use Tax only
        /// </summary>
        SellersUse,

        /// <summary>
        /// Denotes the form type is Lodging Tax only
        /// </summary>
        Lodging,

        /// <summary>
        /// Denotes the form type is Sales and Lodging Tax
        /// </summary>
        SalesAndLodging,

        /// <summary>
        /// Denotes the form type is Consumer Use Tax only
        /// </summary>
        ConsumerUse,

        /// <summary>
        /// Denotes the form type is Resort and Rental Tax
        /// </summary>
        ResortAndRental,

        /// <summary>
        /// Denotes the form type is Tourist and Rental Tax
        /// </summary>
        TouristAndRental,

        /// <summary>
        /// Denotes the form type is Prepayment
        /// </summary>
        Prepayment,

    }
}
