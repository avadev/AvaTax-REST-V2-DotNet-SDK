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
    /// Represents one configuration setting for this account
    /// </summary>
    public class AccountConfigurationModel
    {
        /// <summary>
        /// The unique ID number of the account to which this setting applies
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// The category of the configuration setting. Avalara-defined categories include `AddressServiceConfig` and `TaxServiceConfig`. Customer-defined categories begin with `X-`.
        /// </summary>
        public String category { get; set; }

        /// <summary>
        /// The name of the configuration setting
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The current value of the configuration setting
        /// </summary>
        public String value { get; set; }

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
