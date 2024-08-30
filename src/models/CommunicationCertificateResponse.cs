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
    /// Encloses communication certificate details
    /// </summary>
    public class CommunicationCertificateResponse
    {
        /// <summary>
        /// Certificate Id
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// Certificate effective date
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// Certificate expiration date
        /// </summary>
        public DateTime? expirationDate { get; set; }

        /// <summary>
        /// Certificate exemption reason
        /// </summary>
        public String exemptionReason { get; set; }

        /// <summary>
        /// Certificate exemption region
        /// </summary>
        public String exemptionRegion { get; set; }

        /// <summary>
        /// Certificate tax number
        /// </summary>
        public String taxNumber { get; set; }

        /// <summary>
        /// Certificate status
        /// </summary>
        public String certificateStatus { get; set; }

        /// <summary>
        /// Customers which have this certificate
        /// </summary>
        public List<CommunicationCustomerResponse> customers { get; set; }

        /// <summary>
        /// Tax details of this certificate
        /// </summary>
        public List<CommunicationTaxTypeResponse> exemptions { get; set; }


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
