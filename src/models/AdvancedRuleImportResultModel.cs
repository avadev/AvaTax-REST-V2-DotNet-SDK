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
    /// Model for the results of importing a single rule execution with the Advanced Rules bulk import API
    /// </summary>
    public class AdvancedRuleImportResultModel
    {
        /// <summary>
        /// Name of rule execution
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Import result status code (e.g. Success, ValidationFailed, NotCreated, etc.)
        /// </summary>
        public String importResult { get; set; }

        /// <summary>
        /// Import result status message (e.g. list of validation errors)
        /// </summary>
        public String importDetails { get; set; }

        /// <summary>
        /// Rule execution unique identifier
        /// </summary>
        public String ruleExecutionId { get; set; }

        /// <summary>
        /// Unique identifier of rule to execute
        /// </summary>
        public String ruleId { get; set; }


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
