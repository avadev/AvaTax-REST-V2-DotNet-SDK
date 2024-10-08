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
    /// Update history for Avalara.AvaTax.AccountServices.Models.v2.CustomerModel and Avalara.AvaTax.AccountServices.Models.v2.CertificateModel. This is exposed in the URL's `$includes`.
    /// </summary>
    public class HistoryModel
    {
        /// <summary>
        /// The unique ID number of this history.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The account name this history belongs to.
        /// </summary>
        public String account { get; set; }

        /// <summary>
        /// The name of the field to update.
        /// </summary>
        public String field { get; set; }

        /// <summary>
        /// The old value of the field.
        /// </summary>
        public String oldValue { get; set; }

        /// <summary>
        /// The new value of the field.
        /// </summary>
        public String newValue { get; set; }

        /// <summary>
        /// The date/time when this history was created.
        /// </summary>
        public DateTime? created { get; set; }


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
