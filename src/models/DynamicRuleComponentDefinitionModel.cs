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
    /// Represents the definition and schema of a Dynamic Rule component.
    /// </summary>
    public class DynamicRuleComponentDefinitionModel
    {
        /// <summary>
        /// The primary type of the component, determining its role in the rule execution.
        /// This is typically one of the following: Condition, Action, or Variable.
        /// </summary>
        public DynamicRuleComponentType? type { get; set; }

        /// <summary>
        /// The specific subtype of the component, providing more detailed classification
        /// within the main type. For example, a Condition type might have subtypes like
        /// MatchCustomerCode, MatchProductCode, etc.
        /// The subtype determines the expected format of the data property.
        /// </summary>
        public DynamicRuleComponentSubtype? subtype { get; set; }

        /// <summary>
        /// Display name of this component
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// A description of the component's purpose and usage
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The JSON schema defining the component's configuration structure, as a string
        /// </summary>
        public String dataSchema { get; set; }

        /// <summary>
        /// The execution steps in which the component is usable
        /// </summary>
        public List<String> validSteps { get; set; }

        /// <summary>
        /// Array of node subtypes which are required to be present when this node type is present
        /// </summary>
        public List<String> requires { get; set; }


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
