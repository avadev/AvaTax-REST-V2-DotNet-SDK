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
        public JurisdictionType? type { get; set; }

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
        /// The state assigned code for this jurisdiction, if any.
        /// </summary>
        public String stateCode { get; set; }

        /// <summary>
        /// The "Seller's Use" tax rate specific to this jurisdiction.
        /// </summary>
        public Decimal? useRate { get; set; }


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
