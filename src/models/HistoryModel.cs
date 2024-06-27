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
    /// Update history for Avalara.AvaTax.AccountServices.Models.v2.CustomerModel and Avalara.AvaTax.AccountServices.Models.v2.CertificateModel. Exposed in url $includes
    /// </summary>
    public class HistoryModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// Account name whose history this is
        /// </summary>
        public String account { get; set; }

        /// <summary>
        /// Field name which is updated
        /// </summary>
        public String field { get; set; }

        /// <summary>
        /// Old value of the field
        /// </summary>
        public String oldValue { get; set; }

        /// <summary>
        /// New value of the field
        /// </summary>
        public String newValue { get; set; }

        /// <summary>
        /// Date of creation of this history object
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
