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
    /// Represents a System Country.
    /// </summary>
    public class ProductSystemCountryModel
    {
        /// <summary>
        /// Its Integer SystemCountryId value for SystemCountry
        /// </summary>
        public Int32? systemCountryId { get; set; }

        /// <summary>
        /// Its Integer SystemId value for SystemCountry
        /// </summary>
        public Int32? systemId { get; set; }

        /// <summary>
        /// string value of country code for SystemCountry
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// DateTime as EffDate for SystemCountry
        /// </summary>
        public DateTime? effDate { get; set; }

        /// <summary>
        /// DateTime as EffDate for SystemCountry
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
