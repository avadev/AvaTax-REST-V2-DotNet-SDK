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
    /// Represents one TPS-Nexus jurisdiction node nested under a Avalara.AvaTax.AccountServices.Models.v2.CertificateTaxSubTypeModel.
    /// </summary>
    public class CertificateTaxTypeJurisdictionModel
    {
        /// <summary>
        /// ISO-2 country code (e.g. `"US"`).
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Region code within the country (e.g. two-letter state abbreviation).
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// Jurisdiction type (e.g. `"State"`, `"County"`, `"City"`).
        /// </summary>
        public String type { get; set; }

        /// <summary>
        /// FIPS-style jurisdiction code.
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// Human-readable name of the jurisdiction.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Short display name.
        /// </summary>
        public String shortName { get; set; }


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
