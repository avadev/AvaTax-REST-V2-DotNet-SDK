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
    /// TaxRuleTypeId
    /// </summary>
    public enum TaxRuleTypeId
    {
        /// <summary>
        /// RateRule
        /// </summary>
        RateRule,

        /// <summary>
        /// RateOverrideRule
        /// </summary>
        RateOverrideRule,

        /// <summary>
        /// BaseRule
        /// </summary>
        BaseRule,

        /// <summary>
        /// ExemptEntityRule
        /// </summary>
        ExemptEntityRule,

        /// <summary>
        /// ProductTaxabilityRule
        /// </summary>
        ProductTaxabilityRule,

        /// <summary>
        /// NexusRule
        /// </summary>
        NexusRule,

    }
}
