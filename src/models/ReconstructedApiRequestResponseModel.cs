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
    /// This model contains a reconstructed CreateTransaction request object that could potentially be used
    /// to recreate this transaction.
    ///  
    /// Note that the API changes over time, and this reconstructed model is likely different from the exact request
    /// that was originally used to create this transaction.
    /// </summary>
    public class ReconstructedApiRequestResponseModel
    {
        /// <summary>
        /// API request
        /// </summary>
        public CreateTransactionModel request { get; set; }


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
