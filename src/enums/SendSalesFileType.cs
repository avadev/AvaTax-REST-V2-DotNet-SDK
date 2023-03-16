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
    public enum SendSalesFileType
    {
        /// <summary>
        /// File is in Comma Separated Values format
        /// </summary>
        Csv = 0,

        /// <summary>
        /// File is in Javascript Object Notation format
        /// </summary>
        Json = 1,

    }
}
