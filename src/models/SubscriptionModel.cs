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
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a service that this account has subscribed to.
    /// </summary>
    public class SubscriptionModel
    {
        /// <summary>
        /// The unique ID number of this subscription.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique ID number of the account this subscription belongs to.
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// The unique ID number of the service that the account is subscribed to. If this is provided, subscription description is ignored.
        /// </summary>
        public Int32? subscriptionTypeId { get; set; }

        /// <summary>
        /// A friendly description of the service that the account is subscribed to. You can either provide the subscription type Id or this but not both. If 
        /// subscription type Id is provided, then this information is ignored and this field will be updated with the information from subscription type id.
        /// </summary>
        public String subscriptionDescription { get; set; }

        /// <summary>
        /// The date when the subscription began.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// If the subscription has ended or will end, this date indicates when the subscription ends.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The User ID of the user who created this record.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }


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
