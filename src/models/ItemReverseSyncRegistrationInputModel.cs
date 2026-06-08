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
    /// Input model used to create a Connector Data Sync (reverse sync) webhook registration.
    ///  
    /// A registration tells Avalara which connector should be notified when an item-related
    /// event occurs (currently `HSCodeAssigned`), the callback URL to invoke, and the
    /// events the connector wishes to subscribe to.
    /// </summary>
    public class ItemReverseSyncRegistrationInputModel
    {
        /// <summary>
        /// The connector name. This value is also used as the OAuth scope for the registration.
        /// </summary>
        public String connectorName { get; set; }

        /// <summary>
        /// The webhook callback URL that the connector exposes to receive notifications.
        /// </summary>
        public String url { get; set; }

        /// <summary>
        /// The registration delivery channel (for example, Webhook).
        /// </summary>
        public ItemReverseSyncTypeName typeName { get; set; }

        /// <summary>
        /// The list of events this registration subscribes to.
        /// </summary>
        public ItemReverseSyncEventType events { get; set; }


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
