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
    /// Class to accommodate Custom defined parameters
    /// </summary>
    public class ItemCustomParametersModel
    {
        /// <summary>
        /// The unique ID number of this item custom parameter
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// A unique code representing this item custom parameter.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The value of the custom parameter for this item.
        /// When creating or updating an item, you can specify custom parameter values
        /// to store additional metadata or business-specific information.
        /// </summary>
        public String value { get; set; }


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
