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
    /// 
    /// </summary>
    public enum AdjustmentReason
    {
        /// <summary>
        /// 
        /// </summary>
        NotAdjusted = 0,

        /// <summary>
        /// 
        /// </summary>
        SourcingIssue = 1,

        /// <summary>
        /// 
        /// </summary>
        ReconciledWithGeneralLedger = 2,

        /// <summary>
        /// 
        /// </summary>
        ExemptCertApplied = 3,

        /// <summary>
        /// 
        /// </summary>
        PriceAdjusted = 4,

        /// <summary>
        /// 
        /// </summary>
        ProductReturned = 5,

        /// <summary>
        /// 
        /// </summary>
        ProductExchanged = 6,

        /// <summary>
        /// 
        /// </summary>
        BadDebt = 7,

        /// <summary>
        /// 
        /// </summary>
        Other = 8,

        /// <summary>
        /// 
        /// </summary>
        Offline = 9,

    }
}
