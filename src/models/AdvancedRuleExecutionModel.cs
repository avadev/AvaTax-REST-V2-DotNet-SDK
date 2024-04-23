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
        /// 
        /// </summary>
        public AdvancedRuleModel rule { get; set; }

        /// <summary>
        /// Json data used for rule execution
        /// </summary>
        public String customerData { get; set; }

        /// <summary>
        /// Unique identifier of customer data used in rule execution
        /// </summary>
        public String customerDataId { get; set; }

        /// <summary>
        /// Creator of the rule
        /// </summary>
        public String createdBy { get; set; }

        /// <summary>
        /// When the rule execution was created
        /// </summary>
        public String createdOn { get; set; }

        /// <summary>
        /// Last updater of the rule execution
        /// </summary>
        public String modifiedBy { get; set; }

        /// <summary>
        /// When the rule execution was last updated
        /// </summary>
        public String modifiedOn { get; set; }


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
