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
    /// Used for Enabling an Autit Trail.
    /// </summary>
    public class AuditServiceConfigModel
    {
        /// <summary>
        /// The unique ID number assigned to this account.
        /// </summary>
        public Int32 accountId { get; set; }

        /// <summary>
        /// Date and Time to start Auditing in UTC. If left blank, default to current time
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// Duration of Audit in hours
        /// </summary>
        public Int32 duration { get; set; }


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
