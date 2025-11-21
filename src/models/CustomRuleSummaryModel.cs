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
    /// Base model for custom rules that can be either DynamicRuleModel or AdvancedRuleExecutionModel or TaxRuleModel
    /// </summary>
    public class CustomRuleSummaryModel
    {
        /// <summary>
        /// The unique identifier for this custom rule summary
        /// </summary>
        public String id { get; set; }

        /// <summary>
        /// The company ID that the custom rule belongs to
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The status of the custom rule
        /// </summary>
        public CustomRuleStatus? status { get; set; }

        /// <summary>
        /// The type of custom rule
        /// </summary>
        public CustomRuleType? type { get; set; }

        /// <summary>
        /// The subtypes of the custom rule
        /// </summary>
        public CustomRuleSubtype? subtype { get; set; }

        /// <summary>
        /// The description of the subtypes of the custom rule
        /// </summary>
        public List<String> subtypeDescription { get; set; }

        /// <summary>
        /// Name or ISO 3166 codes identifying the region where this rule will apply.
        /// </summary>
        public List<String> country { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the country where this rule will apply.
        /// </summary>
        public List<String> region { get; set; }

        /// <summary>
        /// For rules that apply to a specific tax code only, this specifies which tax code is affected by this rule.
        /// </summary>
        public List<String> taxCode { get; set; }

        /// <summary>
        /// Indicates the codes of the tax type that applies to this rule.
        /// </summary>
        public List<String> taxType { get; set; }

        /// <summary>
        /// The entity use code to which this rule applies.
        /// </summary>
        public List<String> entityUseCode { get; set; }

        /// <summary>
        /// The order of the rule executions (only applies to advanced rules)
        /// </summary>
        public Int32? order { get; set; }

        /// <summary>
        /// The first date at which this rule applies. If null, this rule will apply to all dates prior to the end date.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The last date for which this rule applies. If null, this rule will apply to all dates after the effective date.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The date the rule was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The date the rule was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The rule entity data, which can be either a TaxRuleModel, a DynamicRuleModel, or an AdvancedRuleExecutionModel
        /// </summary>
        public object ruleEntity { get; set; }


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
