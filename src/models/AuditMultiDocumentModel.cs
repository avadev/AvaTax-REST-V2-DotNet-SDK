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
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Information about a previously created MultiDocument transaction
    /// </summary>
    public class AuditMultiDocumentModel
    {
        /// <summary>
        /// Reconstructed API request/response pair that can be used to adjust or re-create this MultiDocument transaction.
        /// </summary>
        public ReconstructedMultiDocumentModel reconstructed { get; set; }

        /// <summary>
        /// Represents the unique code of this MultiDocument transaction.
        /// 
        /// A MultiDocument transaction is uniquely identified by its `accountId`, `code`, and `type`.
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// Represents the document type of this MultiDocument transaction. For more information about
        /// document types, see [DocumentType](https://developer.avalara.com/api-reference/avatax/rest/v2/models/enums/DocumentType/).
        /// 
        /// A MultiDocument transaction is uniquely identified by its `accountId`, `code`, and `type`.
        /// </summary>
        public DocumentType? type { get; set; }

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
