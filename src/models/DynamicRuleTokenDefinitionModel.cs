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
    /// Represents a valid expression token in Dynamic Rules, i.e. the variables, delimited by double curly braces,
    /// that may be used when performing string manipulation or evaluating formulas within a Dynamic Rule.
    /// </summary>
    public class DynamicRuleTokenDefinitionModel
    {
        /// <summary>
        /// Full contents of the token, including the prefix, but excluding functions.
        /// </summary>
        public String token { get; set; }

        /// <summary>
        /// The type of the token before evaluation. Usually this corresponds to the prefix.
        /// </summary>
        public String tokenType { get; set; }

        /// <summary>
        /// The type of the token after evaluation.
        /// </summary>
        public String evaluatedType { get; set; }

        /// <summary>
        /// Filterable token category.
        /// </summary>
        public String category { get; set; }

        /// <summary>
        /// Details about the token's purpose or usage.
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
