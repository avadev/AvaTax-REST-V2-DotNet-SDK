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
    /// 
    /// </summary>
    public enum NexusTypeId
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

        /// <summary>
        /// 
        /// </summary>
        SalesOrSellersUseTax = 1,

        /// <summary>
        /// 
        /// </summary>
        SalesTax = 2,

        /// <summary>
        /// 
        /// </summary>
        SSTVolunteer = 3,

        /// <summary>
        /// 
        /// </summary>
        SSTNonVolunteer = 4,

    }
}
