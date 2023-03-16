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
    /// Indicates the rounding behavior of a form
    /// </summary>
    public enum RoundingTypeId
    {
        /// <summary>
        /// There is no rounding on the return
        /// </summary>
        None = 0,

        /// <summary>
        /// Round to the nearest whole number
        /// </summary>
        Nearest = 1,

        /// <summary>
        /// Always round up
        /// </summary>
        Up = 2,

        /// <summary>
        /// Always round down
        /// </summary>
        Down = 3,

    }
}
