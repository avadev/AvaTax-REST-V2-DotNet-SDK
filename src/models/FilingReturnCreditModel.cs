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
    /// An attachment associated with a filing return
    /// </summary>
    public class FilingReturnCreditModel
    {
        /// <summary>
        /// The resourceFileId used to retrieve the attachment
        /// </summary>
        public Decimal? totalSales { get; set; }

        /// <summary>
        /// The resourceFileId used to retrieve the attachment
        /// </summary>
        public Decimal? totalExempt { get; set; }

        /// <summary>
        /// The resourceFileId used to retrieve the attachment
        /// </summary>
        public Decimal? totalTaxable { get; set; }

        /// <summary>
        /// The resourceFileId used to retrieve the attachment
        /// </summary>
        public Decimal? totalTax { get; set; }

        /// <summary>
        /// The excluded carry over credit documents
        /// </summary>
        public List<CreditTransactionDetails> transactionDetails { get; set; }


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
