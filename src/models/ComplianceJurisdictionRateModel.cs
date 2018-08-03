using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// A flattened model for jurisdictions and rates.
    /// </summary>
    public class ComplianceJurisdictionRateModel
    {
        /// <summary>
        /// The id of the jurisdiction.
        /// </summary>
        public Int32? jurisdictionId { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the country of this jurisdiction.
        /// 
        /// This field supports many different country identifiers:
        ///  * Two character ISO 3166 codes
        ///  * Three character ISO 3166 codes
        ///  * Fully spelled out names of the country in ISO supported languages
        ///  * Common alternative spellings for many countries
        /// 
        /// For a full list of all supported codes and names, please see the Definitions API `ListCountries`.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the region within the country.
        /// 
        /// This field supports many different region identifiers:
        ///  * Two and three character ISO 3166 region codes
        ///  * Fully spelled out names of the region in ISO supported languages
        ///  * Common alternative spellings for many regions
        /// 
        /// For a full list of all supported codes and names, please see the Definitions API `ListRegions`.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// The name of the jurisdiction.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The type of the jurisdiction, indicating whether it is a country, state/region, city, for example.
        /// </summary>
        public String jurisdictionTypeId { get; set; }

        /// <summary>
        /// The compontent rate.
        /// </summary>
        public Decimal? rate { get; set; }

        /// <summary>
        /// The rate type.
        /// </summary>
        public String rateTypeId { get; set; }

        /// <summary>
        /// The tax type.
        /// </summary>
        public String taxTypeId { get; set; }

        /// <summary>
        /// The date this rate is starts to take effect.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The date this rate is no longer active.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The state assigned code.
        /// </summary>
        public String stateAssignedCode { get; set; }

        /// <summary>
        /// The id of the tax authority.
        /// </summary>
        public Int32? taxAuthorityId { get; set; }


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
