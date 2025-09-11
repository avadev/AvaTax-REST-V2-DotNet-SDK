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
    /// Cache memory usage details
    /// </summary>
    public class CacheMemoryUsage
    {
        /// <summary>
        /// Dictionary of cache information indexed by cache name
        /// </summary>
        public object caches { get; set; }

        /// <summary>
        /// Total memory used by all caches in bytes
        /// </summary>
        public Int64? totalCacheMemory { get; set; }

        /// <summary>
        /// Total memory used by all caches in GB
        /// </summary>
        public Decimal? totalCacheMemoryGB { get; set; }

        /// <summary>
        /// Total number of caches monitored
        /// </summary>
        public Int32? totalCacheCount { get; set; }

        /// <summary>
        /// Timestamp when the cache memory usage was collected
        /// </summary>
        public DateTime? timestamp { get; set; }


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
