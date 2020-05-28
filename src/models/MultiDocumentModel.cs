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
    /// A MultiDocument transaction represents a sale or purchase that occurred between more than two companies.
    ///  
    /// A traditional transaction requires exactly two parties: a seller and a buyer. MultiDocument transactions can
    /// involve a marketplace of vendors, each of which contributes some portion of the final transaction. Within
    /// a MultiDocument transaction, each individual buyer and seller pair are matched up and converted to a separate
    /// document. This separation of documents allows each seller to file their taxes separately.
    /// </summary>
    public class MultiDocumentModel
    {
        /// <summary>
        /// The unique ID number of this MultiDocument object.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The unique ID number of the AvaTax customer account that created this MultiDocument object.
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// The transaction code of the MultiDocument transaction.
        ///  
        /// All individual transactions within this MultiDocument object will have this code as a prefix.
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// Indicates the type of MultiDocument transaction. Common values are:
        ///  
        /// * SalesOrder - An estimate that is not permanently recorded
        /// * SalesInvoice - An invoice that can be reported on a tax return
        ///  
        /// For more information about document types, see [DocumentType](https://developer.avalara.com/api-reference/avatax/rest/v2/models/enums/DocumentType/)
        /// </summary>
        public DocumentType? type { get; set; }

        /// <summary>
        /// The user ID of the user who created this record.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The date/time when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }

        /// <summary>
        /// A separate document will exist for each unique combination of buyer and seller in this MultiDocument transaction.
        /// </summary>
        public List<TransactionModel> documents { get; set; }


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
