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
 * Swagger name: AvaTaxBeverageClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// The Response of the /shippingverify endpoint. Describes the result of checking all applicable shipping rules against each line in the transaction.
    /// </summary>
    public class ShippingVerifyResult
    {
        /// <summary>
        /// Whether every line in the transaction is compliant.
        /// </summary>
        public Boolean? compliant { get; set; }

        /// <summary>
        /// A short description of the result of the compliance check.
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// A detailed description of the result of each of the passed checks made against this transaction, separated by line.
        /// </summary>
        public String successMessages { get; set; }

        /// <summary>
        /// A detailed description of the result of each of the failed checks made against this transaction, separated by line.
        /// </summary>
        public String failureMessages { get; set; }

        /// <summary>
        /// An enumeration of all the failure codes received across all lines. Note: AlcoholContentLimitExceeded is included in API versions 2.2 and later.
        /// </summary>
        public List<FailureCodes> failureCodes { get; set; }

        /// <summary>
        /// An enumeration of all the warning codes received across all lines that a determination could not be made for.
        /// </summary>
        public List<String> warningCodes { get; set; }

        /// <summary>
        /// Describes the results of the checks made for each line in the transaction.
        /// </summary>
        public List<object> lines { get; set; }


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
