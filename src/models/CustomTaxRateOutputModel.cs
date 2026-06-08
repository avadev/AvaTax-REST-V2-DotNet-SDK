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
    /// Describes a single rate override row for a custom tax.
    /// <br>
    /// This is the output variant returned by Custom Tax read endpoints. Each rate row specifies
    /// a rate and a set of optional criteria (jurisdiction, tax code, tariff code, entity use
    /// code, etc.) which determine when the rate applies.
    /// </summary>
    public class CustomTaxRateOutputModel
    {
        /// <summary>
        /// The rate which is assigned based on the criteria in this model. The value is interpreted
        /// according to the custom tax's `unitOfBasis` (for example, a value of `0.05`
        /// with `PerCurrencyUnit` means 5%).
        /// </summary>
        public Decimal? rate { get; set; }

        /// <summary>
        /// Optionally specify the maximum taxable amount. Any portion of the base above this cap
        /// is not taxed at this rate.
        /// </summary>
        public Decimal? cap { get; set; }

        /// <summary>
        /// Optionally specify the per-unit threshold that must be met to apply this rate. If the
        /// line amount is below the threshold this rate does not apply.
        /// </summary>
        public Decimal? threshold { get; set; }

        /// <summary>
        /// Optionally set the type of jurisdiction this rate applies to, e.g. State or City. When
        /// specified together with `jurisCode`, this rate only applies to transactions sourced
        /// to matching jurisdictions.
        /// </summary>
        public JurisdictionType? jurisdictionTypeId { get; set; }

        /// <summary>
        /// Optionally set the specific jurisdiction this rate applies to. This should be one of
        /// the jurisdictions defined on the parent custom tax.
        /// </summary>
        public String jurisCode { get; set; }

        /// <summary>
        /// The rate type for which this rate applies.
        /// </summary>
        public String rateTypeCode { get; set; }

        /// <summary>
        /// Optionally set a specific tax code this rate applies to. Tax codes identify product or
        /// service categories for taxation.
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// Optionally set a specific tariff code this rate applies to. Tariff codes are used for
        /// cross-border and customs taxation.
        /// </summary>
        public String tariffCode { get; set; }

        /// <summary>
        /// Optionally set a specific entity use code this rate applies to. Entity use codes
        /// describe customer usage such as resale, manufacturing, or government use.
        /// </summary>
        public String entityUseCode { get; set; }

        /// <summary>
        /// Optionally set a different effective date for this rate. This date cannot be earlier
        /// than the base effective date set for the entire custom tax.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// Optionally set a different expiration date for this rate. This date cannot be later
        /// than the base expiration date set for the entire custom tax.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Optionally set the currency code to use for this rate. When omitted, the rate uses the
        /// transaction's currency.
        /// </summary>
        public String currencyCode { get; set; }

        /// <summary>
        /// Optionally override the unit of basis for this specific rate. If not specified, the
        /// rate uses the custom tax default unit of basis.
        /// </summary>
        public String unitOfBasis { get; set; }

        /// <summary>
        /// Whether this rate applies to all child jurisdictions or only the specified one. When
        /// true, the rate is applied to every jurisdiction beneath the one identified by
        /// `jurisCode`; when false or null, only the exact jurisdiction is matched.
        /// </summary>
        public Boolean? isAllJuris { get; set; }

        /// <summary>
        /// Optional advanced settings for this rate. The allowed values depend on the tax type
        /// and are documented separately.
        /// </summary>
        public List<String> options { get; set; }


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
