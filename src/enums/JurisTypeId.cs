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
    /// Types of jurisdiction referenced in a transaction
    /// </summary>
    public enum JurisTypeId
    {
        /// <summary>
        /// State
        /// </summary>
        STA = 1,

        /// <summary>
        /// County
        /// </summary>
        CTY = 2,

        /// <summary>
        /// City
        /// </summary>
        CIT = 3,

        /// <summary>
        /// Special
        /// </summary>
        STJ = 4,

        /// <summary>
        /// Country
        /// </summary>
        CNT = 5,

    }
}
