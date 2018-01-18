using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
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
        ImmediateAttentionRequired,

        /// <summary>
        /// High
        /// </summary>
        High,

        /// <summary>
        /// Normal
        /// </summary>
        Normal,

        /// <summary>
        /// Low
        /// </summary>
        Low,

    }
}
