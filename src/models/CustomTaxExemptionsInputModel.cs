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
    /// Describes a single exemption override row for a custom tax.
    /// <br>
    /// This is the input variant used when creating or updating a custom tax. Each exemption row
    /// defines whether a matching transaction line is exempt from the custom tax, optionally
    /// scoped by jurisdiction, rate type, tax code, tariff code, or entity use code.
    /// </summary>
    public class CustomTaxExemptionsInputModel
    {
        /// <summary>
        /// Whether this tax treatment sets an item as exempt or not exempt. When true, matching
        /// lines are exempt from this custom tax; when false, an existing exemption is explicitly
        /// overridden so the custom tax still applies.
        /// </summary>
        public Boolean exempt { get; set; }

        /// <summary>
        /// Optionally set the type of jurisdiction this exemption applies to, e.g. State or City.
        /// When combined with `jurisCode`, the exemption is scoped to the matching
        /// jurisdiction only.
        /// </summary>
        public JurisdictionType? jurisdictionTypeId { get; set; }

        /// <summary>
        /// Optionally set the specific jurisdiction this exemption applies to. This should be one
        /// of the jurisdictions defined on the parent custom tax.
        /// </summary>
        public String jurisCode { get; set; }

        /// <summary>
        /// Optionally set a specific rate type this exemption applies to.
        /// </summary>
        public String rateTypeCode { get; set; }

        /// <summary>
        /// Optionally set a specific tax code this exemption applies to. Tax codes identify
        /// product or service categories for taxation.
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// Optionally set a specific tariff code this exemption applies to. Tariff codes are used
        /// for cross-border and customs taxation.
        /// </summary>
        public String tariffCode { get; set; }

        /// <summary>
        /// Optionally set a specific entity use code this exemption applies to. Entity use codes
        /// describe customer usage such as resale, manufacturing, or government use.
        /// </summary>
        public String entityUseCode { get; set; }

        /// <summary>
        /// Optionally set a different effective date for this exemption. This date cannot be
        /// earlier than the base effective date set for the entire custom tax.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// Optionally set a different expiration date for this exemption. This date cannot be
        /// later than the base expiration date set for the entire custom tax.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Whether this exemption applies to all child jurisdictions or only the specified one.
        /// When true, the exemption is applied to every jurisdiction beneath the one identified by
        /// `jurisCode`; when false or null, only the exact jurisdiction is matched.
        /// </summary>
        public Boolean? isAllJuris { get; set; }


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
