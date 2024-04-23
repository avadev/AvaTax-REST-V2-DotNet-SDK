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
    /// Model for Advanced Rules when full details are requested
    /// </summary>
    public class AdvancedRuleFullDetailsModel
    {
        /// <summary>
        /// Creator of the rule
        /// </summary>
        public String createdBy { get; set; }

        /// <summary>
        /// When the rule was created
        /// </summary>
        public String createdOn { get; set; }

        /// <summary>
        /// Is this a system rule as opposed to customer-facing
        /// </summary>
        public Boolean? isSystemRule { get; set; }

        /// <summary>
        /// Is the rule displayed in the CUP UI
        /// </summary>
        public Boolean? isVisibleInCUP { get; set; }

        /// <summary>
        /// Is this a rule created for testing
        /// </summary>
        public Boolean? isTest { get; set; }

        /// <summary>
        /// The JSON schema for customer data if it is required for the rule
        /// </summary>
        public String customerDataSchema { get; set; }

        /// <summary>
        /// The version of the rule
        /// </summary>
        public Int32? version { get; set; }

        /// <summary>
        /// Unique identifier for a rule
        /// </summary>
        public String ruleId { get; set; }

        /// <summary>
        /// Rule name
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Description of the rule
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// Advance Rules limited availability
        /// </summary>
        public Boolean? arEntitlementRequired { get; set; }

        /// <summary>
        /// Execution position. Both, Before or After
        /// </summary>
        public String executionPosition { get; set; }


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
