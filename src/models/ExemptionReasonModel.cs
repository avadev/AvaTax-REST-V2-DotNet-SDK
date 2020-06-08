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
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// An exemption reason defines why a certificate allows a customer to be exempt
    /// for purposes of tax calculation. For a full list of defined exemption reasons,
    /// please call the `ListCertificateExemptionReasons` API.
    /// </summary>
    public class ExemptionReasonModel
    {
        /// <summary>
        /// A unique ID number representing this exemption reason.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// A friendly name describing this exemption reason.
        /// </summary>
        public String name { get; set; }


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
