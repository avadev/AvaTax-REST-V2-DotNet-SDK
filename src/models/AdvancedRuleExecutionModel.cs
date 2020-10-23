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
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Model representing an execution of an advanced rule for a company
    /// </summary>
    public class AdvancedRuleExecutionModel
    {
        /// <summary>
        /// Rule execution unique identifier
        /// </summary>
        public String ruleExecutionId { get; set; }

        /// <summary>
        /// Name of rule execution
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Date rule execution starts
        /// </summary>
        public DateTime? startDate { get; set; }

        /// <summary>
        /// Date rule execution ends
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Is rule execution enabled
        /// </summary>
        public Boolean? enabled { get; set; }

        /// <summary>
        /// Should we keep running if we hit an exception
        /// </summary>
        public Boolean? continueOnError { get; set; }

        /// <summary>
        /// Unique identifier of rule to execute
        /// </summary>
        public String ruleId { get; set; }

        /// <summary>
        /// Advanced rule to execute
        /// </summary>
        public  rule { get; set; }

        /// <summary>
        /// Json data used for rule execution
        /// </summary>
        public String customerData { get; set; }

        /// <summary>
        /// Unique identifier of customer data used in rule execution
        /// </summary>
        public String customerDataId { get; set; }


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
