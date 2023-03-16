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
 * Swagger name: AvaTaxBeverageClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// The Result of a call to the /ageVerification/verify endpoint.
    /// </summary>
    public class AgeVerifyResult
    {
        /// <summary>
        /// Describes whether the individual meets or exceeds the minimum legal drinking age.
        /// </summary>
        public Boolean? isOfAge { get; set; }

        /// <summary>
        /// A list of failure codes describing why a *false* age determination was made.
        /// </summary>
        public List<AgeVerifyFailureCode> failureCodes { get; set; }


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
