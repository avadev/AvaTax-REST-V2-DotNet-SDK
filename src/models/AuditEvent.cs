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
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// 
    /// </summary>
    public class AuditEvent
    {
        /// <summary>
        /// 
        /// </summary>
        public Int64? auditEventId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int64? transactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? auditEventLevelId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? eventTimestamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String source { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String summary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String details { get; set; }


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
