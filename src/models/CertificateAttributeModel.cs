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
    /// A certificate attribute can be thought of as a feature or flag that is applied to a certificate.
    /// A single certificate can be linked to zero, one, or many certificate attributes. The full list of
    /// attributes can be obtained by calling the `ListCertificateAttributes` API.
    /// </summary>
    public class CertificateAttributeModel
    {
        /// <summary>
        /// A unique ID number representing this certificate attribute.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// A friendly readable name for this certificate attribute.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// A full help text description of the certificate attribute.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// This value is true if this is a system-defined certificate attribute. System-defined attributes
        /// cannot be modified or deleted on the CertCapture website.
        /// </summary>
        public Boolean? isSystemCode { get; set; }


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
