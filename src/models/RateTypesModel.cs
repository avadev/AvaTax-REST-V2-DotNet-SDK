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
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Rate types Model
    /// </summary>
    public class RateTypesModel
    {
        /// <summary>
        /// The unique ID number of this rate type.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The name of this rateType
        /// </summary>
        public String rateType { get; set; }

        /// <summary>
        /// The description of this rate type.
        /// </summary>
        public String description { get; set; }


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
