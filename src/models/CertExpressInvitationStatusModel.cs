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
    /// Represent what is the current status of certificate request
    /// </summary>
    public class CertExpressInvitationStatusModel
    {
        /// <summary>
        /// The status of the CertExpress invitation for this customer. If this status says
        /// InProgress then CertExpress website is currently building a landing page for the customer. 
        /// Please wait about 10 seconds and fetch this request again to see when it will be ready.
        /// </summary>
        public CertExpressInvitationStatus? status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CertExpressInvitationModel invitation { get; set; }


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
