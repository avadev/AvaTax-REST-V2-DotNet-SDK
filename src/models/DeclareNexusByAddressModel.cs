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
    /// Use this object to provide an address and date range where your company does business.
    /// This address will be used to determine what jurisdictions you should declare nexus and
    /// calculate tax.
    /// </summary>
    public class DeclareNexusByAddressModel
    {
        /// <summary>
        /// The earliest date on which your company does business at this address. If you omit
        /// a value in this field, nexus will be declared at the earliest possible date for this
        /// jurisdiction.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The date on which your company stopped doing business at this address, or empty if
        /// your company has no plans to stop doing business at this address.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// First line of the street address
        /// </summary>
        public String line1 { get; set; }

        /// <summary>
        /// Specify the text case for the validated address result. If not specified, will return uppercase.
        /// </summary>
        public TextCase? textCase { get; set; }

        /// <summary>
        /// Second line of the street address
        /// </summary>
        public String line2 { get; set; }

        /// <summary>
        /// Third line of the street address
        /// </summary>
        public String line3 { get; set; }

        /// <summary>
        /// City component of the address
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
        /// Name or ISO 3166 code identifying the country.
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
        /// Postal Code / Zip Code component of the address.
        /// </summary>
        public String postalCode { get; set; }

        /// <summary>
        /// Geospatial latitude measurement, in Decimal Degrees floating point format.
        /// </summary>
        public Decimal? latitude { get; set; }

        /// <summary>
        /// Geospatial longitude measurement, in Decimal Degrees floating point format.
        /// </summary>
        public Decimal? longitude { get; set; }


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
