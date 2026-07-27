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
    /// Represents one multi-tax mapping row attached to a certificate jurisdiction.
    /// Each row references a TPS tax-type / sub-tax-type combination that the
    /// certificate is exempt for.
    /// </summary>
    public class CertificateJurisdictionTaxMappingModel
    {
        /// <summary>
        /// Unique ID number of this mapping row.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// TPS surrogate identifier for the tax type.
        /// </summary>
        public Int32? taxTypeId { get; set; }

        /// <summary>
        /// TPS label for the tax type (e.g. `"Automotive"`).
        /// </summary>
        public String taxType { get; set; }

        /// <summary>
        /// TPS surrogate identifier for the sub-tax type.
        /// </summary>
        public Int32? subTaxTypeId { get; set; }

        /// <summary>
        /// TPS label for the sub-tax type.
        /// </summary>
        public String subTaxType { get; set; }

        /// <summary>
        /// TPS `taxTypeMappingId`. Used as the diff key on PUT.
        /// </summary>
        public Int32? sourceMappingId { get; set; }


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
