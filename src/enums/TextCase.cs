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
    /// Casing to use for validation result
    /// </summary>
    public enum TextCase
    {
        /// <summary>
        /// Default (casing determined by address standardization setting in Avalara)
        /// </summary>
        Default = 0,

        /// <summary>
        /// Upper case
        /// </summary>
        Upper = 1,

        /// <summary>
        /// Mixed Case
        /// </summary>
        Mixed = 2,

    }
}
