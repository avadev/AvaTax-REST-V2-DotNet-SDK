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
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a premium classification associated with an item's HS code for a system code.
    /// </summary>
    public class ItemPremiumClassificationInputModel
    {
        /// <summary>
        /// The HsCode for which this premium classification is being created.
        /// </summary>
        public String hsCode { get; set; }

        /// <summary>
        /// Justification why this HsCode is attached to this item.
        /// </summary>
        public String justification { get; set; }


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
