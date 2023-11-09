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
    /// ViewModel to get Domain control verification
    /// </summary>
    public class DcvViewModel
    {
        /// <summary>
        /// Unique id of the Domain control verification
        /// </summary>
        public String id { get; set; }

        /// <summary>
        /// Domain name for which Domain control verification record is created
        /// </summary>
        public String domainName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Context context { get; set; }

        /// <summary>
        /// Unique token for Domain control verification
        /// </summary>
        public String token { get; set; }

        /// <summary>
        /// Status of the domain Verified/Pending/Cancelled
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// Email id of the user who create Domain control verification
        /// </summary>
        public String emailId { get; set; }

        /// <summary>
        /// Domain control verification creation date
        /// </summary>
        public String createdOn { get; set; }

        /// <summary>
        /// Domain control verification created by
        /// </summary>
        public String createdBy { get; set; }

        /// <summary>
        /// Domain control verification update date
        /// </summary>
        public String updatedOn { get; set; }

        /// <summary>
        /// Domain control verification update by
        /// </summary>
        public String updatedBy { get; set; }


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
