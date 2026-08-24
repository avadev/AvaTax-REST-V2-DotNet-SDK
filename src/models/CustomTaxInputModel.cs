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
    /// A Custom Tax defines company-specific tax content - the jurisdictions where a tax applies together with its
    /// rates, taxability, and exemptions. It provides a focused, content-oriented way to author and manage tax
    /// overrides for a company.
    /// <br>
    /// Use of the Custom Tax endpoints requires the `AvaCustomContent` subscription.
    /// </summary>
    public class CustomTaxInputModel
    {
        /// <summary>
        /// The name of the custom tax.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Optional description of the custom tax. Intended for use by compliance and support
        /// teams to document intent or source.
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
        /// The tax type of the custom tax.
        /// </summary>
        public String taxTypeCode { get; set; }

        /// <summary>
        /// The tax subtype for this custom tax, which describes a more granular
        /// tax category within the main type.
        /// </summary>
        public String taxSubType { get; set; }

        /// <summary>
        /// The rate types associated with this custom tax.
        /// </summary>
        public List<String> rateTypeCodes { get; set; }

        /// <summary>
        /// The default unit of basis used to calculate the value of this custom tax. Determines
        /// how the rate on each rate row is interpreted - for example, `PerCurrencyUnit` for
        /// a percentage or `PerUnit` for a flat amount per unit.
        /// </summary>
        public String unitOfBasis { get; set; }

        /// <summary>
        /// The first date when the tax is valid. Transactions with a document date earlier than
        /// this date will not be affected by this custom tax.
        /// </summary>
        public DateTime effectiveDate { get; set; }

        /// <summary>
        /// The last date when the tax is valid. Transactions with a document date later than this
        /// date will not be affected by this custom tax.
        /// </summary>
        public DateTime endDate { get; set; }

        /// <summary>
        /// Whether the custom tax is enabled. When false, the tax will not be calculated.
        /// Existing saved documents are not affected.
        /// </summary>
        public Boolean enabled { get; set; }

        /// <summary>
        /// Whether to continue execution if there is an error evaluating the rule criteria. When
        /// true, an error in this custom tax does not stop evaluation of other custom taxes or
        /// custom rules on the transaction. When false, a failure will cause the entire transaction
        /// to return an error.
        /// </summary>
        public Boolean continueOnError { get; set; }

        /// <summary>
        /// A list of jurisdictions in which this custom tax applies. At least one jurisdiction is
        /// required; each jurisdiction identifies a place of applicability for the tax.
        /// </summary>
        public List<CustomTaxJurisdictionInputModel> jurisdictions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CustomTaxAdditionalCriteriaInputModel conditions { get; set; }

        /// <summary>
        /// Define the taxability treatment and rate type assignment for this custom tax. Taxability
        /// rows express default and override behaviour for items the tax applies to.
        /// </summary>
        public List<CustomTaxTaxabilityInputModel> taxability { get; set; }

        /// <summary>
        /// Define the tax rates associated with this custom tax. Each rate row specifies the
        /// numeric rate and the criteria under which that rate applies.
        /// </summary>
        public List<CustomTaxRateInputModel> rates { get; set; }

        /// <summary>
        /// Optional list of when items are exempt from this custom tax. Each exemption row defines
        /// criteria that mark matching transaction lines as exempt (or explicitly not exempt).
        /// </summary>
        public List<CustomTaxExemptionInputModel> exemptions { get; set; }


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
