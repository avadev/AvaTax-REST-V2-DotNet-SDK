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
    /// Represents a tax type group
    /// </summary>
    public class TaxTypeGroupModel
    {
        /// <summary>
        /// The unique ID number of this tax type group.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique human readable Id of this tax type group.
        /// </summary>
        public String taxTypeGroup { get; set; }

        /// <summary>
        /// The description of this tax type group.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// If this tax type group requires a subscription, this contains the ID number of the subscription type required to use it.
        /// </summary>
        public Int32? subscriptionTypeId { get; set; }

        /// <summary>
        /// If this tax type group requires a subscription, this contains the friendly name of the subscription type required to use it.
        /// </summary>
        public String subscriptionDescription { get; set; }

        /// <summary>
        /// The name of the tab in the AvaTax website corresponding to this tax type group.
        /// </summary>
        public String tabName { get; set; }

        /// <summary>
        /// True if this tax type group is displayed in the user interface of the AvaTax website.
        /// </summary>
        public Boolean? showColumn { get; set; }

        /// <summary>
        /// The order this record is being returned in the response
        /// </summary>
        public Int32? displaySequence { get; set; }


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
