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
    /// Options for expiring a filing calendar.
    /// </summary>
    public class CycleSafeEditRequestModel
    {
        /// <summary>
        /// Company Identifier
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// Tax Form Code
        /// </summary>
        public String taxFormCode { get; set; }

        /// <summary>
        /// Filing Calendar Identifier
        /// </summary>
        public Int64? filingCalendarId { get; set; }

        /// <summary>
        /// Filing calendar edits
        /// </summary>
        public List<CycleSafeFilingCalendarEditModel> edits { get; set; }


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
