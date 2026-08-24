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
    /// The economic nexus threshold statuses evaluated for a company.
    /// </summary>
    public class EcoNexusThresholdsModel
    {
        /// <summary>
        /// The unique ID number of the company to which these threshold statuses belong.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The per-state threshold statuses for this company.
        /// Empty when no threshold status has been evaluated for the company.
        /// </summary>
        public List<ThresholdStateSummaryModel> states { get; set; }

        /// <summary>
        /// The UTC date and time when these threshold statuses were last updated.
        /// Omitted when the age of the data is not known.
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
