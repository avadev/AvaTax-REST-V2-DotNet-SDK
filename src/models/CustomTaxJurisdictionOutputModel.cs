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
    /// Describes a single jurisdiction in which a custom tax is applicable.
    /// <br>
    /// This is the output variant returned by Custom Tax read endpoints. Each jurisdiction
    /// identifies a region of applicability for the parent custom tax.
    /// </summary>
    public class CustomTaxJurisdictionOutputModel
    {
        /// <summary>
        /// The type of jurisdiction this is, e.g. State or City.
        /// </summary>
        public JurisdictionType? jurisdictionTypeId { get; set; }

        /// <summary>
        /// The code identifying this jurisdiction, in combination with the `jurisdictionTypeId`.
        /// </summary>
        public String jurisCode { get; set; }

        /// <summary>
        /// Optionally set a different effective date for this jurisdiction. This date cannot be
        /// earlier than the base effective date set for the entire custom tax. When omitted, the
        /// jurisdiction inherits the custom tax's effective date.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// Optionally set a different expiration date for this jurisdiction. This date cannot be
        /// later than the base expiration date set for the entire custom tax. When omitted, the
        /// jurisdiction inherits the custom tax's end date.
        /// </summary>
        public DateTime? endDate { get; set; }


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
