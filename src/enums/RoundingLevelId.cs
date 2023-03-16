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
    /// Choice of rounding level for a transaction
    /// </summary>
    public enum RoundingLevelId
    {
        /// <summary>
        /// Round tax on each line separately
        /// </summary>
        Line = 0,

        /// <summary>
        /// Round tax at the document level
        /// </summary>
        Document = 1,

    }
}
