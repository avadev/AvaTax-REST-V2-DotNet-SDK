using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2019 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Genevieve Conty
 * @author Greg Hester
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// A Customer's linked attribute denoting what features applied to the customer. A customer can
    /// be linked to multiple customer attributes and vice versa.
    /// </summary>
    public class CustomerAttributeModel
    {
        /// <summary>
        /// A unique ID number representing this attribute.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// A friendly readable name for this attribute.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// A full help text description of the attribute.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// This value is true if this is a system-defined attribute. System-defined attributes
        /// cannot be modified or deleted on the CertCapture website.
        /// </summary>
        public Boolean? isSystemCode { get; set; }

        /// <summary>
        /// A flag denotes that future exemption certificate request won't be mailed to the customer
        /// </summary>
        public Boolean? isNonDeliver { get; set; }

        /// <summary>
        /// A flag denotes that this attribute can't be removed/added to a customer record
        /// </summary>
        public Boolean? isChangeable { get; set; }


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
