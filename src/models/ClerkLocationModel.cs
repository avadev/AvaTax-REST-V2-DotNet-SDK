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
    /// Represents a physical location used in exemption certificate management.
    /// </summary>
    public class ClerkLocationModel
    {
        /// <summary>
        /// Unique identifier for the location.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// Display name of the location.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Code used to reference this location.
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// Primary street address of the location.
        /// </summary>
        public String address_line1 { get; set; }

        /// <summary>
        /// Additional address details (e.g., suite, building).
        /// </summary>
        public String address_line2 { get; set; }

        /// <summary>
        /// City in which the location is situated.
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// Postal or ZIP code of the location.
        /// </summary>
        public String zip { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public StateModel state { get; set; }


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
