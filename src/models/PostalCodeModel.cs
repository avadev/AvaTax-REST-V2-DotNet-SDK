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
    /// Represents a PostalCode and its associated data like: country, region, effective dates, etc.
    /// </summary>
    public class PostalCodeModel
    {
        /// <summary>
        /// Country this PostalCode locates in
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The Region/State/Province this PostalCode locates in
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// An Avalara assigned TaxRegion Id associated to the PostalCode
        /// </summary>
        public Int32? taxRegionId { get; set; }

        /// <summary>
        /// The date when the PostalCode becomes effective
        /// </summary>
        public DateTime? effDate { get; set; }

        /// <summary>
        /// The date when the PostalCode becomes expired
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The postalCode
        /// </summary>
        public String postalCode { get; set; }


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
