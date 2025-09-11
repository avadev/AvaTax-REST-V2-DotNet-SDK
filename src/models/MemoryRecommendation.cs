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
    /// Memory optimization recommendation
    /// </summary>
    public class MemoryRecommendation
    {
        /// <summary>
        /// Unique identifier for the recommendation
        /// </summary>
        public String id { get; set; }

        /// <summary>
        /// Title of the recommendation
        /// </summary>
        public String title { get; set; }

        /// <summary>
        /// Detailed description of the recommendation
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// Impact of implementing the recommendation
        /// </summary>
        public String impact { get; set; }

        /// <summary>
        /// Implementation guidance for the recommendation
        /// </summary>
        public String implementation { get; set; }

        /// <summary>
        /// Priority level of the recommendation
        /// </summary>
        public MemoryRecommendationPriority? priority { get; set; }

        /// <summary>
        /// Estimated memory savings in megabytes if recommendation is implemented
        /// </summary>
        public Decimal? estimatedMemorySavingsMB { get; set; }


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
