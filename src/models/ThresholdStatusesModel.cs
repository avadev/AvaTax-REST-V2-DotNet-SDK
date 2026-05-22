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
    /// Response model for the economic nexus threshold statuses endpoint.
    /// </summary>
    public class ThresholdStatusesModel
    {
        /// <summary>
        /// The Avalara company identifier.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// Per-state threshold summaries for the company. Empty array if no evaluated data exists.
        /// </summary>
        public List<ThresholdStateSummaryModel> states { get; set; }

        /// <summary>
        /// UTC timestamp of when the TPS in-memory cache last successfully refreshed from Snowflake.
        /// Null if a refresh has not yet completed.
        /// </summary>
        public DateTime? lastRefreshedAt { get; set; }


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
