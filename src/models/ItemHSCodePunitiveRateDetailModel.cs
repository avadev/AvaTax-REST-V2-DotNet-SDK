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
    /// Represents HS Code Punitive Rate Details.
    /// </summary>
    public class ItemHSCodePunitiveRateDetailModel
    {
        /// <summary>
        /// The rate for this punitive duty.
        /// </summary>
        public String rate { get; set; }

        /// <summary>
        /// The unit of measure.
        /// </summary>
        public String uom { get; set; }

        /// <summary>
        /// Whether this rate is stackable with other rates.
        /// </summary>
        public Boolean? isStackable { get; set; }

        /// <summary>
        /// Whether this is a tax on tax.
        /// </summary>
        public Boolean? isTaxOnTax { get; set; }


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
