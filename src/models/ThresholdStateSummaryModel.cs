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
    /// Economic nexus threshold status for a single US state.
    /// </summary>
    public class ThresholdStateSummaryModel
    {
        /// <summary>
        /// Two-letter US state postal code (e.g. CA, TX, WA). Matches the database column `state`; use that name in `$filter`.
        /// </summary>
        public String state { get; set; }

        /// <summary>
        /// Full display name of the state.
        /// </summary>
        public String stateName { get; set; }

        /// <summary>
        /// Threshold status as determined by the upstream data pipeline. Typical values: 'met', 'notmet'.
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// Label describing the measurement window used for threshold evaluation (e.g. 'Prior calendar year').
        /// </summary>
        public String thresholdTimeframe { get; set; }

        /// <summary>
        /// Start of the threshold evaluation window.
        /// </summary>
        public DateTime? thresholdStartDate { get; set; }

        /// <summary>
        /// End of the threshold evaluation window.
        /// </summary>
        public DateTime? thresholdEndDate { get; set; }

        /// <summary>
        /// What triggered the threshold evaluation. Typical values: 'Sales', 'Transactions'.
        /// </summary>
        public String triggerType { get; set; }

        /// <summary>
        /// The configured transaction count threshold for this state, if applicable.
        /// </summary>
        public Int64? transactionThreshold { get; set; }

        /// <summary>
        /// The configured sales amount threshold for this state, if applicable.
        /// </summary>
        public Decimal? salesThreshold { get; set; }

        /// <summary>
        /// Actual total sales amount in the evaluation window.
        /// </summary>
        public Decimal? totalSalesAmount { get; set; }

        /// <summary>
        /// Actual total transaction count in the evaluation window.
        /// </summary>
        public Int64? totalTransactions { get; set; }

        /// <summary>
        /// UTC timestamp of when the upstream Snowflake source record was last modified.
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
