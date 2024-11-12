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
    /// The model for liability parameters definitions
    /// </summary>
    public class LiabilityParametersModel
    {
        /// <summary>
        /// The type of Returns liability report to be generated
        /// </summary>
        public ReturnsLiabilityType? liabilityType { get; set; }

        /// <summary>
        /// The type of Returns report to be generated
        /// </summary>
        public ReturnsReportType? returnsReportType { get; set; }

        /// <summary>
        /// The Hospitality Account ID with Subscription Type as AvaLoding
        /// </summary>
        public Int32? hospitalityAccountId { get; set; }

        /// <summary>
        /// Filter report based on the year
        /// </summary>
        public Int32? year { get; set; }

        /// <summary>
        /// Filter report based on the month
        /// </summary>
        public object month { get; set; }

        /// <summary>
        /// Filter report based on the country code
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Filter report based on the region code or state code
        /// </summary>
        public String region { get; set; }


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
