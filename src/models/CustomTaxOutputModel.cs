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
    /// A Custom Tax represents a tax-rate / taxability / exemption package owned by a single
    /// company. It is a type of Custom Rule that exposes a focused, content-oriented shape for
    /// callers who want to manage tax overrides without constructing a Custom Rule by hand.
    /// <br>
    /// Use of the Custom Tax endpoints requires the `AvaCustomContent` subscription.
    /// <br>
    /// This is the output variant returned by `GetCustomTax`, `ListCustomTaxes`, and
    /// write endpoints that echo the persisted record. It includes system-populated fields such
    /// as `id`, `companyId`, and the created/modified audit fields which are not
    /// accepted on input.
    /// </summary>
    public class CustomTaxOutputModel
    {
        /// <summary>
        /// Unique identifier for this custom tax. Stable for the lifetime of the record and
        /// shared with the broader Custom Rule namespace, so a Custom Tax id is never reused by
        /// another Custom Rule on the same company.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The company ID of the company that owns this custom tax. Returned on output so clients
        /// can correlate the record with its parent company.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The name of the custom tax. Displayed in UI surfaces and used to identify the custom
        /// tax when reviewing rules for a company.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Optional description of the custom tax. Intended for use by compliance and support
        /// teams to document the intent or source of the rule.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The country in which the custom tax applies. This is typically an ISO 3166-1 alpha-2
        /// country code such as `US` or `CA`.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The region or state in which the custom tax applies. The expected value depends on
        /// `country`; for the United States this is typically the two-letter state
        /// abbreviation such as `WA`.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// The tax type for this custom tax.
        /// </summary>
        public String taxTypeCode { get; set; }

        /// <summary>
        /// The tax subtype for this custom tax. Subtypes typically mirror the tax type but may be
        /// customized to describe more granular categories.
        /// </summary>
        public String taxSubType { get; set; }

        /// <summary>
        /// The rate types associated with this custom tax.
        /// </summary>
        public List<String> rateTypeCodes { get; set; }

        /// <summary>
        /// The default unit of basis used to calculate the value of this custom tax. Determines
        /// how the rate on each rate row is interpreted — for example, `PerCurrencyUnit` for
        /// a percentage or `PerUnit` for a flat amount per unit.
        /// </summary>
        public String unitOfBasis { get; set; }

        /// <summary>
        /// The start date when the tax is valid. Transactions with a document date earlier than
        /// this date will not be affected by this custom tax.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The end date when the tax is valid. Transactions with a document date later than this
        /// date will not be affected by this custom tax.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Whether the custom tax is enabled. When false, the tax is persisted but is not
        /// evaluated during tax calculation.
        /// </summary>
        public Boolean? enabled { get; set; }

        /// <summary>
        /// Whether to continue execution if there is an error evaluating the rule criteria. When
        /// true, an error in this custom tax does not stop evaluation of other custom taxes or
        /// custom rules on the transaction.
        /// </summary>
        public Boolean? continueOnError { get; set; }

        /// <summary>
        /// A list of jurisdictions in which this custom tax applies. At least one jurisdiction is
        /// required; each jurisdiction identifies a region of applicability for the tax.
        /// </summary>
        public List<CustomTaxJurisdictionOutputModel> jurisdictions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CustomTaxAdditionalCriteriaOutputModel conditions { get; set; }

        /// <summary>
        /// Define the taxability treatment and rate type assignment for this custom tax. Taxability
        /// rows express default and override behaviour for items the tax applies to.
        /// </summary>
        public List<CustomTaxTaxabilityOutputModel> taxability { get; set; }

        /// <summary>
        /// Define the tax rates associated with this custom tax. Each rate row specifies the
        /// numeric rate and the criteria under which that rate applies.
        /// </summary>
        public List<CustomTaxRateOutputModel> rates { get; set; }

        /// <summary>
        /// Optional list of when items are exempt from this custom tax. Each exemption row defines
        /// criteria that mark matching transaction lines as exempt (or explicitly not exempt).
        /// </summary>
        public List<CustomTaxExemptionsOutputModel> exemptions { get; set; }

        /// <summary>
        /// The date when the custom tax was created. Populated automatically when the record is
        /// persisted.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The user who created the custom tax. Populated automatically from the calling user's
        /// identity at creation time.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The date when the custom tax was last modified. Populated automatically whenever the
        /// record is updated.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user who last modified the custom tax. Populated automatically from the calling
        /// user's identity when the record is updated.
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
