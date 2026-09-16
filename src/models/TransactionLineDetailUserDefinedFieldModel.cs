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
    /// A user-defined field value assigned to a tax detail.
    /// </summary>
    public class TransactionLineDetailUserDefinedFieldModel
    {
        /// <summary>
        /// The name of the user defined field.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The value of the user defined field.
        /// </summary>
        public String value { get; set; }

        /// <summary>
        /// The customer-friendly name of the user defined field.
        /// </summary>
        public String friendlyName { get; set; }


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
