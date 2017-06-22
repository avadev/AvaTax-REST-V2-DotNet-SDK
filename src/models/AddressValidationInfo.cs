using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// TextCase info for input address
    /// </summary>
    public class AddressValidationInfo
    {
        /// <summary>
        /// Specify the text case for the validated address result. If not specified, will return uppercase.
        /// </summary>
        public TextCase? textCase { get; set; }

        /// <summary>
        /// First line of the street address
        /// </summary>
        public String line1 { get; set; }

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
        /// State / Province / Region component of the address.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// Two character ISO 3166 Country Code. Call `ListCountries` for a list of ISO 3166 country codes.
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
