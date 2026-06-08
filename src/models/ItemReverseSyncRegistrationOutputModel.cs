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
    /// Output model representing a Connector Data Sync (reverse sync) webhook registration.
    /// </summary>
    public class ItemReverseSyncRegistrationOutputModel
    {
        /// <summary>
        /// The unique identifier for this registration.
        /// </summary>
        public Int64? registrationId { get; set; }

        /// <summary>
        /// The connector name. This value is also used as the OAuth scope for the registration.
        /// </summary>
        public String connectorName { get; set; }

        /// <summary>
        /// The Avalara company identifier that owns this registration.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The webhook callback URL that the connector exposes to receive notifications.
        /// </summary>
        public String url { get; set; }

        /// <summary>
        /// The registration delivery channel (for example, Webhook).
        /// </summary>
        public ItemReverseSyncTypeName? typeName { get; set; }

        /// <summary>
        /// Indicates whether this registration is currently active.
        /// </summary>
        public Boolean? isActive { get; set; }

        /// <summary>
        /// The list of events this registration subscribes to.
        /// </summary>
        public ItemReverseSyncEventType? events { get; set; }

        /// <summary>
        /// The date and time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user ID who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }

        /// <summary>
        /// The date and time when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The user ID who created this record.
        /// </summary>
        public Int32? createdUserId { get; set; }


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
