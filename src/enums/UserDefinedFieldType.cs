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
    /// 
    /// </summary>
    public enum UserDefinedFieldType
    {
        /// <summary>
        /// Represents document level user defined type.
        /// </summary>
        Document = 1,

        /// <summary>
        /// Represents line level user defined type.
        /// </summary>
        Line = 2,

    }
}
