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
    /// Commit this MultiDocument object so that all transactions within it can be reported on a tax filing.
    /// </summary>
    public class CommitMultiDocumentModel
    {
        /// <summary>
        /// Represents the unique code of this MultiDocument transaction.
        /// 
        /// A MultiDocument transaction is uniquely identified by its `accountId`, `code`, and `type`. ///
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
        /// Set this value to be `true` to commit this transaction.
        /// 
        /// Committing a transaction allows it to be reported on a tax filing. Uncommitted transactions will not be reported.
        /// </summary>
        public Boolean commit { get; set; }


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
