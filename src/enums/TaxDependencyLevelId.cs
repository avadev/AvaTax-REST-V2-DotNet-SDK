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
    /// TaxDependencyLevelId
    /// </summary>
    public enum TaxDependencyLevelId
    {
        /// <summary>
        /// Document
        /// </summary>
        Document = 0,

        /// <summary>
        /// State
        /// </summary>
        State = 1,

        /// <summary>
        /// TaxRegion
        /// </summary>
        TaxRegion = 2,

        /// <summary>
        /// Address
        /// </summary>
        Address = 3,

    }
}
