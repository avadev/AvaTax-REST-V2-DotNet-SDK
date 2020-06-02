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
    /// Error Transaction Model
    /// </summary>
    public class ErrorTransactionOutputModel
    {
        /// <summary>
        /// Error code of the error result from transaction creation
        /// </summary>
        public String errorCode { get; set; }

        /// <summary>
        /// Error message of the error result from transaction creation
        /// </summary>
        public String errorMessage { get; set; }

        /// <summary>
        /// The full JSON of the error result from transaction creation
        /// </summary>
        public String avataxErrorJson { get; set; }

        /// <summary>
        /// The full JSON of the transaction creation request
        /// </summary>
        public String avataxCreateTransactionJson { get; set; }

        /// <summary>
        /// The datasource instance that made the transaction creation call
        /// </summary>
        public String datasource { get; set; }

        /// <summary>
        /// The date of the document
        /// </summary>
        public DateTime? documentDate { get; set; }

        /// <summary>
        /// The date that this ErrorTransaction will be automatically purged from the detabase.
        /// </summary>
        public DateTime? expiresAt { get; set; }

        /// <summary>
        /// The amount of the transaction.
        /// </summary>
        public Decimal? amount { get; set; }

        /// <summary>
        /// The Datasource source of the transaction creation call.
        /// </summary>
        public String datasourceSource { get; set; }

        /// <summary>
        /// The country of the ship to address for the transaction creation call.
        /// </summary>
        public String shipToCountry { get; set; }

        /// <summary>
        /// The region of the ship to address for the transaction creation call.
        /// </summary>
        public String shipToRegion { get; set; }

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
