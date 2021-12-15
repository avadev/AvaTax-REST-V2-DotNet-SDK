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
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// A request to void a previously created transaction.
    /// </summary>
    public class BatchVoidTransactionModel
    {
        /// <summary>
        /// Company Code - Specify the code of the company for this transaction.
        /// </summary>
        public String companyCode { get; set; }

        /// <summary>
        /// Please specify the transaction code of the transacion to void.
        /// </summary>
        public String transactionCode { get; set; }

        /// <summary>
        /// Specifies the type of document to void.
        /// </summary>
        public String documentType { get; set; }

        /// <summary>
        /// Please specify the reason for voiding or cancelling this transaction.
        /// To void the transaction, please specify the reason 'DocVoided'.
        /// If you do not provide a reason, the void command will fail.
        /// </summary>
        public VoidReasonCode code { get; set; }


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
