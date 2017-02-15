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
    /// Settle this transaction with your ledger by verifying its amounts.
        ///If the transaction is not yet committed, you may specify the "commit" value to commit it to the ledger and allow it to be reported.
        ///You may also optionally change the transaction's code by specifying the "newTransactionCode" value.
    /// </summary>
    public class ChangeTransactionCodeModel
    {
        /// <summary>
        /// To change the transaction code for this transaction, specify the new transaction code here.
        /// </summary>
        public String newCode { get; set; }


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
