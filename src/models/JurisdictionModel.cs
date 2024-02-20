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
    /// Represents information about a single legal taxing jurisdiction
    /// </summary>
    public class JurisdictionModel
    {
        /// <summary>
        /// The code that is used to identify this jurisdiction
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// The name of this jurisdiction
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The type of the jurisdiction, indicating whether it is a country, state/region, city, for example.
        /// </summary>
        public JurisdictionType type { get; set; }

        /// <summary>
        /// The base rate of tax specific to this jurisdiction.
        /// </summary>
        public Decimal? rate { get; set; }

        /// <summary>
        /// The "Sales" tax rate specific to this jurisdiction.
        /// </summary>
        public Decimal? salesRate { get; set; }

        /// <summary>
        /// The Avalara-supplied signature code for this jurisdiction.
        /// </summary>
        public String signatureCode { get; set; }

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
        /// The "Seller's Use" tax rate specific to this jurisdiction.
        /// </summary>
        public Decimal? useRate { get; set; }

        /// <summary>
        /// The city name of this jurisdiction
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// The county name of this jurisdiction
        /// </summary>
        public String county { get; set; }

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
        /// A short name of the jurisidiction
        /// </summary>
        public String shortName { get; set; }

        /// <summary>
        /// State FIPS code
        /// </summary>
        public String stateFips { get; set; }

        /// <summary>
        /// County FIPS code
        /// </summary>
        public String countyFips { get; set; }

        /// <summary>
        /// City FIPS code
        /// </summary>
        public String placeFips { get; set; }

        /// <summary>
        /// Unique AvaTax Id of this Jurisdiction
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The date this jurisdiction starts to take effect on tax calculations
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The date this jurisdiction stops to take effect on tax calculations
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The isAcm specific to this jurisdiction.
        /// </summary>
        public Boolean? isAcm { get; set; }

        /// <summary>
        /// The isSst specific to this jurisdiction.
        /// </summary>
        public Boolean? isSst { get; set; }

        /// <summary>
        /// The CreateDate specific to this jurisdiction.
        /// </summary>
        public DateTime? createDate { get; set; }

        /// <summary>
        /// IsLocalAdmin.
        /// </summary>
        public Boolean? isLocalAdmin { get; set; }

        /// <summary>
        /// ModifiedDate
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// TaxAuthorityTypeId.
        /// </summary>
        public Int32? taxAuthorityTypeId { get; set; }


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
