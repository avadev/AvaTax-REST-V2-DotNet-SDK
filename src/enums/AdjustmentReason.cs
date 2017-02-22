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
    /// AdjustmentReason
    /// </summary>
    public enum AdjustmentReason
    {
        /// <summary>
        /// 
        /// </summary>
        NotAdjusted,

        /// <summary>
        /// 
        /// </summary>
        SourcingIssue,

        /// <summary>
        /// 
        /// </summary>
        ReconciledWithGeneralLedger,

        /// <summary>
        /// 
        /// </summary>
        ExemptCertApplied,

        /// <summary>
        /// 
        /// </summary>
        PriceAdjusted,

        /// <summary>
        /// 
        /// </summary>
        ProductReturned,

        /// <summary>
        /// 
        /// </summary>
        ProductExchanged,

        /// <summary>
        /// 
        /// </summary>
        BadDebt,

        /// <summary>
        /// 
        /// </summary>
        Other,

        /// <summary>
        /// 
        /// </summary>
        Offline,

    }
}
