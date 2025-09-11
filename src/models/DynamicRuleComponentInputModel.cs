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
    /// Represents a component within a Dynamic Rule definition.
    /// Components define the logic and flow of a rule, and include condition nodes, action nodes, and rule-wide variables.
    /// </summary>
    public class DynamicRuleComponentInputModel
    {
        /// <summary>
        /// Unique identifier for the component.
        /// This ID is used to reference the component and establish connections
        /// between components via the 'next' property.
        /// </summary>
        public String id { get; set; }

        /// <summary>
        /// The primary type of the component, determining its role in the rule execution.
        /// This is typically one of the following: Condition, Action, or Variable.
        /// </summary>
        public DynamicRuleComponentType type { get; set; }

        /// <summary>
        /// The specific subtype of the component, providing more detailed classification
        /// within the main type. For example, a Condition type might have subtypes like
        /// MatchCustomerCode, MatchProductCode, etc.
        /// The subtype determines the expected format of the data property.
        /// </summary>
        public DynamicRuleComponentSubtype subtype { get; set; }

        /// <summary>
        /// JSON-formatted string containing the configuration data for the component.
        /// The structure of this data varies based on the component type and subtype.
        /// For example, a MatchCustomerCode condition might contain an array of customer codes to match against.
        /// </summary>
        public String data { get; set; }

        /// <summary>
        /// Array of component IDs that represent the next components in the rule execution flow.
        /// This property defines the outgoing edges in the rule graph, allowing for
        /// conditional branching and sequential processing of components.
        /// </summary>
        public List<String> next { get; set; }


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
