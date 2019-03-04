using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2019 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Genevieve Conty
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a tax rule that changes the behavior of Avalara's tax engine for certain products and/or entity use codes
    /// in certain jurisdictions.
    ///  
    /// Avalara supports a few different types of tax rules. For information about tax rule types, see
    /// [TaxRuleTypeId](https://developer.avalara.com/api-reference/avatax/rest/v2/models/enums/TaxRuleTypeId/)
    ///  
    /// Because different types of tax rules have different behavior, some fields may change their behavior based on
    /// the type of tax rule selected. Please read the documentation for each field carefully and ensure that
    /// the value you send is appropriate for the type of tax rule.
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
        public Int32? companyId { get; set; }

        /// <summary>
        /// For rules that apply to a specific tax code only, this specifies which tax code is affected by this rule.
        ///  
        /// You can choose to specify a tax code either by passing its unique ID number in the `taxCodeId` field or
        /// by passing its alphanumeric code in the `taxCode` field. To search for the appropriate tax code for your
        /// custom rule, use the `ListTaxCodes` API.
        ///  
        /// The `RateOverrideRule`, `BaseRule`, and `ExemptEntityRule` rule types can be applied to all tax codes. To
        /// make a rule that applies to all tax codes, leave both fields blank.
        ///  
        /// The `ProductTaxabilityRule` rule must be associated with a tax code. If you attempt to create a product taxability rule
        /// without a tax code, you will get an error message.
        /// </summary>
        public Int32? taxCodeId { get; set; }

        /// <summary>
        /// For rules that apply to a specific tax code only, this specifies which tax code is affected by this rule.
        ///  
        /// You can choose to specify a tax code either by passing its unique ID number in the `taxCodeId` field or
        /// by passing its alphanumeric code in the `taxCode` field. To search for the appropriate tax code for your
        /// custom rule, use the `ListTaxCodes` API.
        ///  
        /// The `RateOverrideRule`, `BaseRule`, and `ExemptEntityRule` rule types can be applied to all tax codes. To
        /// make a rule that applies to all tax codes, leave both fields blank.
        ///  
        /// The `ProductTaxabilityRule` rule must be associated with a tax code. If you attempt to create a product taxability rule
        /// without a tax code, you will get an error message.
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// For U.S. tax rules, this is the state's Federal Information Processing Standard (FIPS) code.
        ///  
        /// This field is required for rules that apply to specific jurisdictions in the United States. It is not required
        /// if you set the `isAllJuris` flag to true.
        /// </summary>
        public String stateFIPS { get; set; }

        /// <summary>
        /// The name of the jurisdiction to which this tax rule applies.
        ///  
        /// Custom tax rules can apply to a specific jurisdiction or to all jurisdictions. To select a jurisdiction, use the
        /// [ListJurisdictions API](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListJurisdictions/)
        /// or the [ListJurisdictionsByAddress API](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListJurisdictionsByAddress/).
        /// To set a rule that applies to all jurisdictions of a specific type, see `isAllJuris`.
        ///  
        /// Once you have determined which jurisdiction you wish to assign to the tax rule, you should fill in the `jurisName`, `jurisCode`, and
        /// `jurisdictionTypeId` fields using the information you retrieved from the API above.
        /// </summary>
        public String jurisName { get; set; }

        /// <summary>
        /// The code of the jurisdiction to which this tax rule applies.
        ///  
        /// Custom tax rules can apply to a specific jurisdiction or to all jurisdictions. To select a jurisdiction, use the
        /// [ListJurisdictions API](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListJurisdictions/)
        /// or the [ListJurisdictionsByAddress API](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListJurisdictionsByAddress/).
        ///  
        /// Once you have determined which jurisdiction you wish to assign to the tax rule, you should fill in the `jurisName`, `jurisCode`, and
        /// `jurisdictionTypeId` fields using the information you retrieved from the API above.
        /// </summary>
        public String jurisCode { get; set; }

        /// <summary>
        /// (DEPRECATED) Please use `jurisdictionTypeId` instead.
        /// </summary>
        public JurisTypeId? jurisTypeId { get; set; }

        /// <summary>
        /// The type of the jurisdiction to which this tax rule applies.
        ///  
        /// Custom tax rules can apply to a specific jurisdiction or to all jurisdictions. To select a jurisdiction, use the
        /// [ListJurisdictions API](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListJurisdictions/)
        /// or the [ListJurisdictionsByAddress API](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListJurisdictionsByAddress/).
        ///  
        /// Once you have determined which jurisdiction you wish to assign to the tax rule, you should fill in the `jurisName`, `jurisCode`, and
        /// `jurisdictionTypeId` fields using the information you retrieved from the API above.
        ///  
        /// To make a custom tax rule for US or Canada that applies to all jurisdictions of a specific type, see the `isAllJuris`
        /// field for more information.
        /// </summary>
        public JurisdictionType? jurisdictionTypeId { get; set; }

        /// <summary>
        /// DEPRECATED - Please use `entityUseCode` instead.
        /// </summary>
        public String customerUsageType { get; set; }

        /// <summary>
        /// The entity use code to which this rule applies.
        ///  
        /// You can create custom `entityUseCode` values with specific behavior using this API, or you can change
        /// the behavior of Avalara's system-defined entity use codes.
        ///  
        /// For a full list of Avalara-defined entity use codes, see the [ListEntityUseCodes API](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListEntityUseCodes/).
        /// </summary>
        public String entityUseCode { get; set; }

        /// <summary>
        /// Some tax type groups contain multiple different types of tax. To create a rule that affects only one
        /// type of tax within a tax type group, set this value to the code matching the specific tax type within
        /// that group. The custom tax rule will then only apply to taxes calculated for that specific type.
        ///  
        /// For rules that affect all tax types, use the value `A` to match `All` tax types within that group.
        /// </summary>
        public MatchingTaxType? taxTypeId { get; set; }

        /// <summary>
        /// (DEPRECATED) Please use `rateTypeCode`, `taxTypeGroup` and `subTaxType` instead.
        /// </summary>
        public RateType? rateTypeId { get; set; }

        /// <summary>
        /// Indicates the code of the rate type that applies to this rule. Use [ListRateTypesByCountry](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListRateTypesByCountry/) API for a full list of rate type codes.
        ///  
        /// If you specify a value in the rateTypeCode field, this rule will cause tax lines that are affected by the rule
        /// to change to a different rate type code.
        /// </summary>
        public String rateTypeCode { get; set; }

        /// <summary>
        /// This type value determines the behavior of the tax rule.
        ///  
        /// You can specify that this rule controls the product's taxability or exempt / nontaxable status, the product's rate
        /// (for example, if you have been granted an official ruling for your product's rate that differs from the official rate),
        /// or other types of behavior.
        /// </summary>
        public TaxRuleTypeId taxRuleTypeId { get; set; }

        /// <summary>
        /// Allows you to make tax rules apply to lower jurisdictions. This feature is only available in the United States and Canada.
        ///  
        /// * In the United States, this value can be used for rules written at the `State` jurisdictional level. If set to `true`, this rule will at the state level, county level, city level, and special jurisdiction level.
        /// * In Canada, this value can be used for rules written at the `Country` or `State` jurisdictional levels. If set to `true`, this rule will at all lower jurisdictional levels.
        ///  
        /// For any other use case, this value must be `false`.
        /// </summary>
        public Boolean? isAllJuris { get; set; }

        /// <summary>
        /// This field has different behavior based on the type of the tax rule.
        ///  
        /// * For a product taxability rule, this value is either 1 or 0, indicating taxable or non-taxable.
        /// * For a rate override rule, this value is the corrected rate stored as a decimal, for example, a rate of 5% would be stored as 0.05 decimal. If you use the special value of 1.0, only the cap and threshold values will be applied and the rate will be left alone.
        /// </summary>
        public Decimal? value { get; set; }

        /// <summary>
        /// The maximum cap for the price of this item according to this rule. Any amount above this cap will not be subject to this rule.
        ///  
        /// For example, if you must pay 5% of a product's value up to a maximum value of $1000, you would set the `cap` to `1000.00` and the `value` to `0.05`.
        /// </summary>
        public Decimal? cap { get; set; }

        /// <summary>
        /// The per-unit threshold that must be met before this rule applies.
        ///  
        /// For example, if your product is nontaxable unless it is above $100 per product, you would set the `threshold` value to `100`. In this case, the rate
        /// for the rule would apply to the entire amount above $100.
        ///  
        /// You can also create rules that make the entire product taxable if it exceeds a threshold, but is nontaxable
        /// if it is below the threshold. To choose this, set the `options` field to the value `TaxAll`.
        /// </summary>
        public Decimal? threshold { get; set; }

        /// <summary>
        /// Supports custom options for your tax rule.
        ///  
        /// Supported options include:
        /// * `TaxAll` - This value indicates that the entire amount of the line becomes taxable when the line amount exceeds the `threshold`.
        /// </summary>
        public String options { get; set; }

        /// <summary>
        /// The first date at which this rule applies. If `null`, this rule will apply to all dates prior to the end date.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The last date for which this rule applies. If `null`, this rule will apply to all dates after the effective date.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// A friendly name for this tax rule.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// For U.S. tax rules, this is the county's Federal Information Processing Standard (FIPS) code.
        ///  
        /// This field is required for rules that apply to specific jurisdictions in the United States. It is not required
        /// if you set the `isAllJuris` flag to true.
        /// </summary>
        public String countyFIPS { get; set; }

        /// <summary>
        /// (DEPRECATED) This field is no longer required.
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
        /// NOTE: Region is required for US and not required for non-US countries because the user may be either creating a Country-level or Region-level rule.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// The sourcing types to which this rule applies.
        /// </summary>
        public Sourcing? sourcing { get; set; }

        /// <summary>
        /// This field has different behavior based on the type of rule.
        ///  
        /// * For a product taxability rule, if the rule applies to an item, this value will override the tax type group of the original product.
        /// * For other rules, this value determines what tax type groups will be affected by the rule.
        ///  
        /// Refer to `ListTaxTypeGroups` for a list of tax type groups supported by AvaTax.
        /// </summary>
        public String taxTypeGroup { get; set; }

        /// <summary>
        /// This field has different behavior based on the type of rule.
        ///  
        /// * For a product taxability rule, if the rule applies to an item, this value will override the tax sub type of the original product.
        /// * For other rules, this value determines what tax sub types will be affected by the rule.
        ///  
        /// Refer to `ListTaxSubtypes` for a list of tax sub types supported by AvaTax.
        /// </summary>
        public String taxSubType { get; set; }

        /// <summary>
        /// Reserved for Avalara internal usage. Leave this field null.
        /// </summary>
        public String nonPassthroughExpression { get; set; }

        /// <summary>
        /// The currency code to use for this rule.
        ///  
        /// For a list of currencies supported by AvaTax, use the [ListCurrencies API](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListCurrencies/).
        /// </summary>
        public String currencyCode { get; set; }

        /// <summary>
        /// Reserved for Avalara internal usage. Leave this field null.
        /// </summary>
        public Int32? preferredProgramId { get; set; }

        /// <summary>
        /// For tax rules that are calculated using units of measurement, this indicates the unit of measurement type
        /// used to calculate the amounts for this rule.
        ///  
        /// For a list of units of measurement, use the [ListUnitsOfMeasurement API](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListUnitOfMeasurement/).
        /// </summary>
        public Int32? uomId { get; set; }

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
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
