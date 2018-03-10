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
    /// Information about a previously created transaction
    /// </summary>
    public class AuditTransactionModel
    {
        /// <summary>
        /// Unique ID number of the company that created this transaction
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// Reconstructed API request/response
        /// </summary>
        public ReconstructedApiRequestResponseModel reconstructed { get; set; }

        /// <summary>
        /// Server timestamp, in UTC, of the date/time when the original transaction was created
        /// </summary>
        public DateTime? serverTimestamp { get; set; }

        /// <summary>
        /// Length of time the original API call took
        /// </summary>
        public DateTime? serverDuration { get; set; }

        /// <summary>
        /// api call status
        /// </summary>
        public ApiCallStatus? apiCallStatus { get; set; }

        /// <summary>
        /// Original API request/response
        /// </summary>
        public OriginalApiRequestResponseModel original { get; set; }


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
