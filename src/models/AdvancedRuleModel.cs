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
    /// A generic global advanced rule encapsulating a script
    /// </summary>
    public class AdvancedRuleModel
    {
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
