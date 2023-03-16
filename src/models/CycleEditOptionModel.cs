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
    /// Model with options for actual filing calendar output based on user edits to filing calendar.
    /// </summary>
    public class CycleEditOptionModel
    {
        /// <summary>
        /// Whether or not changes can be made to the filing calendar.
        /// </summary>
        public Boolean? success { get; set; }

        /// <summary>
        /// The message to present to the user when calendar is successfully or unsuccessfully changed.
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// Whether or not the user should be warned of a change, because some changes are risky and may be being done not in accordance with jurisdiction rules.
        /// For example, user would be warned if user changes filing frequency to new frequency with a start date during an accrual month of the existing frequency.
        /// </summary>
        public Boolean? customerMustApprove { get; set; }

        /// <summary>
        /// True if the filing calendar must be cloned to allow this change; false if the existing filing calendar can be changed itself.
        /// </summary>
        public Boolean? mustCloneFilingCalendar { get; set; }

        /// <summary>
        /// The effective date of the filing calendar (only applies if cloning).
        /// </summary>
        public DateTime? clonedCalendarEffDate { get; set; }

        /// <summary>
        /// The expired end date of the old filing calendar (only applies if cloning).
        /// </summary>
        public DateTime? expiredCalendarEndDate { get; set; }


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
