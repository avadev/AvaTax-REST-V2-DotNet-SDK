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
    /// Filing Frequency types
    /// </summary>
    public enum NoticePriorityId
    {
        /// <summary>
        /// Immediate Attention Required
        /// </summary>
        ImmediateAttentionRequired = 1,

        /// <summary>
        /// High
        /// </summary>
        High = 2,

        /// <summary>
        /// Normal
        /// </summary>
        Normal = 3,

        /// <summary>
        /// Low
        /// </summary>
        Low = 4,

    }
}
