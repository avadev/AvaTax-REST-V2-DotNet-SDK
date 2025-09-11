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
    /// Represents the complete validation result for a dynamic rule, including a summary,
    /// individual messages, an execution plan, and affected tax rules.
    /// </summary>
    public class DynamicRuleValidationResultModel
    {
        /// <summary>
        /// 
        /// </summary>
        public DynamicRuleValidationSummaryModel summary { get; set; }

        /// <summary>
        /// A list of detailed validation messages (errors, warnings, info).
        /// </summary>
        public List<DynamicRuleValidationMessageModel> messages { get; set; }

        /// <summary>
        /// A list of steps outlining the execution plan for the dynamic rule.
        /// This can help in understanding how the rule will be processed.
        /// </summary>
        public List<DynamicRuleValidationPlanStepModel> executionPlan { get; set; }

        /// <summary>
        /// A list of tax rules that would be generated or affected by this dynamic rule if it were saved.
        /// </summary>
        public List<DynamicRuleGeneratedTaxRuleModel> taxRules { get; set; }

        /// <summary>
        /// The list of lookup files used by this rule.
        /// </summary>
        public List<String> lookupFilesUsed { get; set; }


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
