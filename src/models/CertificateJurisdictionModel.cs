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
    /// Represents a jurisdiction associated with a certificate.
    /// A certificate can be linked to one or more jurisdictions indicating the tax
    /// authority regions where the certificate applies.
    /// </summary>
    public class CertificateJurisdictionModel
    {
        /// <summary>
        /// Unique ID number
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The type of the jurisdiction (e.g., State, County, City).
        /// </summary>
        public String type { get; set; }

        /// <summary>
        /// The name of the jurisdiction.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The FIPS code or identifier for the jurisdiction.
        /// </summary>
        public String code { get; set; }


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
