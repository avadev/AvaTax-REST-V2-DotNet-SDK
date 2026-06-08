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
    /// One tax type + subtype combination for a jurisdiction.
    /// </summary>
    public class JurisdictionTaxTypesAndSubTypesModel
    {
        /// <summary>
        /// ID of the tax type.
        /// </summary>
        public String taxTypeId { get; set; }

        /// <summary>
        /// Text description of the tax type.
        /// </summary>
        public String taxTypeDescription { get; set; }

        /// <summary>
        /// ID of the tax subtype.
        /// </summary>
        public String taxSubTypeId { get; set; }

        /// <summary>
        /// Text description of the tax subtype.
        /// </summary>
        public String taxSubTypeDescription { get; set; }

        /// <summary>
        /// Summary tax type display name derived from tax type and subtype.
        /// </summary>
        public String jurisdictionTaxTypeSubtypeDescription { get; set; }

        /// <summary>
        /// Populated when `$includeRateTypes=true` (default). Empty when rate types are omitted.
        /// </summary>
        public List<RateTypesModel> rateTypes { get; set; }


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
