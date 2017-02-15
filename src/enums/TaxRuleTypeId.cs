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
    /// TaxRuleTypeId
    /// </summary>
    public enum TaxRuleTypeId
    {
        /// <summary>
        /// 
        /// </summary>
        RateRule,

        /// <summary>
        /// 
        /// </summary>
        RateOverrideRule,

        /// <summary>
        /// 
        /// </summary>
        BaseRule,

        /// <summary>
        /// 
        /// </summary>
        ExemptEntityRule,

        /// <summary>
        /// 
        /// </summary>
        ProductTaxabilityRule,

        /// <summary>
        /// 
        /// </summary>
        NexusRule,

    }
}
