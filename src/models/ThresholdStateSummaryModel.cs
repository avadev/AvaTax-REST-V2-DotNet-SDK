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
    /// Economic nexus threshold status for a single US region.
    /// </summary>
    public class ThresholdStateSummaryModel
    {
        /// <summary>
        /// The unique identifier of this threshold status.
        /// </summary>
        public String id { get; set; }

        /// <summary>
        /// Two-letter US state postal code (e.g. CA, TX, WA).
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// Full display name of the region.
        /// </summary>
        public String regionName { get; set; }

        /// <summary>
        /// Whether the economic nexus threshold has been met for this region. Typical values: 'met', 'notmet'.
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// Label describing the measurement window used to evaluate the threshold (e.g. 'Prior calendar year').
        /// </summary>
        public String thresholdTimeframe { get; set; }

        /// <summary>
        /// The start of the measurement window.
        /// </summary>
        public DateTime? thresholdStartDate { get; set; }

        /// <summary>
        /// The end of the measurement window.
        /// </summary>
        public DateTime? thresholdEndDate { get; set; }

        /// <summary>
        /// The measure the threshold is evaluated against. Typical values: 'Sales', 'Transactions'.
        /// </summary>
        public String triggerType { get; set; }

        /// <summary>
        /// The configured transaction count threshold for this region, if applicable.
        /// </summary>
        public Int64? transactionThreshold { get; set; }

        /// <summary>
        /// The configured sales amount threshold for this region, if applicable.
        /// </summary>
        public Decimal? salesThreshold { get; set; }

        /// <summary>
        /// The company's total sales amount within the measurement window.
        /// </summary>
        public Decimal? totalSalesAmount { get; set; }

        /// <summary>
        /// The company's total transaction count within the measurement window.
        /// </summary>
        public Int64? totalTransactions { get; set; }

        /// <summary>
        /// The UTC date and time when this threshold status was last modified.
        /// </summary>
        public DateTime? sourceLastUpdatedAt { get; set; }


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
