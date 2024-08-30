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
    /// The reason the certificate is invalid.
    /// </summary>
    public class CertificateInvalidReasonModel
    {
        /// <summary>
        /// The unique ID of this invalid reason.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The name of this certificate invalid reason.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// A description of the certificate invalid reason.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// This value is `true` if the invalid reason is a system code.
        /// </summary>
        public Boolean? systemCode { get; set; }


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
