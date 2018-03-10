using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a transaction/service type pair for telecommunications tax
    /// </summary>
    public class CommunicationsTSPairModel
    {
        /// <summary>
        /// The numeric Id of the transaction type.
        /// </summary>
        public Int32 transactionTypeId { get; set; }

        /// <summary>
        /// The numeric Id of the service type.
        /// </summary>
        public Int32 serviceTypeId { get; set; }

        /// <summary>
        /// The name of the transaction type.
        /// </summary>
        [JsonProperty(PropertyName = "AvaTax.Communications.TransactionType")]
        public String TransactionType { get; set; }

        /// <summary>
        /// The name of the service type.
        /// </summary>
        [JsonProperty(PropertyName = "AvaTax.Communications.ServiceType")]
        public String ServiceType { get; set; }

        /// <summary>
        /// The description of the transaction/service type pair.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// List of the parameters (among Charge, Minutes and Lines) that will be used for calculation for this T/S pair.
        /// </summary>
        public List<String> requiredParameters { get; set; }


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
