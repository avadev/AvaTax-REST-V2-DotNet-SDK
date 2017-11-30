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
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Verify that a MultiDocument object matches the information in your accounting system.
    /// 
    /// If all attributes of the MultiDocument object match the values in your request, the
    /// MultiDocument object will be moved to the document status `Posted`.
    /// 
    /// For more information on document status, see [DocumentStatus](https://developer.avalara.com/api-reference/avatax/rest/v2/models/enums/DocumentStatus/).
    /// </summary>
    public class VerifyMultiDocumentModel
    {
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
        public DocumentType type { get; set; }

        /// <summary>
        /// Set this value if you wish to verify a match between `verifyTransactionDate` and
        /// the `documentDate` value on the transaction recorded in AvaTax.
        /// 
        /// If you leave this field empty, we will skip verification for this field.
        /// </summary>
        public DateTime? verifyTransactionDate { get; set; }

        /// <summary>
        /// Set this value if you wish to verify a match between `verifyTotalAmount` and
        /// the `totalAmount` value on the transaction recorded in AvaTax.
        /// 
        /// If you leave this field empty, we will skip verification for this field.
        /// </summary>
        public Decimal? verifyTotalAmount { get; set; }

        /// <summary>
        /// Set this value if you wish to verify a match between `verifyTotalTax` and
        /// the `totalTax` value on the transaction recorded in AvaTax.
        /// 
        /// If you leave this field empty, we will skip verification for this field.
        /// </summary>
        public Decimal? verifyTotalTax { get; set; }


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
