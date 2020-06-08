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
    /// Represents a transaction parameter.
    /// </summary>
    public class TransactionLineParameterModel
    {
        /// <summary>
        /// The name of the parameter.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The value of the parameter.
        /// </summary>
        public String value { get; set; }

        /// <summary>
        /// The unit of measure of the parameter value.
        /// </summary>
        public String unit { get; set; }


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
