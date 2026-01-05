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
    /// Represents HS Code Restriction Details.
    /// </summary>
    public class ItemHSCodeRestrictionDetailModel
    {
        /// <summary>
        /// The type of restriction.
        /// </summary>
        public String type { get; set; }

        /// <summary>
        /// The regulation governing this restriction.
        /// </summary>
        public String regulation { get; set; }

        /// <summary>
        /// The name of the restriction.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The summary of the restriction.
        /// </summary>
        public String summary { get; set; }

        /// <summary>
        /// The government agency responsible for this restriction.
        /// </summary>
        public String governmentAgency { get; set; }

        /// <summary>
        /// The compliance title.
        /// </summary>
        public String complianceTitle { get; set; }

        /// <summary>
        /// The compliance message.
        /// </summary>
        public String complianceMessage { get; set; }

        /// <summary>
        /// The compliance citation or reference.
        /// </summary>
        public String complianceCitation { get; set; }


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
