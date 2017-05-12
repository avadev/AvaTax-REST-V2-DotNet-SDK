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
    /// Refund types
    /// </summary>
    public enum RefundType
    {
        /// <summary>
        /// Refund the whole transaction.
        /// </summary>
        Full,

        /// <summary>
        /// Refund only specific lines from the original a transaction.
        /// </summary>
        Partial,

        /// <summary>
        /// Only refund the tax part of the transaction.
        /// </summary>
        TaxOnly,

        /// <summary>
        /// Refund a percentage of the value of this transaction.
        /// </summary>
        Percentage,

    }
}
