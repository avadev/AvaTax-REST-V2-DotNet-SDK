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
    /// A single entry in a company's exemption matrix.
    ///  
    /// The exemption matrix holds, for each combination of exposure zone and exempt
    /// reason that a company has configured, the rule used to work out when a
    /// certificate for that combination expires, and the qualifying statement shown
    /// to the customer.
    /// </summary>
    public class ExemptionMatrixModel
    {
        /// <summary>
        /// A unique ID number representing this exemption matrix entry.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The ID number of the exposure zone this entry applies to.
        /// </summary>
        public Int32? exposureZoneId { get; set; }

        /// <summary>
        /// The name of the exposure zone this entry applies to, for example "Alabama".
        /// </summary>
        public String exposureZoneName { get; set; }

        /// <summary>
        /// The Avalara tag of the exposure zone, for example "AV_US_AL".
        /// </summary>
        public String exposureZoneTag { get; set; }

        /// <summary>
        /// The ID number of the exempt reason this entry applies to.
        /// </summary>
        public Int32? exemptReasonId { get; set; }

        /// <summary>
        /// The name of the exempt reason this entry applies to, for example "Resale".
        /// </summary>
        public String exemptReasonName { get; set; }

        /// <summary>
        /// The Avalara tag of the exempt reason, for example "AV_OO_RESL".
        /// </summary>
        public String exemptReasonTag { get; set; }

        /// <summary>
        /// The encoded rule used to calculate a certificate's expiration date from its
        /// signed date. One of five markers, optionally combined with an interval:
        ///  
        /// * `IMM` - expires on the signed date.
        /// * `NVR` - never expires; the expiration date is `9999-12-31`.
        /// * `OVR` - no rule configured; an expiration date must be supplied when the
        ///  certificate is recorded, otherwise recording it fails.
        /// * `EOM` - end of the signing month, rolling to the next month when that is
        ///  within 7 days of the signed date.
        /// * `EOY` - end of the signing year, rolling to the next year when that is
        ///  within 31 days of the signed date.
        ///  
        /// An interval may appear on its own or combined with `EOM` / `EOY`:
        /// `36 months` is added to the signed date; `EOM+2 years` applies the marker and
        /// then adds the interval; `18 months+EOY` adds the interval and then rounds up.
        /// An interval is a whole number followed by a unit, most commonly `days`,
        /// `months` or `years` - for example `30 days`, `36 months`, `2 years`.
        /// </summary>
        public String timeLength { get; set; }

        /// <summary>
        /// The statement the customer qualifies themselves against when they request a
        /// certificate for this exposure zone and exempt reason, for display to the
        /// customer. Null when none is configured.
        /// </summary>
        public String qualifyingStatement { get; set; }


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
