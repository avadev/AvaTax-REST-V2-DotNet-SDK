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
    /// Memory alert information
    /// </summary>
    public class MemoryAlert
    {
        /// <summary>
        /// Unique identifier for the alert
        /// </summary>
        public String id { get; set; }

        /// <summary>
        /// Title of the alert
        /// </summary>
        public String title { get; set; }

        /// <summary>
        /// Detailed description of the alert
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// Severity level of the alert
        /// </summary>
        public MemoryAlertSeverity? severity { get; set; }

        /// <summary>
        /// Timestamp when the alert was generated
        /// </summary>
        public DateTime? timestamp { get; set; }

        /// <summary>
        /// Additional metrics associated with the alert
        /// </summary>
        public object metrics { get; set; }


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
