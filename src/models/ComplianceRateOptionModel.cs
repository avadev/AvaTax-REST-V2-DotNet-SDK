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
    /// Model for RateOption.
    /// </summary>
    public class ComplianceRateOptionModel
    {
        /// <summary>
        /// The name of the Jurisdiction
        /// </summary>
        public String jurisName { get; set; }

        /// <summary>
        /// The Group Code
        /// </summary>
        public String groupCode { get; set; }

        /// <summary>
        /// The id of the tax region.
        /// </summary>
        public Int32? taxRegionId { get; set; }

        /// <summary>
        /// The name of the tax region.
        /// </summary>
        public String taxRegionName { get; set; }

        /// <summary>
        /// The report level.
        /// </summary>
        public String reportLevel { get; set; }

        /// <summary>
        /// The Tax Type Code.
        /// </summary>
        public String taxTypeCode { get; set; }

        /// <summary>
        /// The name of the Tax Type Code.
        /// </summary>
        public String taxTypeCodeName { get; set; }

        /// <summary>
        /// The Sub Type Code.
        /// </summary>
        public String taxSubTypeCode { get; set; }

        /// <summary>
        /// The name of Sub Type.
        /// </summary>
        public String taxSubTypeCodeName { get; set; }

        /// <summary>
        /// The rate type of the rate.
        /// </summary>
        public String rateTypeCode { get; set; }

        /// <summary>
        /// The rate type description.
        /// </summary>
        public String rateTypeCodeName { get; set; }

        /// <summary>
        /// The Stack Rate
        /// </summary>
        public Decimal? stackRate { get; set; }

        /// <summary>
        /// The Component Rate
        /// </summary>
        public Decimal? componentRate { get; set; }

        /// <summary>
        /// The id of the tax authority.
        /// </summary>
        public Int32? taxAuthorityId { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public String cityName { get; set; }

        /// <summary>
        /// County
        /// </summary>
        public String countyName { get; set; }

        /// <summary>
        /// Effective Date
        /// </summary>
        public DateTime? effDate { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        public DateTime? endDate { get; set; }


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
