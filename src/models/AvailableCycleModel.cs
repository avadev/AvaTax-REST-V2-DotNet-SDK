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
    /// Available Cycle object
    /// </summary>
    public class AvailableCycleModel
    {
        /// <summary>
        /// Transactional Period Start
        /// </summary>
        public DateTime? transactionalPeriodStart { get; set; }

        /// <summary>
        /// Transactional Period End
        /// </summary>
        public DateTime? transactionalPeriodEnd { get; set; }

        /// <summary>
        /// Filing Due Date
        /// </summary>
        public DateTime? filingDueDate { get; set; }

        /// <summary>
        /// Cycle Name
        /// </summary>
        public String cycleName { get; set; }


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
