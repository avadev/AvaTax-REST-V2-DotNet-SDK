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
        ///When creating or updating a tax rule, you may specify either the taxCodeId value or the taxCode value.
        /// </summary>
        public Int32? taxCodeId { get; set; }

        /// <summary>
        /// The code string of the tax code for this rule.
        ///When creating or updating a tax rule, you may specify either the taxCodeId value or the taxCode value.
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
        /// The type of customer usage to which this rule applies.
        /// </summary>
        public String customerUsageType { get; set; }

        /// <summary>
        /// Indicates which tax types to which this rule applies.
        /// </summary>
        public MatchingTaxType? taxTypeId { get; set; }

        /// <summary>
        /// Indicates the rate type to which this rule applies.
        /// </summary>
        public RateType? rateTypeId { get; set; }

        /// <summary>
        /// This type value determines the behavior of the tax rule.
        ///You can specify that this rule controls the product's taxability or exempt / nontaxable status, the product's rate 
        ///(for example, if you have been granted an official ruling for your product's rate that differs from the official rate), 
        ///or other types of behavior.
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
        /// The two character ISO 3166 country code for the locations where this rule applies.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The state, region, or province name for the locations where this rule applies.
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
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
