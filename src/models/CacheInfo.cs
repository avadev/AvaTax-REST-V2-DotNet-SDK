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
    /// Individual cache information
    /// </summary>
    public class CacheInfo
    {
        /// <summary>
        /// Name of the cache
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Memory size of the cache in bytes
        /// </summary>
        public Int64? memorySizeBytes { get; set; }

        /// <summary>
        /// Memory size of the cache in megabytes
        /// </summary>
        public Decimal? memorySizeMB { get; set; }

        /// <summary>
        /// Memory size of the cache in GB
        /// </summary>
        public Decimal? memorySizeGB { get; set; }

        /// <summary>
        /// Number of items in the cache
        /// </summary>
        public Int32? itemCount { get; set; }

        /// <summary>
        /// Whether the cache is currently loaded
        /// </summary>
        public Boolean? isLoaded { get; set; }

        /// <summary>
        /// Time when the cache was last refreshed
        /// </summary>
        public DateTime? lastRefreshTime { get; set; }

        /// <summary>
        /// Duration of the last cache refresh operation
        /// </summary>
        public String lastRefreshDuration { get; set; }


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
