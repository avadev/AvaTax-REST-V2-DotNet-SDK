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
    /// Represents one TPS tax-type node returned by the `ListCertificateTaxTypes` API.
    ///  
    /// The pair (`taxType`, `taxTypeId`) is what the caller uses to
    /// populate `taxTypeMappings` on a certificate jurisdiction.
    /// </summary>
    public class CertificateTaxTypeModel
    {
        /// <summary>
        /// TPS label for the tax type (e.g. `"Automotive"`).
        /// </summary>
        public String taxType { get; set; }

        /// <summary>
        /// TPS surrogate identifier for the tax type.
        /// </summary>
        public Int32? taxTypeId { get; set; }

        /// <summary>
        /// ISO-2 country code (e.g. `"US"`).
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Sub-tax-type details under this tax type.
        /// </summary>
        public List<CertificateTaxSubTypeModel> taxSubTypeDetails { get; set; }


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
