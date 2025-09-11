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
    /// Represents a single validation message for a dynamic rule.
    /// </summary>
    public class DynamicRuleValidationMessageModel
    {
        /// <summary>
        /// The severity level of the message (error, warning, or info).
        /// </summary>
        public String level { get; set; }

        /// <summary>
        /// The detailed message content.
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// An optional reference indicating what part of the rule or configuration this message pertains to.
        /// This is usually a node identifier, but may be empty if the message is not related to a specific node.
        /// </summary>
        public String refersTo { get; set; }


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
