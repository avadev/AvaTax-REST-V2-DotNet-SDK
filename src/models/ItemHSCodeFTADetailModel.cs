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
    /// Represents HS Code FTA (Free Trade Agreement) Details.
    /// </summary>
    public class ItemHSCodeFTADetailModel
    {
        /// <summary>
        /// The name of the FTA.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The rate for this FTA.
        /// </summary>
        public String rate { get; set; }

        /// <summary>
        /// The unit of measure.
        /// </summary>
        public String uom { get; set; }


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
