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
    /// Represents a create advanced rules batch request model.
    /// </summary>
    public class CreateAdvancedRulesBatchRequestModel
    {
        /// <summary>
        /// The user-friendly readable name for this batch.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Flag to try updating existing rules instead of just append
        /// </summary>
        public Boolean? replaceExisting { get; set; }

        /// <summary>
        /// Any optional flags provided for this batch
        /// </summary>
        public String options { get; set; }

        /// <summary>
        /// List of rule executions to import
        /// </summary>
        public List<AdvancedRuleExecutionModel> executions { get; set; }


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
