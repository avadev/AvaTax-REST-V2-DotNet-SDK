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
    /// Represents a tax code classification request input model
    /// </summary>
    public class ItemTaxCodeClassificationRequestInputModel
    {
        /// <summary>
        /// Determines if classification has to be initiated for all items of a company
        /// </summary>
        public Boolean classifyAllItems { get; set; }

        /// <summary>
        /// Item ids for which classification has to be initiated
        /// </summary>
        public List<Int64> itemIds { get; set; }

        /// <summary>
        /// Product categories of items
        /// </summary>
        public List<String> productCategories { get; set; }


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
