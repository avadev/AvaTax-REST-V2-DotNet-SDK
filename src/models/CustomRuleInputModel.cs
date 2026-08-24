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
    /// A Custom Rule customizes AvaTax's default tax calculation to match a company's specific requirements.
    /// It is composed of modular conditions and actions that can adjust an item's taxability, tax base, and tax rate,
    /// modify transaction fields and addresses, allocate or split line items, update location codes, and more.
    /// </summary>
    public class CustomRuleInputModel
    {
        /// <summary>
        /// Unique integer ID for this rule.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CustomRuleDefinitionInputModel definition { get; set; }

        /// <summary>
        /// The name of the rule. Must be unique within a company.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Optional description of the rule.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The first date at which this rule applies.
        /// Within each execution step, each rule executes in effective date order by default.
        /// Rules effective on the same date execute alphabetically based on their name.
        /// </summary>
        public DateTime effectiveDate { get; set; }

        /// <summary>
        /// The last date for which this rule applies.
        /// This must be on or after the effective date for the rule to be valid.
        /// </summary>
        public DateTime endDate { get; set; }

        /// <summary>
        /// Whether the rule is ever allowed to execute.
        /// </summary>
        public Boolean enabled { get; set; }

        /// <summary>
        /// Whether to continue the transaction if this rule fails.
        /// If set to `false`, a failure will cause the entire transaction to return an error.
        /// If set to `true`, a failure will only stop execution of this rule.
        /// </summary>
        public Boolean continueOnError { get; set; }

        /// <summary>
        /// Whether this is a draft rule. Draft rules are not executed
        /// on transactions by default. To execute a draft rule,
        /// it must be enabled and the `TestTransaction` endpoint
        /// must be used with appropriate settings.
        /// </summary>
        public Boolean? isDraft { get; set; }


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
