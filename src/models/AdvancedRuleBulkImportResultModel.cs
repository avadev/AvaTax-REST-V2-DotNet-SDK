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
    /// Output model for the Advanced Rules bulk import API
    /// </summary>
    public class AdvancedRuleBulkImportResultModel
    {
        /// <summary>
        /// Aggregated import result code
        /// </summary>
        public BulkImportStatus? importResult { get; set; }

        /// <summary>
        /// Aggregated import result message
        /// </summary>
        public String importMessage { get; set; }

        /// <summary>
        /// Import results for individual rule executions
        /// </summary>
        public List<AdvancedRuleImportResultModel> executions { get; set; }


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
