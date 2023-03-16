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
    /// Represents a Jurisdiction with applicable TaxType, TaxSubType and RateType.
    /// </summary>
    public class JurisdictionRateTypeTaxTypeMappingModel
    {
        /// <summary>
        /// The unique ID number of this Jurisdiction RateType TaxType Mapping.
        /// </summary>
        public Int32? id { get; set; }

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
        /// Name or ISO 3166 code identifying the region of this jurisdiction.
        ///  
        /// This field supports many different region identifiers:
        ///  * Two and three character ISO 3166 region codes
        ///  * Fully spelled out names of the region in ISO supported languages
        ///  * Common alternative spellings for many regions
        ///  
        /// For a full list of all supported codes and names, please see the Definitions API `ListRegions`.
        /// </summary>
        public String state { get; set; }

        /// <summary>
        /// Jurisdiction TypeId
        /// </summary>
        public String jurisdictionType { get; set; }

        /// <summary>
        /// Jurisdiction Code
        /// </summary>
        public String jurisdictionCode { get; set; }

        /// <summary>
        /// Jurisdiction long name
        /// </summary>
        public String longName { get; set; }

        /// <summary>
        /// Tax Type to which this jurisdiction is applicable
        /// </summary>
        public String taxTypeId { get; set; }

        /// <summary>
        /// Tax Type to which this jurisdiction is applicable
        /// </summary>
        public String taxSubTypeId { get; set; }

        /// <summary>
        /// Tax Type Group to which this jurisdiction is applicable
        /// </summary>
        public String taxTypeGroupId { get; set; }

        /// <summary>
        /// Rate Type to which this jurisdiction is applicable
        /// </summary>
        public String rateTypeId { get; set; }

        /// <summary>
        /// StateFips value of this jurisdiction
        /// </summary>
        public String stateFips { get; set; }

        /// <summary>
        /// The date this jurisdiction starts to take effect on tax calculations
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The date this jurisdiction stops to take effect on tax calculations
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
