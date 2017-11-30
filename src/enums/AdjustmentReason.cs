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
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Indicates the type of adjustment that was performed on a transaction
    /// </summary>
    public enum AdjustmentReason
    {
        /// <summary>
        /// The transaction has not been adjusted
        /// </summary>
        NotAdjusted,

        /// <summary>
        /// A sourcing issue existed which caused the transaction to be adjusted
        /// </summary>
        SourcingIssue,

        /// <summary>
        /// Transaction was adjusted to reconcile it with a general ledger
        /// </summary>
        ReconciledWithGeneralLedger,

        /// <summary>
        /// Transaction was adjusted after an exemption certificate was applied
        /// </summary>
        ExemptCertApplied,

        /// <summary>
        /// Transaction was adjusted when the price of an item changed
        /// </summary>
        PriceAdjusted,

        /// <summary>
        /// Transaction was adjusted due to a product return
        /// </summary>
        ProductReturned,

        /// <summary>
        /// Transaction was adjusted due to a product exchange
        /// </summary>
        ProductExchanged,

        /// <summary>
        /// Transaction was adjusted due to bad or uncollectable debt
        /// </summary>
        BadDebt,

        /// <summary>
        /// Transaction was adjusted for another reason not specified
        /// </summary>
        Other,

        /// <summary>
        /// Offline
        /// </summary>
        Offline,

    }
}
