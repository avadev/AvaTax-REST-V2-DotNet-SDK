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
    /// Settle this transaction with your ledger by executing one or many actions against that transaction. 
        ///You may use this endpoint to verify the transaction, change the transaction's code, and commit the transaction for reporting purposes.
        ///This endpoint may be used to execute any or all of these actions at once.
    /// </summary>
    public class SettleTransactionModel
    {
        /// <summary>
        /// To use the "Settle" endpoint to verify a transaction, fill out this value.
        /// </summary>
        public VerifyTransactionModel verify { get; set; }

        /// <summary>
        /// To use the "Settle" endpoint to change a transaction's code, fill out this value.
        /// </summary>
        public ChangeTransactionCodeModel changeCode { get; set; }

        /// <summary>
        /// To use the "Settle" endpoint to commit a transaction for reporting purposes, fill out this value.
        ///If you use Avalara Returns, committing a transaction will cause that transaction to be filed.
        /// </summary>
        public CommitTransactionModel commit { get; set; }


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
