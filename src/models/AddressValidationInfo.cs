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
        /// selectable textcase
        /// </summary>
        public String textCase { get; set; }

        /// <summary>
        /// Line1
        /// </summary>
        public String line1 { get; set; }

        /// <summary>
        /// Line2
        /// </summary>
        public String line2 { get; set; }

        /// <summary>
        /// Line3
        /// </summary>
        public String line3 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// State / Province / Region
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// Two character ISO 3166 Country Code
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Postal Code / Zip Code
        /// </summary>
        public String postalCode { get; set; }

        /// <summary>
        /// Geospatial latitude measurement
        /// </summary>
        public Decimal? latitude { get; set; }

        /// <summary>
        /// Geospatial longitude measurement
        /// </summary>
        public Decimal? longitude { get; set; }

        /// <summary>
        /// Address type code. One of: 
        ///* F - Firm or company address
        ///* G - General Delivery address
        ///* H - High-rise or business complex
        ///* P - PO Box address
        ///* R - Rural route address
        ///* S - Street or residential address
        /// </summary>
        public String addressType { get; set; }


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
