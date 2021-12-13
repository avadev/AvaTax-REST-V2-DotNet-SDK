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
 * Swagger name: AvaTaxClient 
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// 
    /// </summary>
    public enum FormTypeId
    {
        /// <summary>
        /// 
        /// </summary>
        SalesAndUse = 0,

        /// <summary>
        /// 
        /// </summary>
        Sales = 1,

        /// <summary>
        /// 
        /// </summary>
        SellersUse = 2,

        /// <summary>
        /// 
        /// </summary>
        Lodging = 3,

        /// <summary>
        /// 
        /// </summary>
        SalesAndLodging = 4,

        /// <summary>
        /// 
        /// </summary>
        ConsumerUse = 5,

        /// <summary>
        /// 
        /// </summary>
        ResortAndRental = 6,

        /// <summary>
        /// 
        /// </summary>
        TouristAndRental = 7,

        /// <summary>
        /// 
        /// </summary>
        Prepayment = 8,

        /// <summary>
        /// 
        /// </summary>
        PrepaymentAllowed = 9,

    }
}
