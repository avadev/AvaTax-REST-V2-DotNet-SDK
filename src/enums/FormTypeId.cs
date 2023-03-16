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
    /// A list of possible AvaFile Form Types.
    /// </summary>
    public enum FormTypeId
    {
        /// <summary>
        /// Denotes the form type is Sales and Use Tax
        /// </summary>
        SalesAndUse = 0,

        /// <summary>
        /// Denotes the form type is Sales Tax only
        /// </summary>
        Sales = 1,

        /// <summary>
        /// Denotes the form type is Sellers Use Tax only
        /// </summary>
        SellersUse = 2,

        /// <summary>
        /// Denotes the form type is Lodging Tax only
        /// </summary>
        Lodging = 3,

        /// <summary>
        /// Denotes the form type is Sales and Lodging Tax
        /// </summary>
        SalesAndLodging = 4,

        /// <summary>
        /// Denotes the form type is Consumer Use Tax only
        /// </summary>
        ConsumerUse = 5,

        /// <summary>
        /// Denotes the form type is Resort and Rental Tax
        /// </summary>
        ResortAndRental = 6,

        /// <summary>
        /// Denotes the form type is Tourist and Rental Tax
        /// </summary>
        TouristAndRental = 7,

        /// <summary>
        /// Denotes the form type is Prepayment
        /// </summary>
        Prepayment = 8,

        /// <summary>
        /// Denotes the form type is Prepayment Allowance
        /// </summary>
        PrepaymentAllowed = 9,

    }
}
