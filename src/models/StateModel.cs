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
    /// Defines a state, region, or province as known to Avalara's certificate management system.
    /// </summary>
    public class StateModel
    {
        /// <summary>
        /// A unique ID number that represents this state, region, or province.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The state, region, or province name as known in US English.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The abbreviated two or three character ISO 3166 state, province, or region code.
        /// </summary>
        public String initials { get; set; }

        /// <summary>
        /// A geocoding identification number for this state
        /// </summary>
        public Int32? geoCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CountryModel country { get; set; }


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
