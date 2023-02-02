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
    /// Represents item tax code model
    /// </summary>
    public class ItemTaxCodeModel
    {
        /// <summary>
        /// Suggested tax code
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// Suggested tax code description
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// Priority of Suggested tax code description
        /// </summary>
        public Int32? rank { get; set; }


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
