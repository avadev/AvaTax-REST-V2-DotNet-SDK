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
    /// Describes a single taxability override row for a custom tax.
    /// <br>
    /// This is the output variant returned by Custom Tax read endpoints. Each taxability row
    /// defines whether an item is taxable or not, optionally scoped to a specific jurisdiction,
    /// tax code, tariff code, or entity use code.
    /// </summary>
    public class CustomTaxTaxabilityOutputModel
    {
        /// <summary>
        /// Whether this tax treatment sets an item as taxable or not taxable. When true, items
        /// matching the other criteria are taxable under this custom tax; when false, they are
        /// explicitly marked as not taxable.
        /// </summary>
        public Boolean? taxable { get; set; }

        /// <summary>
        /// Optionally specify the maximum taxable amount. Any portion of the base above this cap
        /// is not taxed under this taxability treatment.
        /// </summary>
        public Decimal? cap { get; set; }

        /// <summary>
        /// Optionally specify the per-unit threshold that must be met to apply this tax treatment.
        /// If the line amount is below the threshold, this treatment does not apply.
        /// </summary>
        public Decimal? threshold { get; set; }

        /// <summary>
        /// Optionally set the type of jurisdiction this tax treatment applies to, e.g. State or
        /// City. When combined with `jurisCode`, the taxability is scoped to the matching
        /// jurisdiction only.
        /// </summary>
        public JurisdictionType? jurisdictionTypeId { get; set; }

        /// <summary>
        /// Optionally set the specific jurisdiction this tax treatment applies to. This should be
        /// one of the jurisdictions defined on the parent custom tax.
        /// </summary>
        public String jurisCode { get; set; }

        /// <summary>
        /// The rate type to assign as part of this tax treatment.
        /// </summary>
        public String rateTypeCode { get; set; }

        /// <summary>
        /// Optionally set a specific tax code this tax treatment applies to. Tax codes identify
        /// product or service categories for taxation.
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// Optionally set a specific tariff code this tax treatment applies to. Tariff codes are
        /// used for cross-border and customs taxation.
        /// </summary>
        public String tariffCode { get; set; }

        /// <summary>
        /// Optionally set a specific entity use code this tax treatment applies to. Entity use
        /// codes describe customer usage such as resale, manufacturing, or government use.
        /// </summary>
        public String entityUseCode { get; set; }

        /// <summary>
        /// Optionally set a different effective date for this tax treatment. This date cannot be
        /// earlier than the base effective date set for the entire custom tax.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// Optionally set a different expiration date for this tax treatment. This date cannot be
        /// later than the base expiration date set for the entire custom tax.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Optionally set the currency code to use for this tax treatment.
        /// </summary>
        public String currencyCode { get; set; }

        /// <summary>
        /// Whether this tax treatment applies to all child jurisdictions or only the specified one.
        /// When true, the treatment is applied to every jurisdiction beneath the one identified by
        /// `jurisCode`; when false or null, only the exact jurisdiction is matched.
        /// </summary>
        public Boolean? isAllJuris { get; set; }

        /// <summary>
        /// Optionally override the sourcing to Origin, Destination, or blank (default). Sourcing
        /// controls which location of the transaction (origin or destination) is used to evaluate
        /// this tax treatment.
        /// </summary>
        public String sourcing { get; set; }

        /// <summary>
        /// Optional advanced settings for this tax treatment. The allowed values depend on the
        /// tax type and are documented separately.
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
