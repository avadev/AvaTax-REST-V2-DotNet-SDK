using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
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
    /// Rate type Model
    /// </summary>
    public class RateTypeModel
    {
        /// <summary>
        /// The unique ID number of this rate type.
        /// </summary>
        public String id { get; set; }

        /// <summary>
        /// Description of this rate type.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// Country code for this rate type
        /// </summary>
        public String country { get; set; }


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
