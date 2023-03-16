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
    /// Indicates the type of adjustment that was performed on a transaction
    /// </summary>
    public enum AdjustmentReason
    {
        /// <summary>
        /// The transaction has not been adjusted
        /// </summary>
        NotAdjusted = 0,

        /// <summary>
        /// A sourcing issue existed which caused the transaction to be adjusted
        /// </summary>
        SourcingIssue = 1,

        /// <summary>
        /// Transaction was adjusted to reconcile it with a general ledger
        /// </summary>
        ReconciledWithGeneralLedger = 2,

        /// <summary>
        /// Transaction was adjusted after an exemption certificate was applied
        /// </summary>
        ExemptCertApplied = 3,

        /// <summary>
        /// Transaction was adjusted when the price of an item changed
        /// </summary>
        PriceAdjusted = 4,

        /// <summary>
        /// Transaction was adjusted due to a product return
        /// </summary>
        ProductReturned = 5,

        /// <summary>
        /// Transaction was adjusted due to a product exchange
        /// </summary>
        ProductExchanged = 6,

        /// <summary>
        /// Transaction was adjusted due to bad or uncollectable debt
        /// </summary>
        BadDebt = 7,

        /// <summary>
        /// Transaction was adjusted for another reason not specified
        /// </summary>
        Other = 8,

        /// <summary>
        /// Offline
        /// </summary>
        Offline = 9,

    }
}
