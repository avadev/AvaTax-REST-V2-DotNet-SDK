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
    /// Represents a create Custom Rules import batch request model. The payload is the Custom Rules
    /// export envelope (tax rules, dynamic rules, and advanced rules) which is stored as JSON in S3
    /// and processed downstream by BatchV2.
    /// </summary>
    public class CreateCustomRulesBatchRequestModel
    {
        /// <summary>
        /// The user-friendly readable name for this batch. Optional - when omitted it is derived
        /// from Avalara.AvaTax.AccountServices.Models.v2.CreateCustomRulesBatchRequestModel.kind and Avalara.AvaTax.AccountServices.Models.v2.CreateCustomRulesBatchRequestModel.exportedAt.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The kind of export this payload represents (e.g. "CustomRulesExport").
        /// </summary>
        public String kind { get; set; }

        /// <summary>
        /// The schema version of the export payload.
        /// </summary>
        public String schemaVersion { get; set; }

        /// <summary>
        /// The UTC timestamp when the source rules were exported.
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
        /// The dynamic-rule-specific filter used to produce the export, if any.
        /// </summary>
        public String dynamicRuleFilter { get; set; }

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
        /// The number of dynamic rules contained in this payload.
        /// </summary>
        public Int32? dynamicRuleCount { get; set; }

        /// <summary>
        /// The number of advanced rules contained in this payload.
        /// </summary>
        public Int32? advancedRuleCount { get; set; }

        /// <summary>
        /// The traditional tax rules to import. Stored verbatim so downstream processing receives the
        /// exact exported shape.
        /// </summary>
        public List<TaxRuleModel> taxRules { get; set; }

        /// <summary>
        /// The dynamic (graph-based) rules to import. Stored verbatim so downstream processing receives
        /// the exact exported shape.
        /// </summary>
        public List<DynamicRuleInputModel> dynamicRules { get; set; }

        /// <summary>
        /// The advanced rules to import. Stored verbatim so downstream processing receives the exact
        /// exported shape.
        /// </summary>
        public List<AdvancedRuleModel> advancedRules { get; set; }


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
