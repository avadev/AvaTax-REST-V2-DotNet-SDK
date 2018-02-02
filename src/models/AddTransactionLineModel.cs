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
    /// Model to add specific lines to exising transaction
    /// </summary>
    public class AddTransactionLineModel
    {
        /// <summary>
        /// company code
        /// </summary>
        public String companyCode { get; set; }

        /// <summary>
        /// document code for the transaction to add lines
        /// </summary>
        public String transactionCode { get; set; }

        /// <summary>
        /// document type
        /// </summary>
        public DocumentType? documentType { get; set; }

        /// <summary>
        /// List of lines to be added
        /// </summary>
        public List<LineItemModel> lines { get; set; }

        /// <summary>
        /// Option to renumber lines after add. After renumber, the line number becomes: "1", "2", "3", ...
        /// </summary>
        public Boolean? renumber { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
