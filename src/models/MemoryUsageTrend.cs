using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
    /// Memory usage trend data
    /// </summary>
    public class MemoryUsageTrend
    {
        /// <summary>
        /// List of memory usage data points over time
        /// </summary>
        public List<MemoryUsageStats> dataPoints { get; set; }

        /// <summary>
        /// Duration of the trend analysis period
        /// </summary>
        public String duration { get; set; }

        /// <summary>
        /// Average memory usage percentage over the trend period
        /// </summary>
        public Decimal? averageMemoryUsage { get; set; }

        /// <summary>
        /// Peak memory usage percentage during the trend period
        /// </summary>
        public Decimal? peakMemoryUsage { get; set; }

        /// <summary>
        /// Lowest memory usage percentage during the trend period
        /// </summary>
        public Decimal? lowMemoryUsage { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
