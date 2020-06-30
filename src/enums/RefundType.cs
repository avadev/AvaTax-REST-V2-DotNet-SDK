using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2019 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Genevieve Conty
 * @author Greg Hester
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
        Full = 0,

        /// <summary>
        /// Refund only specific lines from the original a transaction.
        /// </summary>
        Partial = 1,

        /// <summary>
        /// Only refund the tax part of the transaction.
        /// </summary>
        TaxOnly = 2,

        /// <summary>
        /// Refund a percentage of the value of this transaction.
        /// </summary>
        Percentage = 3,

    }
}
