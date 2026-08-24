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
    /// A portable export envelope containing the custom rules (tax rules, custom rules, and
    /// advanced rules) matched by an ExportCustomRules request. This envelope can be re-imported
    /// into another company or account using the CreateCustomRulesBatch endpoint.
    /// </summary>
    public class CustomRulesExportModel
    {
        /// <summary>
        /// The kind of export this payload represents (e.g. "CustomRulesExport").
        /// </summary>
        public String kind { get; set; }

        /// <summary>
        /// The schema version of the export payload.
        /// </summary>
        public String schemaVersion { get; set; }

        /// <summary>
        /// The UTC timestamp when the rules were exported.
        /// </summary>
        public DateTime? exportedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CustomRuleExportUser exportedBy { get; set; }

        /// <summary>
        /// The account the rules were exported from.
        /// </summary>
        public Int64? sourceAccountId { get; set; }

        /// <summary>
        /// The company the rules were exported from.
        /// </summary>
        public Int32? sourceCompanyId { get; set; }

        /// <summary>
        /// The overall filter used to produce the export, if any.
        /// </summary>
        public String filter { get; set; }

        /// <summary>
        /// The tax-rule-specific filter used to produce the export, if any.
        /// </summary>
        public String taxRuleFilter { get; set; }

        /// <summary>
        /// The advanced-rule-specific filter used to produce the export, if any.
        /// </summary>
        public String advancedRuleFilter { get; set; }

        /// <summary>
        /// The custom-rule-specific filter used to produce the export, if any.
        /// </summary>
        public String customRuleFilter { get; set; }

        /// <summary>
        /// The order-by clause used to produce the export, if any.
        /// </summary>
        public String orderBy { get; set; }

        /// <summary>
        /// The page size used when producing the export.
        /// </summary>
        public Int32? top { get; set; }

        /// <summary>
        /// The number of records skipped when producing the export.
        /// </summary>
        public Int32? skip { get; set; }

        /// <summary>
        /// The total number of rules contained in this payload.
        /// </summary>
        public Int32? totalCount { get; set; }

        /// <summary>
        /// The number of traditional tax rules contained in this payload.
        /// </summary>
        public Int32? taxRuleCount { get; set; }

        /// <summary>
        /// The number of custom rules contained in this payload.
        /// </summary>
        public Int32? customRuleCount { get; set; }

        /// <summary>
        /// The number of advanced rules contained in this payload.
        /// </summary>
        public Int32? advancedRuleCount { get; set; }

        /// <summary>
        /// The traditional tax rules matched by this export.
        /// </summary>
        public List<TaxRuleModel> taxRules { get; set; }

        /// <summary>
        /// The custom (graph-based) rules matched by this export.
        /// </summary>
        public List<CustomRuleOutputModel> customRules { get; set; }

        /// <summary>
        /// The advanced rules matched by this export.
        /// </summary>
        public List<AdvancedRuleExecutionModel> advancedRules { get; set; }


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
