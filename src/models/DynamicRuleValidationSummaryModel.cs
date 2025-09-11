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
    /// Represents a summary of the validation results for a dynamic rule.
    /// </summary>
    public class DynamicRuleValidationSummaryModel
    {
        /// <summary>
        /// A high-level message describing the overall validation status.
        /// For example, "Errors are present, do not save rule."
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// The total number of errors found during validation.
        /// </summary>
        public Int32? errorCount { get; set; }

        /// <summary>
        /// The total number of warnings found during validation.
        /// </summary>
        public Int32? warningCount { get; set; }

        /// <summary>
        /// The total number of informational messages generated during validation.
        /// </summary>
        public Int32? infoCount { get; set; }

        /// <summary>
        /// The total number of tax rules that would be generated or affected by this dynamic rule.
        /// </summary>
        public Int32? taxRuleCount { get; set; }


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
