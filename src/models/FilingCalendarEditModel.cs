using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// An edit to be made on a filing calendar.
    /// </summary>
    public class FilingCalendarEditModel
    {
        /// <summary>
        /// The name of the field to be modified.
        /// </summary>
        public String fieldName { get; set; }

        /// <summary>
        /// The unique ID of the filing calendar question. "Filing calendar question" is the wording displayed to users for a given field.
        /// </summary>
        public Int32 questionId { get; set; }

        /// <summary>
        /// The current value of the field.
        /// </summary>
        public Dictionary<string, string> oldValue { get; set; }

        /// <summary>
        /// The new/proposed value of the field.
        /// </summary>
        public Dictionary<string, string> newValue { get; set; }


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
