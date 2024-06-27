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
    /// Defines a country as known to Avalara's certificate management system.
    /// </summary>
    public class CountryModel
    {
        /// <summary>
        /// The unique ID number of this country as defined in Avalara's certificate management system.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The name of this country in US English.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The three-character ISO 3166 code for this country.
        /// </summary>
        public String initials { get; set; }

        /// <summary>
        /// The two-character ISO 3166 code for this country.
        /// </summary>
        public String abbreviation { get; set; }


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
