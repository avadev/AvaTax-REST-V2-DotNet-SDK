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
    public enum TaxRuleTypeId
    {
        /// <summary>
        /// 
        /// </summary>
        RateRule = 0,

        /// <summary>
        /// 
        /// </summary>
        RateOverrideRule = 1,

        /// <summary>
        /// 
        /// </summary>
        BaseRule = 2,

        /// <summary>
        /// 
        /// </summary>
        ExemptEntityRule = 3,

        /// <summary>
        /// 
        /// </summary>
        ProductTaxabilityRule = 4,

        /// <summary>
        /// 
        /// </summary>
        NexusRule = 5,

        /// <summary>
        /// 
        /// </summary>
        RateCapRule = 6,

        /// <summary>
        /// 
        /// </summary>
        TaxOverrideRule = 7,

        /// <summary>
        /// 
        /// </summary>
        FeeRule = 8,

        /// <summary>
        /// 
        /// </summary>
        OtherRule = 100,

    }
}
