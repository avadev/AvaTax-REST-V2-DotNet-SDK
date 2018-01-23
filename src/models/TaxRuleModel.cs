using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a tax rule that changes the behavior of Avalara's tax engine for certain products in certain jurisdictions.
    /// </summary>
    public class TaxRuleModel
    {
        /// <summary>
        /// The unique ID number of this tax rule.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The unique ID number of the company that owns this tax rule.
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// The unique ID number of the tax code for this rule.
        /// When creating or updating a tax rule, you may specify either the taxCodeId value or the taxCode value.
        /// </summary>
        public Int32? taxCodeId { get; set; }

        /// <summary>
        /// The code string of the tax code for this rule.
        /// When creating or updating a tax rule, you may specify either the taxCodeId value or the taxCode value.
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// For U.S. tax rules, this is the state's Federal Information Processing Standard (FIPS) code.
        /// </summary>
        public String stateFIPS { get; set; }

        /// <summary>
        /// The name of the jurisdiction to which this tax rule applies.
        /// </summary>
        public String jurisName { get; set; }

        /// <summary>
        /// The code of the jurisdiction to which this tax rule applies.
        /// </summary>
        public String jurisCode { get; set; }

        /// <summary>
        /// The type of the jurisdiction to which this tax rule applies.
        /// </summary>
        public JurisTypeId? jurisTypeId { get; set; }

        /// <summary>
        /// DEPRECATED - The type of customer usage to which this rule applies.
        /// Please use entityUseCode instead.
        /// </summary>
        public String customerUsageType { get; set; }

        /// <summary>
        /// The type of customer usage to which this rule applies.
        /// </summary>
        public String entityUseCode { get; set; }

        /// <summary>
        /// Indicates which tax types to which this rule applies.
        /// </summary>
        public MatchingTaxType? taxTypeId { get; set; }

        /// <summary>
        /// (DEPRECATED) Enumerated rate type to which this rule applies. Please use rateTypeCode instead.
        /// </summary>
        public RateType? rateTypeId { get; set; }

        /// <summary>
        /// Indicates the code of the rate type that applies to this rule. Use `/api/v2/definitions/ratetypes` for a full list of rate type codes.
        /// </summary>
        public String rateTypeCode { get; set; }

        /// <summary>
        /// This type value determines the behavior of the tax rule.
        /// You can specify that this rule controls the product's taxability or exempt / nontaxable status, the product's rate 
        /// (for example, if you have been granted an official ruling for your product's rate that differs from the official rate), 
        /// or other types of behavior.
        /// </summary>
        public TaxRuleTypeId? taxRuleTypeId { get; set; }

        /// <summary>
        /// Set this value to true if this tax rule applies in all jurisdictions.
        /// </summary>
        public Boolean? isAllJuris { get; set; }

        /// <summary>
        /// The corrected rate for this tax rule.
        /// </summary>
        public Decimal? value { get; set; }

        /// <summary>
        /// The maximum cap for the price of this item according to this rule.
        /// </summary>
        public Decimal? cap { get; set; }

        /// <summary>
        /// The per-unit threshold that must be met before this rule applies.
        /// </summary>
        public Decimal? threshold { get; set; }

        /// <summary>
        /// Custom option flags for this rule.
        /// </summary>
        public String options { get; set; }

        /// <summary>
        /// The first date at which this rule applies. If null, this rule will apply to all dates prior to the end date.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The last date for which this rule applies. If null, this rule will apply to all dates after the effective date.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// A friendly name for this tax rule.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// For U.S. tax rules, this is the county's Federal Information Processing Standard (FIPS) code.
        /// </summary>
        public String countyFIPS { get; set; }

        /// <summary>
        /// If true, indicates this rule is for Sales Tax Pro.
        /// </summary>
        public Boolean? isSTPro { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the country where this rule will apply.
        /// 
        /// This field supports many different country identifiers:
        ///  * Two character ISO 3166 codes
        ///  * Three character ISO 3166 codes
        ///  * Fully spelled out names of the country in ISO supported languages
        ///  * Common alternative spellings for many countries
        /// 
        /// For a full list of all supported codes and names, please see the Definitions API `ListCountries`.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the region where this rule will apply.
        /// 
        /// This field supports many different region identifiers:
        ///  * Two and three character ISO 3166 region codes
        ///  * Fully spelled out names of the region in ISO supported languages
        ///  * Common alternative spellings for many regions
        /// 
        /// For a full list of all supported codes and names, please see the Definitions API `ListRegions`.
        /// NOTE: Region is not required for non-US countries because the user may be either creating a Country-level or Region-level rule.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// The sourcing types to which this rule applies.
        /// </summary>
        public Sourcing? sourcing { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The User ID of the user who created this record.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }

        /// <summary>
        /// The group Id of tax types supported by Avalara. Refer to /api/v2/definitions/taxtypegroups for types we support.
        /// </summary>
        public String taxTypeGroup { get; set; }

        /// <summary>
        /// The Id of sub tax types supported by Avalara. Refer to /api/v2/definitions/taxsubtypes for types we support.
        /// </summary>
        public String taxSubType { get; set; }

        /// <summary>
        /// Id for TaxTypeMapping object
        /// </summary>
        public Int32? taxTypeMappingId { get; set; }

        /// <summary>
        /// Id for RateTypeTaxTypeMapping object
        /// </summary>
        public Int32? rateTypeTaxTypeMappingId { get; set; }

        /// <summary>
        /// Indicates the expression to use to determine whether this tax rule generates a non-passthrough tax.
        /// 
        /// Non-passthrough taxes are taxes that cannot be charged to the customer.
        /// </summary>
        public String nonPassthroughExpression { get; set; }

        /// <summary>
        /// The currency code to use for this rule.
        /// </summary>
        public String currencyCode { get; set; }

        /// <summary>
        /// For rules that only apply to one tax code program, this value indicates what program should be used for implementing this rule.
        /// </summary>
        public Int32? preferredProgramId { get; set; }

        /// <summary>
        /// For tax rules that are calculated using units of measurement, this indicates the unit of measurement type
        /// used to calculate the amounts for this rule.
        /// 
        /// For a list of units of measurement, please call `ListUnitsOfMeasurement()`.
        /// </summary>
        public Int32? uomId { get; set; }


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
