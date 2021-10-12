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
    /// The resource model returned by the ECommerceTokenController's endpoints.
    /// </summary>
    public class ECommerceTokenOutputModel
    {
        /// <summary>
        /// The JWT token that authorizes the gencert tool to operate.
        /// </summary>
        public String token { get; set; }

        /// <summary>
        /// The list of clients that the token is valid for.
        /// </summary>
        public List<Int64> clientIds { get; set; }

        /// <summary>
        /// The date the token was created.
        /// </summary>
        public DateTime createdDate { get; set; }

        /// <summary>
        /// The date that the token will expire.
        /// </summary>
        public DateTime expirationDate { get; set; }


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
