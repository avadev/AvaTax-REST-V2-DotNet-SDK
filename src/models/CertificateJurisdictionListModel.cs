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
    /// Represents a valid jurisdiction that can be linked to a certificate.
    ///  
    /// This model is returned by the `ListJurisdictions` API, which lists the jurisdictions
    /// that are valid for a given exposure zone and exemption tax code. The returned
    /// jurisdictions can then be used to add valid jurisdictions to a certificate.
    /// </summary>
    public class CertificateJurisdictionListModel
    {
        /// <summary>
        /// The code identifying the jurisdiction.
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// The name of the jurisdiction.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The type of the jurisdiction (e.g., Special, State, County, City).
        /// </summary>
        public String type { get; set; }

        /// <summary>
        /// The region (for example, the two-letter state or province abbreviation) where
        /// this jurisdiction applies.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// The ISO country code for this jurisdiction.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The customer usage type (entity use code) associated with this jurisdiction.
        /// </summary>
        public String customerUsageType { get; set; }


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
