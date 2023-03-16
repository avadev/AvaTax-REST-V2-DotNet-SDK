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
    /// Indicates the level of detail requested from a tax API call
    /// </summary>
    public enum TaxDebugLevel
    {
        /// <summary>
        /// User requests the normal level of debug information when creating a tax transaction
        /// </summary>
        Normal = 0,

        /// <summary>
        /// User requests additional diagnostic information when creating a tax transaction
        /// </summary>
        Diagnostic = 1,

    }
}
