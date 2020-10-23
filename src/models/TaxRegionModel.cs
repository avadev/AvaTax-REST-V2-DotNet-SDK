using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2019 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Genevieve Conty
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// The tax region model.
    /// </summary>
    public class TaxRegionModel
    {
        /// <summary>
        /// The id of the tax region.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The code of the tax region.
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// The name of the tax region.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The name of the county.
        /// </summary>
        public String county { get; set; }

        /// <summary>
        /// The name of the city.
        /// </summary>
        public String city { get; set; }

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
        /// The ser code.
        /// </summary>
        public String serCode { get; set; }

        /// <summary>
        /// The tax region signature code.
        /// </summary>
        public String signatureCode { get; set; }

        /// <summary>
        /// The date this tax region starts to take effect.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The date this tax region stops to take effect.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Is Acm flag.
        /// </summary>
        public Boolean? isAcm { get; set; }

        /// <summary>
        /// Is SST flag.
        /// </summary>
        public Boolean? isSst { get; set; }

        /// <summary>
        /// List of jurisdictions associated with this tax region.
        /// </summary>
        public List<> jurisdictions { get; set; }


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
