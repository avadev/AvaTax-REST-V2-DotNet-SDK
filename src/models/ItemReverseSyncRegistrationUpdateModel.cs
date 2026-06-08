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
    /// Update model for an existing Connector Data Sync (reverse sync) webhook registration.
    ///  
    /// Only the fields included in the request body will be updated.
    /// </summary>
    public class ItemReverseSyncRegistrationUpdateModel
    {
        /// <summary>
        /// The webhook callback URL that the connector exposes to receive notifications.
        /// </summary>
        public String url { get; set; }

        /// <summary>
        /// The registration delivery channel (for example, Webhook). Omit to leave the persisted value unchanged.
        /// </summary>
        public ItemReverseSyncTypeName? typeName { get; set; }

        /// <summary>
        /// The list of events this registration subscribes to.
        /// </summary>
        public ItemReverseSyncEventType? events { get; set; }


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
