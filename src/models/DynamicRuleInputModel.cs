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
    /// A Dynamic Rule is a type of a custom rule which is similar to an Advanced Rule, but
    /// has a graph-based execution flow made up of modular Conditions and Actions that may
    /// be linked to one or more traditional custom Tax Rules.
    /// </summary>
    public class DynamicRuleInputModel
    {
        /// <summary>
        /// 
        /// </summary>
        public DynamicRuleDefinitionInputModel definition { get; set; }

        /// <summary>
        /// The name of the execution
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The description of the execution
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The start date when the execution is valid
        /// </summary>
        public DateTime effectiveDate { get; set; }

        /// <summary>
        /// The end date when the execution is valid
        /// </summary>
        public DateTime endDate { get; set; }

        /// <summary>
        /// Whether the execution is enabled
        /// </summary>
        public Boolean enabled { get; set; }

        /// <summary>
        /// Whether to continue execution if this rule fails
        /// </summary>
        public Boolean continueOnError { get; set; }


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
