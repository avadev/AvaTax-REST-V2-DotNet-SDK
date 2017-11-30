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
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a region, province, or state within a country
    /// </summary>
    public class IsoRegionModel
    {
        /// <summary>
        /// The two-character ISO 3166 country code this region belongs to
        /// </summary>
        public String countryCode { get; set; }

        /// <summary>
        /// The three character ISO 3166 region code
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// The full name, using localized characters, for this region, in uppercase.
        /// 
        /// For names in proper or formal case, or for names in other languages, please examine the `localizedNames` element for an appropriate name.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The word in the local language that classifies what type of a region this represents
        /// </summary>
        public String classification { get; set; }

        /// <summary>
        /// For the United States, this flag indicates whether a U.S. State participates in the Streamlined
        /// Sales Tax program. For countries other than the US, this flag is null.
        /// </summary>
        public Boolean? streamlinedSalesTax { get; set; }

        /// <summary>
        /// A list of localized names in a variety of languages.
        /// 
        /// This list is maintained by the International Standards Organization.
        /// </summary>
        public List<IsoLocalizedName> localizedNames { get; set; }


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
