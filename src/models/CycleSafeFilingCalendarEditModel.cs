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
    /// Filing Calendar Edit
    /// </summary>
    public class CycleSafeFilingCalendarEditModel
    {
        /// <summary>
        /// Field To Edit
        /// </summary>
        public String fieldName { get; set; }

        /// <summary>
        /// Destination is used to identify filing questions' type Other or Settings.
        /// </summary>
        public String destination { get; set; }

        /// <summary>
        /// Question
        /// </summary>
        public Int64? questionId { get; set; }

        /// <summary>
        /// The filing question code.
        /// </summary>
        public String questionCode { get; set; }

        /// <summary>
        /// Old Value
        /// </summary>
        public object oldValue { get; set; }

        /// <summary>
        /// New Value
        /// </summary>
        public object newValue { get; set; }


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
