using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Options for expiring a filing calendar.
    /// </summary>
    public class CycleExpireOptionModel
    {
        /// <summary>
        /// The period start date for the customer's first transaction in the jurisdiction being expired.
        /// </summary>
        public DateTime? transactionalPeriodStart { get; set; }

        /// <summary>
        /// The period end date for the customer's last transaction in the jurisdiction being expired.
        /// </summary>
        public DateTime? transactionalPeriodEnd { get; set; }

        /// <summary>
        /// The jurisdiction-assigned due date for the form.
        /// </summary>
        public DateTime? filingDueDate { get; set; }

        /// <summary>
        /// A descriptive name of the cycle and due date of the form.
        /// </summary>
        public String cycleName { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
