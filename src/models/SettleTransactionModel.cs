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
    /// Settle this transaction with your ledger by executing one or many actions against that transaction. 
    /// 
    /// You may use this endpoint to verify the transaction, change the transaction's code, and commit the transaction for reporting purposes.
    /// This endpoint may be used to execute any or all of these actions at once.
    /// </summary>
    public class SettleTransactionModel
    {
        /// <summary>
        /// To verify this transaction, you may provide information in this field.
        /// 
        /// If you leave this field null, the transaction will not be verified.
        /// </summary>
        public VerifyTransactionModel verify { get; set; }

        /// <summary>
        /// To change the code for this transaction, you may provide information in this field.
        /// 
        /// If you leave this field null, the transaction's code will not be changed.
        /// </summary>
        public ChangeTransactionCodeModel changeCode { get; set; }

        /// <summary>
        /// To commit this transaction so that it can be reported on a tax filing, you may provide information in this field.
        /// 
        /// If you leave this field null, the transaction's commit status will not be changed.
        /// 
        /// If you use Avalara's Managed Returns Service, committing a transaction will allow that transaction to be filed.
        /// </summary>
        public CommitTransactionModel commit { get; set; }


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
