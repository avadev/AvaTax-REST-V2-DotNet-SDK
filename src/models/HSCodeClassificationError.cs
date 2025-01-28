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
    /// The HS code classification error model.
    /// </summary>
    public class HSCodeClassificationError
    {
        /// <summary>
        /// The error code.
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// The error message
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// Target is source where failure is happened.
        /// </summary>
        public String target { get; set; }

        /// <summary>
        /// The fault code
        /// </summary>
        public String faultCode { get; set; }


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
