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
    /// Response model of a single error transaction delete
    /// </summary>
    public class DeleteErrorTransactionResponseModel
    {
        /// <summary>
        /// Result of the deletion
        /// </summary>
        public AvataxDeleteErrorTransactionStatus? result { get; set; }

        /// <summary>
        /// Type of transaction of the error transaction
        /// </summary>
        public DocumentType documentType { get; set; }

        /// <summary>
        /// The internal reference code (used by the client application) of the error transaction
        /// </summary>
        public String documentCode { get; set; }


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
