using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Indicates the customer's exemption status in a specific country and region.
    /// </summary>
    public class ExemptionStatusModel
    {
        /// <summary>
        /// The exemption status of this customer in this country/region.
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// Certificate if the customer is exempted
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
