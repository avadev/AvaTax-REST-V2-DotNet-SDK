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
 * Swagger name: AvaTaxBeverageClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// The Request for the /ageVerification/verify endpoint. Describes information about the person whose age is being verified.
    /// </summary>
    public class AgeVerifyRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public String firstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String lastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object address { get; set; }

        /// <summary>
        /// The value should be ISO-8601 compliant (e.g. 2020-07-21).
        /// </summary>
        public String DOB { get; set; }


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
