using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
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
    /// 
    /// </summary>
    public enum AdjustmentTypeId
    {
        /// <summary>
        /// 
        /// </summary>
        Other,

        /// <summary>
        /// 
        /// </summary>
        CurrentPeriodRounding,

        /// <summary>
        /// 
        /// </summary>
        PriorPeriodRounding,

        /// <summary>
        /// 
        /// </summary>
        CurrentPeriodDiscount,

        /// <summary>
        /// 
        /// </summary>
        PriorPeriodDiscount,

        /// <summary>
        /// 
        /// </summary>
        CurrentPeriodCollection,

        /// <summary>
        /// 
        /// </summary>
        PriorPeriodCollection,

        /// <summary>
        /// 
        /// </summary>
        Penalty,

        /// <summary>
        /// 
        /// </summary>
        Interest,

        /// <summary>
        /// 
        /// </summary>
        Discount,

        /// <summary>
        /// 
        /// </summary>
        Rounding,

        /// <summary>
        /// 
        /// </summary>
        CspFee,

    }
}
