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
    /// Certificate with exemption reason and exposure zone. Exposed in url $includes
    /// </summary>
    public class ActiveCertificateModel
    {
        /// <summary>
        /// Certificate ID.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// Created date time
        /// </summary>
        public DateTime? created { get; set; }

        /// <summary>
        /// Modified date time
        /// </summary>
        public DateTime? modified { get; set; }

        /// <summary>
        /// Certificate's expected tax number
        /// </summary>
        public String expectedTaxNumber { get; set; }

        /// <summary>
        /// Certificate's actual tax number
        /// </summary>
        public String actualTaxNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExposureZoneModel exposureZone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExemptionReasonModel expectedTaxCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExemptionReasonModel actualTaxCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CertificateModel certificate { get; set; }


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
