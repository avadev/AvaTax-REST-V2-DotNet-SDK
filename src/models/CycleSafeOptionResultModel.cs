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
    /// CycleSafe Option Result
    /// </summary>
    public class CycleSafeOptionResultModel
    {
        /// <summary>
        /// Tax Form Code
        /// </summary>
        public String taxFormCode { get; set; }

        /// <summary>
        /// Boolean if the Filing Calendar must be cloned
        /// </summary>
        public Boolean? mustCloneFilingCalendar { get; set; }

        /// <summary>
        /// Cloned Calendar Effective Date
        /// </summary>
        public DateTime? clonedCalendarEffDate { get; set; }

        /// <summary>
        /// Expired Calendar End Date
        /// </summary>
        public DateTime? expiredCalendarEndDate { get; set; }

        /// <summary>
        /// Frequencies Available
        /// </summary>
        public List<FrequencyAvailableModel> frequenciesAvailable { get; set; }


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
