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
    public enum StackAggregationOption
    {
        /// <summary>
        /// 
        /// </summary>
        NoStackAggregation = 0,

        /// <summary>
        /// 
        /// </summary>
        FullStackAggregation = 1,

        /// <summary>
        /// 
        /// </summary>
        AggregateStateAndCounty = 2,

        /// <summary>
        /// 
        /// </summary>
        AggregateCityAndCounty = 3,

    }
}
