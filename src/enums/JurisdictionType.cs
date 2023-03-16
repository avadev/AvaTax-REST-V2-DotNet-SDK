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
    /// Jurisdiction Type
    /// </summary>
    public enum JurisdictionType
    {
        /// <summary>
        /// Country
        /// </summary>
        Country = 0,

        /// <summary>
        /// State
        /// </summary>
        State = 1,

        /// <summary>
        /// County
        /// </summary>
        County = 2,

        /// <summary>
        /// City
        /// </summary>
        City = 3,

        /// <summary>
        /// Special Tax Jurisdiction
        /// </summary>
        Special = 4,

    }
}
