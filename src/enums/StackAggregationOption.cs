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
    /// Defines how a stack rate is determined for a specific country and region.
    /// </summary>
    public enum StackAggregationOption
    {
        /// <summary>
        /// No aggregation.
        ///  The component rate is used for the stack rate.
        /// </summary>
        NoStackAggregation = 0,

        /// <summary>
        /// Rates are aggregated across all jurisdiction types.
        /// </summary>
        FullStackAggregation = 1,

        /// <summary>
        /// State and county rates are aggregated.
        /// </summary>
        AggregateStateAndCounty = 2,

        /// <summary>
        /// City and county rates are aggregated.
        /// </summary>
        AggregateCityAndCounty = 3,

    }
}
