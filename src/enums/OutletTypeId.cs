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
    /// Indicates the behavior of a tax form for a company with multiple places of business.
    ///  
    ///  Some tax authorities require that a separate form must be filed for each place of business.
    /// </summary>
    public enum OutletTypeId
    {
        /// <summary>
        /// File a single return per cycle for your entire business.
        /// </summary>
        None = 0,

        /// <summary>
        /// You may file separate forms for each outlet; contact the tax authority for more details about location based reporting requirements.
        /// </summary>
        Schedule = 1,

        /// <summary>
        /// You may file separate forms for each outlet; contact the tax authority for more details about location based reporting requirements.
        /// </summary>
        Duplicate = 2,

        /// <summary>
        /// File a single return, but you must have a line item for each place of business.
        /// </summary>
        Consolidated = 3,

    }
}
